using System;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FiscaliZi.Colinfo.Assets
{
    public class ConfigGeralViewModel : PropertyChangedBase
    {
        private IEventAggregator _events;
        public ConfigGeralViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
            Configuracoes = CarregarConfiguracoes();
        }
        
        #region · Properties ·
        public AppSettings Configuracoes { get; set; }
        #endregion

        private AppSettings CarregarConfiguracoes()
        {
            try
            {
                var config = DFe.Utils.FuncoesXml.ArquivoXmlParaClasse<AppSettings>(@"Config\config.xml");
                return config;
            }
            catch (System.Exception ex)
            {
                Utils.Funcoes.MostrarErro(ex);
                return null;
            }

        }

        public void SalvarConfiguracoes()
        {
            try
            {
                if (Configuracoes == null)
                {
                    var config = new AppSettings();
                    config.CfgServico.Certificado = new DFe.Utils.ConfiguracaoCertificado
                    {
                        Serial = "",
                        ManterDadosEmCache = true
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

                    DFe.Utils.FuncoesXml.ClasseParaArquivoXml(config, @"Config\config.xml");
                    Configuracoes = CarregarConfiguracoes();
                    _events.PublishOnUIThread(new NotifyMessage("Configurações salvas com sucesso", "NOTIFY"));
                }
                else
                {
                    DFe.Utils.FuncoesXml.ClasseParaArquivoXml(Configuracoes, @"Config\config.xml");
                    Configuracoes = CarregarConfiguracoes();
                    _events.PublishOnUIThread(new NotifyMessage("Configurações salvas com sucesso", "NOTIFY"));
                }
            }
            catch (Exception e)
            {
                _events.PublishOnUIThread(new NotifyMessage("Erro ao salvar configurações", "NOTIFY"));
                Console.WriteLine(e);
            }

        }

        public void BuscarCertificado()
        {
            try
            {
                var cert = DFe.Utils.Assinatura.CertificadoDigital.ListareObterDoRepositorio();
                Configuracoes.CfgServico.Certificado.Serial = cert.SerialNumber;
                Configuracoes.Certificado = new CertificadoDados
                {
                    Serial = cert.SerialNumber,
                    Nome = cert.FriendlyName,
                    Validade = cert.NotAfter
                };
            }
            catch (Exception ex)
            {
                _events.PublishOnUIThread(new NotifyMessage("Erro ao configurar certificado", "NOTIFY"));
                Console.WriteLine(ex);
            }

        }
    }
}
