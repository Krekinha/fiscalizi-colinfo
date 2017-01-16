using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Identificacao
{
    public class NFref
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     BA02 - Chave de acesso da NF-e referenciada
        /// </summary>
        public string refNFe { get; set; }

        /// <summary>
        ///     BA03 - Informação da NF modelo 1/1A referenciada
        /// </summary>
        public refNF refNF { get; set; }

        /// <summary>
        ///     BA10 - Informações da NF de produtor rural referenciada
        /// </summary>
        public refNFP refNFP { get; set; }

        /// <summary>
        ///     BA20 - Informações do Cupom Fiscal referenciado
        /// </summary>
        public refECF refECF { get; set; }
    }
}