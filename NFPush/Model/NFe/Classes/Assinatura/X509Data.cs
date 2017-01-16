using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Assinatura
{
    public class X509Data
    {
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        ///     XS21 - Certificado Digital X509 em Base64
        /// </summary>
        public string X509Certificate { get; set; }
    }
}