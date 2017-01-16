using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Transporte
{
    public class lacres
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     X34 - Número dos Lacres
        /// </summary>
        public string nLacre { get; set; }
    }
}