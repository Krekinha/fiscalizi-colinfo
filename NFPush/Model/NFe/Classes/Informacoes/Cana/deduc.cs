using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Cana
{
    public class deduc
    {
        private decimal _vDed;
        private decimal _vFor;
        private decimal _vTotDed;
        private decimal _vLiqFor;

        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     ZC11 - Descrição da Dedução
        /// </summary>
        public string xDed { get; set; }

        /// <summary>
        ///     ZC12 - Valor da Dedução
        /// </summary>
        public decimal vDed
        {
            get { return _vDed; }
            set { _vDed = value.Arredondar(2); }
        }

        /// <summary>
        ///     ZC13 - Valor dos Fornecimentos
        /// </summary>
        public decimal vFor
        {
            get { return _vFor; }
            set { _vFor = value.Arredondar(2); }
        }

        /// <summary>
        ///     ZC14 - Valor Total da Dedução
        /// </summary>
        public decimal vTotDed
        {
            get { return _vTotDed; }
            set { _vTotDed = value.Arredondar(2); }
        }

        /// <summary>
        ///     ZC15 - Valor Líquido dos Fornecimentos
        /// </summary>
        public decimal vLiqFor
        {
            get { return _vLiqFor; }
            set { _vLiqFor = value.Arredondar(2); }
        }
    }
}