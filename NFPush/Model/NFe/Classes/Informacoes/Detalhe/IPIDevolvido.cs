using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe
{
    public class IPIDevolvido
    {
        private decimal _vIpiDevol;

        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     UA04 - Valor do IPI devolvido
        /// </summary>
        public decimal vIPIDevol
        {
            get { return _vIpiDevol; }
            set { _vIpiDevol = value.Arredondar(2); }
        }
    }
}