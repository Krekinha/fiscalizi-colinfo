using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Assinatura
{
    public class Transform
    {
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        ///     XS13 - Atributos válidos Algorithm do Transform:
        ///     <para>http://www.w3.org/TR/2001/REC-xml-c14n-20010315</para>
        ///     <para>http://www.w3.org/2000/09/xmldsig#enveloped-signature</para>
        /// </summary>
        [XmlAttribute]
        public string Algorithm { get; set; }
    }
}