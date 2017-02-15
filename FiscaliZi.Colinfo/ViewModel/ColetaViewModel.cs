﻿using System;
using FiscaliZi.Colinfo.Model;
using GalaSoft.MvvmLight;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
using NFe.Utils;
using NFe.Utils.Excecoes;
using retConsCad = FiscaliZi.Colinfo.Model.retConsCad;

namespace FiscaliZi.Colinfo.ViewModel
{
    [ImplementPropertyChanged]
    public class ColetaViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        const string dir_Pedidos = @"..\Pedidos\";

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

            Configuracoes = new ConfiguracaoApp();
            CarregarConfiguracoes();
            InitializeMonitor();

            #region Commands

            RemoverVendedorCommand = new RelayCommand<Vendedor>(RemoverVendedor);
            ConsultaCadastroCommand = new RelayCommand<Cliente>(ConsultaCadastro);

            #endregion
        }

        /*public ColetaViewModel()
        {
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

        }*/

        #region · Properties ·

        #region Commands

        public RelayCommand<Vendedor> RemoverVendedorCommand { get; set; }
        public RelayCommand<Cliente> ConsultaCadastroCommand { get; set; }

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
            MonitorTXTPED();
            Monitors.MonitorGZPTPED(@"D:\SOF\VDWIN\PTPED");
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
        private async void ConsCad(Vendedor vend)
        {
            var erro = false;
            foreach (var ped in vend.Pedidos)
            {
                if (ped.Cliente.Situacao != "CONSULTAR") continue;
                ped.Cliente.RetConsultaCadastro = await Task.Run(() => RetCad(DesmascararCNPJ(ped.Cliente.CNPJ), "MG", out erro));
                ped.Cliente.Situacao = SituacaoCliente(ped.Cliente, erro);
                EditarVendedor(vend);
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
                    var vnd = Coletor.getColeta(e.FullPath, e.Name);
                    dataService.AddVendedor(vnd);
                    Vendedores = dataService.GetVendedores();
                    ConsCad(vnd);
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

        private retConsCad RetCad(string CNPJ, string UF, out bool erro)
        {

            throw new NotImplementedException();
        }

        private void ConsultaCadastro(Cliente cli)
        {
            try
            {
                #region Consulta Cadastro
                try
                {
                    var cert = CertificadoDigital.ListareObterDoRepositorio();
                    Configuracoes.CfgServico.Certificado.Serial = cert.SerialNumber;
                    //TxtValidade.Text = "Validade: " + cert.GetExpirationDateString();
                }
                catch (Exception ex)
                {
                    Funcoes.Mensagem(ex.Message, "ERRO", MessageBoxButton.OK);
                }
                var servicoNFe = new ServicosNFe(Configuracoes.CfgServico);
                var retornoConsulta = servicoNFe.NfeConsultaCadastro("MG", (ConsultaCadastroTipoDocumento)0, cli.IE);
                // TrataRetorno(retornoConsulta);
                CarregarConfiguracoes();

                #endregion
            }
            catch (ComunicacaoException ex)
            {
                // Funcoes.Mensagem(ex.Message, "Erro", MessageBoxButton.OK);
            }
            catch (ValidacaoSchemaException ex)
            {
                // Funcoes.Mensagem(ex.Message, "Erro", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                //if (!string.IsNullOrEmpty(ex.Message))
                //  Funcoes.Mensagem(ex.Message, "Erro", MessageBoxButton.OK);
            }
        }
        private void CarregarConfiguracoes()
        {
            var config = new ConfiguracaoApp();
            config.CfgServico.Certificado.Serial = "29CC1C5B551BABA7";
            config.CfgServico.TimeOut = 00000;
            config.CfgServico.cUF = (Estado) 31;
            config.CfgServico.tpAmb = TipoAmbiente.taProducao;
            config.CfgServico.tpEmis = TipoEmissao.teNormal;
            config.CfgServico.ModeloDocumento = (ModeloDocumento) 55;
            config.CfgServico.VersaoNfeConsultaCadastro = VersaoServico.ve100;
            config.CfgServico.SalvarXmlServicos = false;

            config.Emitente.CNPJ = "21795927000488";
            config.Emitente.CRT = (CRT) 1;

            config.EnderecoEmitente.UF = "MG";

            Configuracoes = config;
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
        void EditarVendedor(Vendedor vnd)
        {
            /*dataService.EditarVendedor(vnd);
            Vendedor = vnd;
            Vendedor.ForcePropertyChanged("Pedidos");
            RaisePropertyChanged("Vendedores");*/

        }

        #endregion


    }
}