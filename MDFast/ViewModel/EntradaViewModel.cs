using GalaSoft.MvvmLight;
using MDFast.Model;
using System.Collections.ObjectModel;
using NFe.Utils;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using Microsoft.Win32;
using NFe.Classes;
using MDFast.Validation;

namespace MDFast.ViewModel
{
    public class EntradaViewModel : ViewModelBase
    {
        public EntradaViewModel(IDataService dataService)
        {
            _dataService = dataService;
            NFs = new ObservableCollection<nfeProc>();
            AddNFSCommand = new RelayCommand(AddNFS);
            TestCommand = new RelayCommand(Teste);
        }

        #region · Propriedades ·

        private const string ArquivoConfiguracao = @"..\..\Utils\configuracao.xml";
        private readonly IDataService _dataService;

        public RelayCommand AddNFSCommand { get; set; }
        public RelayCommand TestCommand { get; set; }

        private ObservableCollection<nfeProc> _nfs;
        public ObservableCollection<nfeProc> NFs
        {
            get
            {
                return _nfs;
            }

            set
            {
                Set(() => NFs, ref _nfs, value);
            }
        }

        #endregion

        #region · Construtores ·
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
                    RaisePropertyChanged("NFS");
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