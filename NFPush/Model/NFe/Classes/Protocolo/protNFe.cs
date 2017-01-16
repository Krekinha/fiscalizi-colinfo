using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Protocolo
{
    public class protNFe
    {
        public protNFe()
        {
            infProt = new infProt();
        }

        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     PR02 - Versão do leiaute das informações de Protocolo.
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     PR03 - Informações do Protocolo de resposta. TAG a ser assinada
        /// </summary>
        public infProt infProt { get; set; }
    }
}