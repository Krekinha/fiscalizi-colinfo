using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Observacoes
{
    public class procRef
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     Z11 - Identificador do processo ou ato concessório
        /// </summary>
        public string nProc { get; set; }

        /// <summary>
        ///     Z12 - Indicador da origem do processo
        /// </summary>
        public IndicadorProcesso indProc { get; set; }
    }
}