using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Pagamento
{
    public class pag
    {
        private decimal _vPag;

        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     YA02 - Forma de pagamento
        /// </summary>
        public FormaPagamento tPag { get; set; }

        /// <summary>
        ///     YA03 - Valor do Pagamento
        /// </summary>
        public decimal vPag
        {
            get { return _vPag; }
            set { _vPag = value.Arredondar(2); }
        }

        /// <summary>
        ///     YA04 - Grupo de Cartões
        /// </summary>
        public card card { get; set; }
    }
}