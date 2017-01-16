using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Assinatura
{
    public class SignatureMethod
    {
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        ///     XS06 - Atributo Algorithm de SignatureMethod: http://www.w3.org/2000/09/xmldsig#rsa-sha1
        /// </summary>
        [XmlAttribute]
        public string Algorithm { get; set; }
    }
}