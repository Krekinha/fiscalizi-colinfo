using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Cobranca
{
    public class dup
    {
        private decimal _vDup;

        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     Y08 - Número da Duplicata
        /// </summary>
        public string nDup { get; set; }

        /// <summary>
        ///     Y09 - Data de vencimento
        /// </summary>
        public string dVenc { get; set; }

        /// <summary>
        ///     Y10 - Valor da duplicata
        /// </summary>
        public decimal vDup
        {
            get { return _vDup; }
            set { _vDup = value.Arredondar(2); }
        }
    }
}