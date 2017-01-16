using System.Xml.Serialization;
using NFPush.Model.NFe.Classes.Informacoes;
using NFPush.Model.NFe.Classes.Assinatura;
using System.Xml.Schema;

namespace NFPush.Model.NFe.Classes
{
    [XmlRoot("NFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class NFeObj
    {
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        ///     A01 - Informações da Nota Fiscal Eletrônica
        /// </summary>
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public infNFe infNFe { get; set; }

        /// <summary>
        /// ZX01 - Informações suplementares da Nota Fiscal
        /// </summary>
        [XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public infNFeSupl infNFeSupl { get; set; }

        /// <summary>
        ///     XS01
        /// </summary>
        [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }

    }
}