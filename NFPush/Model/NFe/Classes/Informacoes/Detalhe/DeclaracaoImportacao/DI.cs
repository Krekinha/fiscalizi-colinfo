using System.Collections.Generic;
using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.DeclaracaoImportacao
{
    public class DI
    {
        private decimal? _vAfrmm;

        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     I19 - Número do Documento de Importação (DI, DSI, DIRE, ...)
        /// </summary>
        public string nDI { get; set; }

        /// <summary>
        ///     I20 - Data de Registro do documento. Formato: “AAAA-MM-DD”
        /// </summary>
        public string dDI { get; set; }

        /// <summary>
        ///     I21 - Local de desembaraço
        /// </summary>
        public string xLocDesemb { get; set; }

        /// <summary>
        ///     I22 - Sigla da UF onde ocorreu o Desembaraço Aduaneiro
        /// </summary>
        public string UFDesemb { get; set; }

        /// <summary>
        ///     I23 - Data do Desembaraço Aduaneiro. Formato: “AAAA-MM-DD”
        /// </summary>
        public string dDesemb { get; set; }

        /// <summary>
        ///     I23a - Via de transporte internacional informada na Declaração de Importação (DI)
        /// </summary>
        public TipoTransporteInternacional tpViaTransp { get; set; }

        /// <summary>
        ///     I23b - Valor da AFRMM - Adicional ao Frete para Renovação da Marinha Mercante
        /// </summary>
        public decimal? vAFRMM
        {
            get { return _vAfrmm.Arredondar(2); }
            set { _vAfrmm = value.Arredondar(2); }
        }

        /// <summary>
        ///     I23c - Forma de importação quanto a intermediação
        /// </summary>
        public TipoIntermediacao tpIntermedio { get; set; }

        /// <summary>
        ///     I23d - CNPJ do adquirente ou do encomendante
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        ///     I23e - Sigla da UF do adquirente ou do encomendante
        /// </summary>
        public string UFTerceiro { get; set; }

        /// <summary>
        ///     I24 - Código do Exportador
        /// </summary>
        public string cExportador { get; set; }

        /// <summary>
        ///     I25 - Adições
        /// </summary>
        public List<adi> adi { get; set; }

        public bool ShouldSerializevAFRMM()
        {
            return vAFRMM.HasValue;
        }
    }
}