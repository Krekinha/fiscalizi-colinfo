using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Assinatura
{
    public class DigestMethod
    {
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        ///     XS16 - Atributo Algorithm de DigestMethod: http://www.w3.org/2000/09/xmldsig#sha1
        /// </summary>
        [XmlAttribute]
        public string Algorithm { get; set; }
    }
}