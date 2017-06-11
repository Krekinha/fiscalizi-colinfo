using System.Collections.ObjectModel;
using Caliburn.Micro;
using DFe.Utils;
using FiscaliZi.MDFast.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using NFe.Classes.Servicos.DistribuicaoDFe.Schemas;

namespace FiscaliZi.MDFast.Assets
{
    public class EntradaViewModel : PropertyChangedBase
    {
        public EntradaViewModel(IEventAggregator events)
        {
            _events = events;
            NFs = new ObservableCollection<nfeProc>();
            AddNFSCommand = new RelayCommand(AddNFS);
            TestCommand = new RelayCommand(Teste);
        }

        #region · Propriedades ·

        private const string ArquivoConfiguracao = @"..\..\Utils\configuracao.xml";
        private readonly IDataService _dataService;
        private IEventAggregator _events;

        public RelayCommand AddNFSCommand { get; set; }
        public RelayCommand TestCommand { get; set; }

        public ObservableCollection<nfeProc> NFs { get; set; }

        #endregion

        #region · Metodos ·
        private void AddNFS()
        {
            OpenFileDialog opd = new OpenFileDialog
            {
                DefaultExt = ".xml",                   // Padrão .xml
                Filter = "XML Arquivo (*.xml)|*.xml", // Somente XML
                Multiselect = true                  // vários arquivos
            };

            bool? result = opd.ShowDialog();

            if (result == true)
            {
                foreach (var file in opd.FileNames)
                {
                    var nf = FuncoesXml.ArquivoXmlParaClasse<nfeProc>(file);
                    NFs.Add(nf);
                }
            }
        }
        private void Teste()
        {
            _dataService.AdicionarVeiculo(new Veiculo { Placa = "XXX1234", Tara = 15000, CapKG = 66000, TPRod = "03", TPCar = "10", UF = "SP" });
        }

        #endregion

    }
}