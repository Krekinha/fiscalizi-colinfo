using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Assinatura
{
    [XmlRoot(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public class Signature
    {
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        ///     XS02 - Grupo da Informação da assinatura
        /// </summary>
        public SignedInfo SignedInfo { get; set; }

        /// <summary>
        ///     XS18 - Grupo do Signature Value
        /// </summary>
        public string SignatureValue { get; set; }

        /// <summary>
        ///     XS19 - Grupo do KeyInfo
        /// </summary>
        public KeyInfo KeyInfo { get; set; }
    }
}