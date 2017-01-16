using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Exportacao
{
    public class detExport
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     I51 - Número do ato concessório de Drawback
        /// </summary>
        public string nDraw { get; set; }

        /// <summary>
        ///     I52 - Grupo sobre exportação indireta
        /// </summary>
        public exportInd exportInd { get; set; }
    }
}