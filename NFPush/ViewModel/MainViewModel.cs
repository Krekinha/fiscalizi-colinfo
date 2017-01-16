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

namespace NFPush.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;

            CarregarConfiguracao();
        }

        #region · Propriedades ·

        private const string ArquivoConfiguracao = @"..\..\Utils\configuracao.xml";
        private readonly IDataService _dataService;
        private ConfiguracaoApp _configuracoes;


        #endregion

        #region Construtores

        public ConfiguracaoApp Configuracoes
        {
            get { return _configuracoes; }
            set
            {
                Set(() => Configuracoes, ref _configuracoes, value);
            }
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
                    Configuracoes.CfgServico.TimeOut = 9000; //mínimo
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.Message))
                    Funcoes.Mensagem(ex.Message, "Erro", MessageBoxButton.OK);
            }
        }

        #endregion
    }
}