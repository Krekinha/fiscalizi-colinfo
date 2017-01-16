using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Cana
{
    public class forDia
    {
        private decimal _qtde;
        private decimal _qTotMes;
        private decimal _qTotAnt;
        private decimal _qTotGer;

        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     ZC05 - Dia
        /// </summary>
        [XmlAttribute]
        public int dia { get; set; }

        /// <summary>
        ///     ZC06 - Quantidade
        /// </summary>
        public decimal qtde
        {
            get { return _qtde; }
            set { _qtde = value.Arredondar(10); }
        }

        /// <summary>
        ///     ZC07 - Quantidade Total do Mês
        /// </summary>
        public decimal qTotMes
        {
            get { return _qTotMes; }
            set { _qTotMes = value.Arredondar(10); }
        }

        /// <summary>
        ///     ZC08 - Quantidade Total Anterior
        /// </summary>
        public decimal qTotAnt
        {
            get { return _qTotAnt; }
            set { _qTotAnt = value.Arredondar(10); }
        }

        /// <summary>
        ///     ZC09 - Quantidade Total Geral
        /// </summary>
        public decimal qTotGer
        {
            get { return _qTotGer; }
            set { _qTotGer = value.Arredondar(10); }
        }
    }
}