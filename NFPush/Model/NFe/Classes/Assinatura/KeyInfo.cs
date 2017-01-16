using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Assinatura
{
    public class KeyInfo
    {
        [XmlIgnore]
        public int ID { get; set; }
        public KeyInfo()
        {
            X509Data = new X509Data();
        }

        /// <summary>
        ///     XS20 - Grupo X509
        /// </summary>
        public X509Data X509Data { get; set; }
    }
}