using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NFPush.Model;
using NFPush.Model.NFe.Classes;
using System.Collections.ObjectModel;
using System;
using NFe.Servicos;
using NFe.Servicos.Retorno;
using NFPush.Utils;
using System.Windows;
using System.IO;
using System.Reflection;
using NFe.Classes.Servicos.DistribuicaoDFe;
using NFe.Utils.DistribuicaoDFe;
using NFe.Utils;
using NFe.Classes.Servicos.DistribuicaoDFe.Schemas;
using System.Text;
using NFe.Classes.Servicos.Tipos;
using System.Collections.Generic;
using System.Linq;

namespace NFPush.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class PushViewModel : ViewModelBase
    {
        public PushViewModel(IDataService dataService)
        {
            _dataService = dataService;

            ListarNFSDestCommand = new RelayCommand<string>((s) => ListarNFSDest("0"));
            ListarOfflineCommand = new RelayCommand(ListarOffline);
            TestCommand = new RelayCommand<ObservableCollection<DFeObj>>(Teste);
            //ListarNFSDestCommand = new RelayCommand<string>(ListarNFSDest);
            SalvarNFeCommand = new RelayCommand(SalvarNFe);
            DFs = new ObservableCollection<DFeObj>();
            RetornoBasico = new retDistDFeInt();
            CarregarConfiguracao();
        }

        #region · Propriedades ·

        private const string ArquivoConfiguracao = @"..\..\Utils\configuracao.xml";
        private readonly IDataService _dataService;
        private ObservableCollection<DFeObj> _dfs;
        private retDistDFeInt _retornoBasico;
        private ConfiguracaoApp _configuracoes;

        public RelayCommand<string> ListarNFSDestCommand { get; set; }
        public RelayCommand ListarOfflineCommand { get; set; }
        public RelayCommand SalvarNFeCommand { get; set; }
        public RelayCommand<ObservableCollection<DFeObj>> TestCommand { get; set; }

        public ObservableCollection<DFeObj> DFs
        {
            get { return _dfs; }
            set
            {
                Set(() => DFs, ref _dfs, value);
            }
        }

        #endregion

        #region Construtores
        private void SalvarNFe()
        {
            var procNFS = new List<Model.NFe.Classes.nfeProc>();
            foreach (var item in DFs)
            {
                if (item.schema.Contains("procNFe"))
                {
                    try
                    {
                        var dfe = new DFe
                        {
                            NSU = item.NSU,
                            schema = item.schema,
                            xmlDFe = item.xmlNFe
                        };
                        _dataService.SalvaDFe(dfe);
                    }
                    catch (Exception ex)
                    {
                        var msg = "";
                        if (!string.IsNullOrEmpty(ex.Message))
                        {
                            if (ex.InnerException != null)
                                msg = ex.InnerException.Message;
                            else
                                msg = ex.Message;
                            Funcoes.Mensagem(msg, "Erro", MessageBoxButton.OK);
                        }
                    }
                }
            }
        }
        public retDistDFeInt RetornoBasico
        {
            get { return _retornoBasico; }
            set
            {
                Set(() => RetornoBasico, ref _retornoBasico, value);
            }
        }
        public ConfiguracaoApp Configuracoes
        {
            get { return _configuracoes; }
            set
            {
                Set(() => Configuracoes, ref _configuracoes, value);
            }
        }
        private void ListarNFSDest(string nsu = "0")
        {
            ushort ultNSU, maxNSU;
            try
            {
                #region NFeDistribuicaoDFe

                var cnpj = "21795927000488";
                if (string.IsNullOrEmpty(cnpj)) throw new Exception("O CNPJ deve ser informado!");
                if (cnpj.Length != 14) throw new Exception("O CNPJ deve conter 14 caracteres!");
                if (string.IsNullOrEmpty(nsu)) throw new Exception("NSU deve ser informado!");
                if (int.Parse(nsu) < 0) throw new Exception("NSU deve ser maior ou igual a 0");

                var servicoNFe = new ServicosNFe(_configuracoes.CfgServico);
                var retornoNFeDistDFe = servicoNFe.NfeDistDFeInteresse(_configuracoes.EnderecoEmitente.UF, cnpj, nsu);
                ultNSU = retornoNFeDistDFe.Retorno.ultNSU;
                maxNSU = retornoNFeDistDFe.Retorno.maxNSU;

                TrataRetorno(retornoNFeDistDFe);

                //Todos DFe dos ultimos 90 dias
                while (ultNSU != maxNSU)
                {
                    var reDFs = servicoNFe.NfeDistDFeInteresse(_configuracoes.EnderecoEmitente.UF, cnpj, ultNSU.ToString());
                    TrataRetorno(reDFs);
                    ultNSU = reDFs.Retorno.ultNSU;
                    maxNSU = reDFs.Retorno.maxNSU;
                }
                

                #endregion
            }
            catch (Exception ex)
            {
                var msg = "";
                if (!string.IsNullOrEmpty(ex.Message))
                {
                    if (ex.InnerException != null)
                        msg = ex.InnerException.Message;
                    else
                        msg = ex.Message;
                    Funcoes.Mensagem(msg, "Erro", MessageBoxButton.OK);
                }

            }
        }
        private void TrataRetorno(RetornoNfeDistDFeInt retornoBasico)
        {
            SalvarArquivoXml($"dfs_{retornoBasico.Retorno.loteDistDFeInt[0].NSU}-{retornoBasico.Retorno.ultNSU}--{retornoBasico.Retorno.loteDistDFeInt.Count()}.xml", retornoBasico.RetornoStr);
            RetornoBasico = retornoBasico.Retorno;
            TratarDFe(retornoBasico);
        }
        private void CarregarConfiguracao()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                Configuracoes = !File.Exists(ArquivoConfiguracao)
                    ? new ConfiguracaoApp()
                    : FuncoesXml.ArquivoXmlParaClasse<ConfiguracaoApp>(ArquivoConfiguracao);
                if (Configuracoes.CfgServico.TimeOut == 0)
                    Configuracoes.CfgServico.TimeOut = 90000; //mínimo
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                    Funcoes.Mensagem(ex.Message, "Erro", MessageBoxButton.OK);
            }
        }
        private void TratarDFe(RetornoNfeDistDFeInt retornoDistDFe)
        {
            var lotes = retornoDistDFe.Retorno.loteDistDFeInt;

            for (int i = 0; i < lotes.Length; i++)
            {

                string conteudo = Compressao.Unzip(lotes[i].XmlNfe);

                if (lotes[i].schema.Contains("procNFe"))
                {
                    //SalvarArquivoXml($"nfeProc_NUM_{lotes[i].NSU}.xml", conteudo);
                    DFs.Add(
                        new DFeObj
                        {
                            NSU = lotes[i].NSU,
                            schema = lotes[i].schema,
                            xmlNFe = conteudo,
                            nfeObj = FuncoesXml.XmlStringParaClasse<Model.NFe.Classes.nfeProc>(conteudo)
                        });
                }
                else if (lotes[i].schema.Contains("resNFe"))
                {
                    var resNF = FuncoesXml.XmlStringParaClasse<resNFe>(conteudo);
                    Model.NFe.Classes.nfeProc nfProc = new Model.NFe.Classes.nfeProc
                    {
                        NFe = new NFeObj
                        {
                            infNFe = new Model.NFe.Classes.Informacoes.infNFe
                            {
                                emit = new Model.NFe.Classes.Informacoes.Emitente.emit
                                {
                                    xNome = resNF.xNome,
                                    CNPJ = resNF.CNPJ.ToString()
                                },
                                ide = new Model.NFe.Classes.Informacoes.Identificacao.ide
                                {
                                    dhEmi = resNF.dhEmi
                                },
                                total = new Model.NFe.Classes.Informacoes.Total.total
                                {
                                    ICMSTot = new Model.NFe.Classes.Informacoes.Total.ICMSTot
                                    {
                                        vNF = resNF.vNF
                                    }
                                }
                            }
                        },
                        protNFe = new Model.NFe.Classes.Protocolo.protNFe
                        {
                            infProt = new Model.NFe.Classes.Protocolo.infProt
                            {
                                dhRecbto = resNF.dhRecbto,
                                chNFe = resNF.chNFe

                            }
                        }
                    };
                    DFs.Add(
                        new DFeObj
                        {
                            NSU = lotes[i].NSU,
                            schema = lotes[i].schema,
                            xmlNFe = conteudo,
                            nfeObj = nfProc
                        });
                }
            }
        }
        private void SalvarArquivoXml(string nomeArquivo, string xmlString)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var stw = new StreamWriter(Path.Combine(desktop + @"\zeusxml\" + nomeArquivo));
            stw.WriteLine(xmlString);
            stw.Close();
        }
        private void ListarOffline()
        {         
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string[] files = Directory.GetFiles(Path.Combine(desktop + @"\zeusxml\"));

            var rms = new List<resNFe>();
            var nfs = new List<Model.NFe.Classes.nfeProc>();
            var evs = new List<procEventoNFe>();
            var dfs = new List<DFeObj>();

            #region Loop conteudo
            foreach (var file in files)
            {
                var retorno = FuncoesXml.ArquivoXmlParaClasse<retDistDFeInt>(file);
                var lotes = retorno.loteDistDFeInt;

                for (int i = 0; i < lotes.Length; i++)
                {

                    string conteudo = Compressao.Unzip(lotes[i].XmlNfe);

                    if (lotes[i].schema.Contains("resNFe"))
                    {
                        try
                        {
                            rms.Add(FuncoesXml.XmlStringParaClasse<resNFe>(conteudo));
                        }
                        catch (Exception ex)
                        {
                            Funcoes.MostrarErro(ex);
                        }                     
                        #region ignorar
                        /*DFs.Add(
                            new DFeObj
                            {
                                NSUnfe = lotes[i].NSU,
                                schema = lotes[i].schema,
                                xmlNFe = conteudo,
                                nfeObj = FuncoesXml.XmlStringParaClasse<Model.NFe.Classes.nfeProc>(conteudo)

                            });*/
                        #endregion
                    }
                    else if (lotes[i].schema.Contains("procNFe"))
                    {
                        try
                        {
                            nfs.Add(FuncoesXml.XmlStringParaClasse<Model.NFe.Classes.nfeProc>(conteudo));
                        }
                        catch (Exception ex)
                        {
                            Funcoes.MostrarErro(ex);
                        }

                        #region ignorar
                        /*var resNF = FuncoesXml.XmlStringParaClasse<resNFe>(conteudo);
                        Model.NFe.Classes.nfeProc nfProc = new Model.NFe.Classes.nfeProc
                        {
                            NFe = new NFeObj
                            {
                                infNFe = new Model.NFe.Classes.Informacoes.infNFe
                                {
                                    emit = new Model.NFe.Classes.Informacoes.Emitente.emit
                                    {
                                        xNome = resNF.xNome,
                                        CNPJ = resNF.CNPJ.ToString()
                                    },
                                    ide = new Model.NFe.Classes.Informacoes.Identificacao.ide
                                    {
                                        dhEmi = $"{DateTime.SpecifyKind(resNF.dhEmi, DateTimeKind.Utc):dd/MM/yyyy HH:mm:ss}"
                                    },
                                    total = new Model.NFe.Classes.Informacoes.Total.total
                                    {
                                        ICMSTot = new Model.NFe.Classes.Informacoes.Total.ICMSTot
                                        {
                                            vNF = resNF.vNF
                                        }
                                    }
                                }
                            },
                            protNFe = new Model.NFe.Classes.Protocolo.protNFe
                            {
                                infProt = new Model.NFe.Classes.Protocolo.infProt
                                {
                                    dhRecbto = resNF.dhRecbto,
                                    chNFe = resNF.chNFe

                                }
                            }
                        };
                        DFs.Add(
                            new DFeObj
                            {
                                NSUnfe = lotes[i].NSU,
                                schema = lotes[i].schema,
                                xmlNFe = conteudo,
                                nfeObj = nfProc
                            });*/
                        #endregion
                    }
                    else if (lotes[i].schema.Contains("procEventoNFe"))
                    {
                        try
                        {
                            evs.Add(FuncoesXml.XmlStringParaClasse<procEventoNFe>(conteudo));
                        }
                        catch (Exception ex)
                        {
                            Funcoes.MostrarErro(ex);
                        }
                    }


                }               
            }
            #endregion

            foreach (var res in rms)
            {
                var _dfe = new DFeObj();
                _dfe.resObj = res;
                _dfe.nfeObj = nfs.Find(x => x.protNFe.infProt.chNFe == res.chNFe);
                _dfe.eventoNFe = evs.Find(ev => ev.retEvento.infEvento.chNFe == res.chNFe);
                dfs.Add(_dfe);
            }

            foreach (var item in dfs)
            {
                DFs.Add(item);
            }
            
        }
        private void Teste(ObservableCollection<DFeObj> dfs)
        {
            var repets = dfs.Sum(x => x.resObj.vNF);
            Funcoes.Mensagem(repets.ToString(), "Aviso", MessageBoxButton.OK);
        }
        #endregion
    }
}