using System;
using FiscaliZi.Colinfo.Model;
using GalaSoft.MvvmLight;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using DFe.Utils.Assinatura;
using FiscaliZi.Colinfo.Utils;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Practices.ServiceLocation;
using NFe.Classes;
using NFe.Classes.Informacoes.Emitente;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Servicos.ConsultaCadastro;
using NFe.Classes.Servicos.Tipos;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using NFe.Utils;
using NFe.Utils.Excecoes;
using TipoAmbiente = NFe.Classes.Informacoes.Identificacao.Tipos.TipoAmbiente;
using System.Linq;
using System.Runtime.InteropServices;
using DFe.Utils;
using NFe = NFe.Classes.NFe;

namespace FiscaliZi.Colinfo.ViewModel
{
    [ImplementPropertyChanged]
    public class ColetaViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        const string dir_Pedidos = @"Pedidos\";

        public ColetaViewModel(IDataService _dataService)
        {
            dataService = _dataService;
            if (IsInDesignMode)
            {
                Vendedores = new ObservableCollection<Vendedor>()
                {
                    new Vendedor
                    {
                        VendedorID = 1,
                        NumVendedor = 308,
                        DataColeta = DateTime.Now,
                        DataEnvio = DateTime.Parse("03/05/2000 00:00:00"),
                        NomeVendedor = "RAFAEL ALVES",
                        ArquivoVendedor = "TXAA0600000308.TXT"
                    }
                };
            }
            else
            {
                Vendedores = dataService.GetVendedores();
            }

            Configuracoes = CarregarConfiguracoes();
            InitializeMonitor();

            #region Commands

            RemoverVendedorCommand = new RelayCommand<Vendedor>(RemoverVendedor);
            ConsultaCadastroCommand = new RelayCommand<Pedido>(ConsultaCadastro);
            ShowPedidoFlyoutCommand = new RelayCommand<Pedido>(ShowPedidoFlyout);

            #endregion
        }

        #region · Properties ·

        #region Commands

        public RelayCommand<Vendedor> RemoverVendedorCommand { get; set; }
        public RelayCommand<Pedido> ConsultaCadastroCommand { get; set; }
        public RelayCommand<Pedido> ShowPedidoFlyoutCommand { get; set; }

        #endregion
        public ObservableCollection<Vendedor> Vendedores { get; set; }

        private ConfiguracaoApp _configuracoes;

        public ConfiguracaoApp Configuracoes
        {
            get { return _configuracoes; }
            set
            {
                Set(() => Configuracoes, ref _configuracoes, value);
            }
        }
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
        private void RemoverVendedor(Vendedor vnd)
        {
            dataService.RemoverVendedor(vnd);
            AtualizaVendedores();
        }
        private void EditarVendedor(Vendedor vnd)
        {
            dataService.EditarVendedor(vnd);
            /*Vendedor = vnd;
            Vendedor.ForcePropertyChanged("Pedidos");*/
            RaisePropertyChanged("Vendedores");

        }
        private void EditarPedido(Pedido ped)
        {
            dataService.EditarPedido(ped);
            ped.ForcePropertyChanged("Cliente");
            RaisePropertyChanged("Vendedores");

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
                    dataService.AddVendedor(vnd);
                    File.Delete(e.FullPath);
                    Application.Current.Dispatcher.Invoke(delegate
                        {
                            Vendedores.Add(vnd);
                        });
                    
                    ConsultaCadastros(vnd);
                    //AtualizaVendedores();
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

        private void ConsultaCadastro(Pedido ped)
        {
            Task.Run(() =>
            {
                try
                {
                    var servicoNFe = new ServicosNFe(Configuracoes.CfgServico);
                    //var cert = CertificadoDigital.ListareObterDoRepositorio();
                    //Configuracoes.CfgServico.Certificado.Serial = cert.SerialNumber;
                    var retornoConsulta = servicoNFe.NfeConsultaCadastro("MG", (ConsultaCadastroTipoDocumento)1, ped.Cliente.CNPJ.Replace(".", "").Replace("/", "").Replace("-", ""));
                    var recRet = FuncoesXml.XmlStringParaClasse<Model.retConsCad>(retornoConsulta.RetornoCompletoStr);
                    ped.Cliente.RetConsultaCadastro = recRet;
                    EditarPedido(ped);
                    ped.ForcePropertyChanged("Cliente");
                }
                catch (ComunicacaoException ex)
                {
                    Funcoes.Mensagem(ex.Message, "Erro", MessageBoxButton.OK);
                }
                catch (ValidacaoSchemaException ex)
                {
                    Funcoes.Mensagem(ex.Message, "Erro", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    if (!string.IsNullOrEmpty(ex.Message))
                        Funcoes.Mensagem(ex.Message, "Erro", MessageBoxButton.OK);
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
            ((MainWindow)Application.Current.MainWindow).LeftFlyout.IsOpen = !((MainWindow)Application.Current.MainWindow).LeftFlyout.IsOpen;
            ((MainWindow) Application.Current.MainWindow).LeftFlyout.DataContext = ped;
        }

        #endregion


    }
}
