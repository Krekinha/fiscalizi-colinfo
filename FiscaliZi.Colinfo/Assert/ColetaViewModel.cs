using System;
using FiscaliZi.Colinfo.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using FiscaliZi.Colinfo.Utils;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Servicos.ConsultaCadastro;
using NFe.Classes.Servicos.Tipos;
using NFe.Servicos;
using NFe.Utils.Excecoes;
using TipoAmbiente = NFe.Classes.Informacoes.Identificacao.Tipos.TipoAmbiente;
using DFe.Utils;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using PostSharp.Patterns.Model;

namespace FiscaliZi.Colinfo.Assert
{
    [NotifyPropertyChanged]
    public class ColetaViewModel : PropertyChangedBase
    {
        private readonly IDataService dataService;
        const string dir_Pedidos = @"Pedidos\";
        private IEventAggregator _events;

        public ColetaViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
            dataService = new DataService();

            Vendedores = dataService.GetVendedores();
            Configuracoes = CarregarConfiguracoes();
            InitializeMonitor();
        }

        #region · Properties ·

        private ObservableCollection<Vendedor> _vendedores { get; set; }

        public ObservableCollection<Vendedor> Vendedores { get; set; }

        public ConfiguracaoApp Configuracoes { get; set; }
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
        private void AtualizaVendedores()
        {
            var vnds = dataService.GetVendedores();
            if(Vendedores.Count > 0)
                Vendedores.Clear();
            foreach (var vnd in vnds)
            {
                Vendedores.Add(vnd);
            }
        }
        public void RemoverVendedor(Vendedor vnd)
        {
            dataService.RemoverVendedor(vnd);
            AtualizaVendedores();
        }
        private void EditarVendedor(Vendedor vnd)
        {
            dataService.EditarVendedor(vnd);
            /*Vendedor = vnd;
            Vendedor.ForcePropertyChanged("Pedidos");*/
            //RaisePropertyChanged("Vendedores");

        }
        private void EditarPedido(Pedido ped)
        {
            //dataService.EditarPedido(ped);
            //ped.ForcePropertyChanged("Cliente");
            //RaisePropertyChanged("Vendedores");

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
                    var vnd = Coletor.getColeta(e.FullPath, e.Name);
                    File.Delete(e.FullPath);

                    if (vnd != null)
                    {
                        dataService.AddVendedor(vnd);
                        Application.Current.Dispatcher.Invoke(delegate
                        {
                            Vendedores.Add(vnd);
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
            
            var recRet = new Model.retConsCad();
            Task.Run(() =>
            {
                try
                {
                    var servicoNFe = new ServicosNFe(Configuracoes.CfgServico);
                    //var cert = CertificadoDigital.ListareObterDoRepositorio();
                    //Configuracoes.CfgServico.Certificado.Serial = cert.SerialNumber;
                    var retornoConsulta = servicoNFe.NfeConsultaCadastro("MG", (ConsultaCadastroTipoDocumento)1, ped.Cliente.CNPJ.Replace(".", "").Replace("/", "").Replace("-", ""));
                    recRet = FuncoesXml.XmlStringParaClasse<Model.retConsCad>(retornoConsulta.RetornoCompletoStr);
                    //ped.Cliente.RetConsultaCadastro = recRet;

                    using (var context = new ColinfoContext())
                    {
                        var vnd = context.Vendedores
                        .Include(vd => vd.Pedidos)
                        .ThenInclude(cli => cli.Cliente)
                        .ThenInclude(cons => cons.RetConsultaCadastro)
                        .ThenInclude(inf => inf.infCons)
                        .ThenInclude(cad => cad.infCad)
                        .FirstOrDefault(v => v.VendedorID == ped.VendedorID);

                        var oldPed = vnd.Pedidos.FirstOrDefault(pd => pd.PedidoID == ped.PedidoID);
                        var ctxPed = Vendedores.FirstOrDefault(v => v.VendedorID == ped.VendedorID).Pedidos.Find(p => p.PedidoID == ped.PedidoID);

                        oldPed.Cliente.RetConsultaCadastro = recRet;
                        context.Entry(oldPed).State = EntityState.Modified;
                        context.SaveChanges();

                        ctxPed.Cliente.RetConsultaCadastro = recRet;
                    }
                }
                catch (ComunicacaoException ex)
                {
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
                catch (DbUpdateException ex)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    var consulta = new Model.retConsCad()
                    {
                        ErrorCode = "err_dives",
                        ErrorMessage = ex.Message
                    };
                    EditarPedido(ped, consulta);
                }
            });

        }
        private void ConsultaCadastros(Vendedor vnd)
        {
            foreach (var ped in vnd.Pedidos)
            {
                if (IsCNPJ(ped.Cliente.CNPJ))
                    ConsultaCadastro(ped);
            }

        }
        private ConfiguracaoApp CarregarConfiguracoes()
        {
            var config = new ConfiguracaoApp();
            config.CfgServico.Certificado.Serial = "29CC1C5B551BABA7";
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

            config.EnderecoEmitente.UF = "MG";

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
            var digts = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
            var idx = digts.Length - 6;

            return digts.Substring(idx, 4) != "0000";
        }

        private void ShowPedidoFlyout( Pedido ped)
        {
            //((MainView)Application.Current.MainWindow).LeftFlyout.IsOpen = !((MainView)Application.Current.MainWindow).LeftFlyout.IsOpen;
            //((MainView) Application.Current.MainWindow).LeftFlyout.DataContext = ped;
        }

        private void EditarPedido(Pedido ped, Model.retConsCad consulta)
        {
            using (var context = new ColinfoContext())
            {
                var vnd = context.Vendedores
                    .Include(vd => vd.Pedidos)
                    .ThenInclude(cli => cli.Cliente)
                    .ThenInclude(cons => cons.RetConsultaCadastro)
                    .ThenInclude(inf => inf.infCons)
                    .ThenInclude(cad => cad.infCad)
                    .FirstOrDefault(v => v.VendedorID == ped.VendedorID);

                var oldPed = vnd.Pedidos.FirstOrDefault(pd => pd.PedidoID == ped.PedidoID);
                var ctxPed = Vendedores.FirstOrDefault(v => v.VendedorID == ped.VendedorID).Pedidos.Find(p => p.PedidoID == ped.PedidoID);

                oldPed.Cliente.RetConsultaCadastro = consulta;
                context.Entry(oldPed).State = EntityState.Modified;
                context.SaveChanges();

                ctxPed.Cliente.RetConsultaCadastro = consulta;
            }
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
                var view = new Dialog_Conculta()
                {
                    DataContext = ped
                };

                var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
            }
            
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }

        #endregion


    }
}
