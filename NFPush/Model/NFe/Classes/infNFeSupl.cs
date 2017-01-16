using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes
{
    public class infNFeSupl
    {
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        /// ZX02 - Texto com o QR-Code impresso no DANFE NFC-e
        /// </summary>
        public string qrCode { get; set; }
    }
}