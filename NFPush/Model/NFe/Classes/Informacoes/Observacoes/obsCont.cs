using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Observacoes
{
    public class obsCont
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     Z05 - Identificação do campo
        /// </summary>
        public string xCampo { get; set; }

        /// <summary>
        ///     Z06 - Conteúdo do campo
        /// </summary>
        public string xTexto { get; set; }
    }
}