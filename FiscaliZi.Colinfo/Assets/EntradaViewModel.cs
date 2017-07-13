using System;
using System.Collections.Generic;
using FiscaliZi.Colinfo.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Utils;
using NFe.Classes.Servicos.ConsultaCadastro;
using NFe.Servicos;
using NFe.Utils.Excecoes;
using DFe.Utils;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;

namespace FiscaliZi.Colinfo.Assets
{
    public class EntradaViewModel : PropertyChangedBase
    {
        const string dir_Pedidos = @"Pedidos\";
        private IEventAggregator _events;

        public EntradaViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);

            Arquivos = GetArquivos();

            Configuracoes = CarregarConfiguracoes();
            //Configuracoes = settings();

            InitializeMonitor();
            RomaneioNum = 2;
            RomaneioData = DateTime.Now;
            SnackbarMQ = new SnackbarMessageQueue();
        }

        #region · Properties ·
        public ObservableCollection<Arquivo> Arquivos { get; set; }
        public List<Pedido> PedidosPendentes { get; set; }
        public SnackbarMessageQueue SnackbarMQ { get; set; }
        public Arquivo Arquivo { get; set; }
        public AppSettings Configuracoes { get; set; }
        public int RomaneioNum { get; set; }
        public DateTime RomaneioData { get; set; }
        #endregion

        #region · Constructors ·

        private void InitializeMonitor()
        {
            var path = @"F:\SOF\VDWIN\PTPED";
            if (Environment.MachineName == "ATAIDE-PC")
                path = @"D:\SOF\VDWIN\PTPED";

            MonitorTXTPED();
            Monitors.MonitorGZPTPED(path);
            Monitors.MonitorGZPED();
            
        }
        public void AtualizaArquivos()
        {
            var vnds = GetArquivos();
            if(Arquivos.Count > 0)
                Arquivos.Clear();
            foreach (var vnd in vnds)
            {
                Arquivos.Add(vnd);
            }
        }

        private void MonitorTXTPED()
        {
            if (!Directory.Exists(dir_Pedidos))
            {
                Directory.CreateDirectory(dir_Pedidos);
            }

            var dir = new DirectoryInfo(dir_Pedidos);
            foreach (var file in dir.GetFiles())
            {
                file.Delete();
            }

            var fsw = new FileSystemWatcher(dir_Pedidos, "*.txt");
            fsw.Created += new FileSystemEventHandler(fswTXT_Created);
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime;
            fsw.EnableRaisingEvents = true;

        }
        private void fswTXT_Created(object sender, FileSystemEventArgs e)
        {
            var NumberOfRetries = 3000;
            const int DelayOnRetry = 10;

            for (var i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                    var vnd = Coletor.getArquivo(e.FullPath, e.Name);
                    File.Delete(e.FullPath);

                    if (vnd != null)
                    {
                        //AddArquivo(vnd);
                        Application.Current.Dispatcher.Invoke(delegate
                        {
                            Arquivos.Add(vnd);
                        });
                        ConsultaCadastros(vnd);
                    }
                    break;
                }
                catch (IOException)
                {
                    if (i == NumberOfRetries)
                        throw;

                    Thread.Sleep(DelayOnRetry);
                }
            }
        }

        public void ConsultaCadastro(Pedido ped)
        {
            int NumOfRetries = 10;
            int trysExCom = 0;
            int trysExOthers = 0;
            var recRet = new Model.retConsCad();
            Task.Run(() =>
            {
                TryAgain:
                try
                {
                    var servicoNFe = new ServicosNFe(Configuracoes.CfgServico);
                    //var cert = DFe.Utils.Assinatura.CertificadoDigital.ListareObterDoRepositorio();
                    //Configuracoes.CfgServico.Certificado.Serial = cert.SerialNumber;
                    //Configuracoes.CfgServico.Certificado.Serial = "00D424AA";

                    var retornoConsulta = servicoNFe.NfeConsultaCadastro("MG", (ConsultaCadastroTipoDocumento)1, ped.Cliente.CNPJ.Replace(".", "").Replace("/", "").Replace("-", ""));
                    recRet = FuncoesXml.XmlStringParaClasse<Model.retConsCad>(retornoConsulta.RetornoCompletoStr);
                    //ped.Cliente.RetConsultaCadastro = recRet;

                    using (var context = new ColinfoContext())
                    {
                        var vnd = context.Arquivos
                        .Include(vd => vd.Pedidos)
                        .ThenInclude(cli => cli.Cliente)
                        .ThenInclude(cons => cons.RetConsultaCadastro)
                        .ThenInclude(inf => inf.infCons)
                        .ThenInclude(cad => cad.infCad)
                        .FirstOrDefault(v => v.ArquivoID == ped.Arquivo.ArquivoID);

                        var oldPed = vnd.Pedidos.FirstOrDefault(pd => pd.PedidoID == ped.PedidoID);
                        var ctxPed = Arquivos.FirstOrDefault(v => v.ArquivoID == ped.Arquivo.ArquivoID).Pedidos.FirstOrDefault(p => p.PedidoID == ped.PedidoID);
                        var ctxVnd = Arquivos.FirstOrDefault(v => v.ArquivoID == ped.Arquivo.ArquivoID);

                        oldPed.Cliente.RetConsultaCadastro = recRet;
                        oldPed.Cliente.Situacao = SituacaoCadastro(oldPed);
                        context.Entry(oldPed).State = EntityState.Modified;
                        context.SaveChanges();

                        ctxPed.Cliente.RetConsultaCadastro = recRet;

                        Arquivo = ctxVnd;
                        
                        NotifyOfPropertyChange(() => ctxVnd.Pedidos);

                        NotifyOfPropertyChange(() => Arquivo.Pedidos);

                        Arquivo.ForcePropertyChanged("Pedidos");
                        ctxPed.Cliente.ForcePropertyChanged("RetConsultaCadastro");
                    }
                }
                catch (ComunicacaoException ex)
                {
                    if (trysExCom < NumOfRetries)
                    {
                        trysExCom += 1;
                        goto TryAgain;
                        
                    }
                    var consulta = new Model.retConsCad()
                    {
                        ErrorCode = "err_dives",
                        ErrorMessage = ex.Message
                    };
                    EditarPedido(ped, consulta);
                }
                catch (ValidacaoSchemaException ex)
                {
                    var consulta = new Model.retConsCad()
                    {
                        ErrorCode = "err_dives",
                        ErrorMessage = ex.Message
                    };
                    EditarPedido(ped, consulta);
                }
                catch (DbUpdateException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    if (trysExOthers < NumOfRetries)
                    {
                        trysExOthers += 1;
                        goto TryAgain;

                    }
                    var consulta = new Model.retConsCad()
                    {
                        ErrorCode = "err_dives",
                        ErrorMessage = ex.Message
                    };
                    EditarPedido(ped, consulta);
                }
            });

        }
        public void ReconsultaCadastros()
        {
            foreach (var arq in Arquivos)
            {
                foreach (var ped in arq.Pedidos)
                {
                    if (IsCNPJ(ped.Cliente.CNPJ) 
                        && ped.SitPed != "HABILITADO" 
                        && ped.SitPed != "ISENTO")
                        ConsultaCadastro(ped);
                }
            }
        }

        private string SituacaoCadastro(Pedido ped)
        {
            var cnpj = ped.Cliente?.CNPJ;
            var consulta = ped.Cliente?.RetConsultaCadastro;
            var ie = ped.Cliente?.IE;

            if (string.IsNullOrEmpty(cnpj)) return "???";
            var digts = Tools.SoString(cnpj);
            var idx = digts.Length - 6;
            if (digts.Substring(idx, 4) == "0000") return "ISENTO";

            if (consulta != null)
            {
                if (consulta.ErrorCode == "err_dives") return "ERRO";

                if (ie == "" || ie == "ISENTO")
                {
                    return consulta.infCons?.infCad?.Count > 0 ? "ERRO" : "ISENTO";
                }

                var sit = consulta.infCons?.infCad.Find(s => s.IE == ie.Replace(".", "").Replace("/", ""));
                if (sit == null)
                {
                    return !string.IsNullOrEmpty(consulta.infCons.cStat) ? "ERRO" : "CONSULTAR";
                }
                switch (sit.cSit)
                {
                    case "1":
                        return "HABILITADO";
                    case "0":
                        return "REJEIÇÃO";
                    default:
                        return "?????";
                }
            }
            else
            {
                if (ie == "" || ie == "ISENTO") return "ISENTO";
                return "CONSULTAR";
            }
        }
        private void ConsultaCadastros(Arquivo arq)
        {
            foreach (var ped in arq.Pedidos)
            {
                if (IsCNPJ(ped.Cliente.CNPJ))
                    ConsultaCadastro(ped);
            }

        }
        private AppSettings CarregarConfiguracoes()
        {
            var config = Funcoes.CarregarConfiguracoes();
            /*config.CfgServico.Certificado.Serial = "29CC1C5B551BABA7";
            config.CfgServico.Certificado.ManterDadosEmCache = true;
            config.CfgServico.TimeOut = 5000;
            config.CfgServico.cUF = (Estado) 31;
            config.CfgServico.tpAmb = TipoAmbiente.taProducao;
            config.CfgServico.tpEmis = TipoEmissao.teNormal;
            config.CfgServico.ModeloDocumento = (ModeloDocumento) 55;
            config.CfgServico.VersaoNfeConsultaCadastro = VersaoServico.ve200;
            config.CfgServico.SalvarXmlServicos = false;
            config.CfgServico.DiretorioSchemas = @"Schemas";

            config.CfgServico.ProtocoloDeSeguranca = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;

            config.Emitente.CNPJ = "21795927000488";
            config.Emitente.CRT = (CRT) 1;

            config.EnderecoEmitente.UF = "MG";*/

            return config;
        }
        private static string DesmascararCNPJ(string cnpj)
        {
            return cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
        }
        private string SituacaoCliente(Cliente cli, bool erro)
        {
            if (erro) return "ERRO";

            if (cli.Situacao == "CONSULTAR")
            {
                if (cli.IE == "" || cli.IE == "ISENTO")
                {
                    if (cli.RetConsultaCadastro.infCons.infCad.Count > 0)
                    {
                        return "ERRO";
                    }
                    else
                    {
                        return "ISENTO";
                    }
                }
                else
                {
                    if (cli.RetConsultaCadastro.infCons.infCad.Count > 0)
                    {
                        var sit = cli.RetConsultaCadastro.infCons.infCad.Find(s => s.IE == cli.IE.Replace(".", "").Replace("/", ""));
                        if (sit != null)
                        {
                            if (sit.cSit == "1")
                            {
                                return "HABILITADO";
                            }
                            else if (sit.cSit == "0")
                            {
                                return "REJEIÇÃO";
                            }
                            else
                            {
                                return "?????";
                            }
                        }
                    }
                }
            }
            return "?????";
        }

        private static bool IsCNPJ(string cnpj)
        {
            if (cnpj == null) return false;
            var digts = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
            var idx = digts.Length - 6;

            return digts.Substring(idx, 4) != "0000";
        }

        public void ShowPedidoFlyout( Pedido ped)
        {
            ((MainView)Application.Current.MainWindow).LeftFlyout.IsOpen = !((MainView)Application.Current.MainWindow).LeftFlyout.IsOpen;
            ((MainView) Application.Current.MainWindow).LeftFlyout.DataContext = ped;
        }

        public async void ShowConsulta(Pedido ped)
        {
            var consulta = ped.Cliente.RetConsultaCadastro;

            if (consulta?.ErrorCode == "err_dives")
            {
                var view = new Dialog_ErroConsulta()
                {
                    DataContext = consulta
                };

                var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }
            else
            {
                var view = new Dialog_Consulta()
                {
                    DataContext = ped
                };

                var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }
            
        }

        public async void Dialog_AddRomaneio()
        {
            var view = new Dialog_AddRomaneio{DataContext = this};

            var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);

            var path = @"F:\SOF\VDWIN\EXP\PEDIDOS.CSV";

            if (Environment.MachineName == "ATAIDE-PC")
                path = @"C:\Users\krekm\Desktop\PEDIDOS.CSV";

            using (var context = new ColinfoContext())
            {
                var NumRom = ToRomaneio();

                var rom = Coletor.GetRomaneio(path, NumRom);

                if (rom != null)
                {
                    Application.Current.Dispatcher.Invoke(delegate
                    {
                        Arquivos.Add(rom);
                    });
                    ConsultaCadastros(rom);
                }
            }
        }

        public void AddRomaneio(string rom)
        {
            var r = rom;
        }
        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }

        private string ToRomaneio()
        {
            if (RomaneioNum > 0)
            {
                return $"{RomaneioData.Year}{RomaneioData.Month:00}{RomaneioData.Day:00}{RomaneioNum:000}";
            }
            return "";
        }

        public async void Notify()
        {
            await Task.Run(() =>
             {
                 _events.PublishOnUIThread(new NotifyMessage("venho do entradavm", ""));
             });
             
        }

        #endregion

        #region · CRUD ·

        public void EditarPedido(Pedido ped, Model.retConsCad consulta)
        {
            using (var context = new ColinfoContext())
            {
                var vnd = context.Arquivos
                    .Include(vd => vd.Pedidos)
                    .ThenInclude(cli => cli.Cliente)
                    .ThenInclude(cons => cons.RetConsultaCadastro)
                    .ThenInclude(inf => inf.infCons)
                    .ThenInclude(cad => cad.infCad)
                    .FirstOrDefault(v => v.ArquivoID == ped.Arquivo.ArquivoID);

                var oldPed = vnd.Pedidos.FirstOrDefault(pd => pd.PedidoID == ped.PedidoID);
                var ctxPed = Arquivos.FirstOrDefault(v => v.ArquivoID == ped.Arquivo.ArquivoID).Pedidos.FirstOrDefault(p => p.PedidoID == ped.PedidoID);

                oldPed.Cliente.RetConsultaCadastro = consulta;
                oldPed.Cliente.Situacao = SituacaoCadastro(oldPed);
                context.Entry(oldPed).State = EntityState.Modified;
                context.SaveChanges();

                ctxPed.Cliente.RetConsultaCadastro = consulta;
            }
        }
        public void RemoverArquivo(Arquivo arq)
        {
            using (var context = new ColinfoContext())
            {
                try
                {
                    var a1 = context.Arquivos.Find(arq.ArquivoID);
                    context.Arquivos.Remove(a1);
                    context.Entry(a1).State = EntityState.Deleted;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var msg = "";
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        msg = ex.InnerException?.Message ?? ex.Message;
                        //ShowDialogErrorAsync(msg);
                    }
                }
            }

            AtualizaArquivos();
        }
        public void AddArquivo(Arquivo arq)
        {
            using (var context = new ColinfoContext())
            {
                context.Add(arq);
                context.SaveChanges();
            }

        }
        public void LimparTudo()
        {
            using (var context = new ColinfoContext())
            {
                try
                {
                    context.Arquivos.RemoveRange();
                    var existingArqs = context.Arquivos.ToList();
                    context.Arquivos.RemoveRange(existingArqs);
                    context.SaveChanges();
                    AtualizaArquivos();
                }
                catch (Exception ex)
                {
                    var msg = "";
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        msg = ex.InnerException?.Message ?? ex.Message;
                        //ShowDialogErrorAsync(msg);
                    }
                }
            }

            AtualizaArquivos();
        }
        private ObservableCollection<Arquivo> GetArquivos()
        {
            using (var context = new ColinfoContext())
            {
                var Arqs = new ObservableCollection<Arquivo>();

                var arqs = context.Arquivos
                    .Include(vnd => vnd.Pedidos)
                    .ThenInclude(cli => cli.Cliente)
                    .ThenInclude(ret => ret.RetConsultaCadastro)
                    .ThenInclude(inf => inf.infCons)
                    .ThenInclude(inf2 => inf2.infCad);

                foreach (var item in arqs)
                {
                    Arqs.Add(item);
                }

                return Arqs;
            }
        }

        #endregion

        private AppSettings settings()
        {
            var config = new AppSettings();
            config.CfgServico.Certificado = new DFe.Utils.ConfiguracaoCertificado
            {
                Serial = "00D424AA",
                ManterDadosEmCache = true,

                TipoCertificado = TipoCertificado.A1Repositorio
            };
            config.CfgServico.TimeOut = 5000;
            config.CfgServico.cUF = (DFe.Classes.Entidades.Estado)31;
            config.CfgServico.tpAmb = NFe.Classes.Informacoes.Identificacao.Tipos.TipoAmbiente.taProducao;
            config.CfgServico.tpEmis = NFe.Classes.Informacoes.Identificacao.Tipos.TipoEmissao.teNormal;
            config.CfgServico.ModeloDocumento = (DFe.Classes.Flags.ModeloDocumento)55;
            config.CfgServico.VersaoNfeConsultaCadastro = NFe.Classes.Servicos.Tipos.VersaoServico.ve200;
            config.CfgServico.SalvarXmlServicos = false;
            config.CfgServico.DiretorioSchemas = @"Schemas";
            config.CfgServico.ProtocoloDeSeguranca = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            return config;
        }
    }
}
