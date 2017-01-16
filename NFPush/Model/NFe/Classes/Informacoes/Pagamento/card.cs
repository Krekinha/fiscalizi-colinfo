using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Pagamento
{
    public class card
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     YA04a - Tipo de Integração para pagamento
        /// </summary>
        public TipoIntegracaoPagamento? tpIntegra { get; set; }

        public bool ShouldSerializetpIntegra()
        {
            return tpIntegra.HasValue;
        }

        /// <summary>
        ///     YA05 - CNPJ da Credenciadora de cartão de crédito e/ou débito
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        ///     YA06 - Bandeira da operadora de cartão de crédito e/ou débito
        /// </summary>
        public BandeiraCartao? tBand { get; set; }

        public bool ShouldSerializetBand()
        {
            return tBand.HasValue;
        }

        /// <summary>
        ///     YA07 - Número de autorização da operação cartão de crédito e/ou débito
        /// </summary>
        public string cAut { get; set; }
    }
}