using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Observacoes
{
    public class obsFisco
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     Z08 - Identificação do campo
        /// </summary>
        public string xCampo { get; set; }

        /// <summary>
        ///     Z09 - Conteúdo do campo
        /// </summary>
        public string xTexto { get; set; }
    }
}