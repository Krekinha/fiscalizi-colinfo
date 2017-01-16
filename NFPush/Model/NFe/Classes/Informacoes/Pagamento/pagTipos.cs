using System.ComponentModel;
using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Pagamento
{
    /// <summary>
    ///     <para>01=Dinheiro</para>
    ///     <para>02=Cheque</para>
    ///     <para>03=Cartão de Crédito</para>
    ///     <para>04=Cartão de Débito</para>
    ///     <para>05=Crédito Loja</para>
    ///     <para>10=Vale Alimentação</para>
    ///     <para>11=Vale Refeição</para>
    ///     <para>12=Vale Presente</para>
    ///     <para>13=Vale Combustível</para>
    ///     <para>99=Outros</para>
    /// </summary>
    public enum FormaPagamento
    {
        [Description("Dinheiro")] [XmlEnum("01")] fpDinheiro,

        [Description("Cheque")] [XmlEnum("02")] fpCheque,

        [Description("Cartão de Crédito")] [XmlEnum("03")] fpCartaoCredito,

        [Description("Cartão de Débito")] [XmlEnum("04")] fpCartaoDebito,

        [Description("Crédito Loja")] [XmlEnum("05")] fpCreditoLoja,

        [Description("Vale Alimentação")] [XmlEnum("10")] fpValeAlimentacao,

        [Description("Vale Refeição")] [XmlEnum("11")] fpValeRefeicao,

        [Description("Vale Presente")] [XmlEnum("12")] fpValePresente,

        [Description("Vale Combustível")] [XmlEnum("13")] fpValeCombustivel,

        [Description("Outros")] [XmlEnum("99")] fpOutro
    }

    /// <summary>
    ///     <para>01=Visa</para>
    ///     <para>02=Mastercard</para>
    ///     <para>03=American Express</para>
    ///     <para>04=Sorocred</para>
    ///     <para>99=Outros</para>
    /// </summary>
    public enum BandeiraCartao
    {
        [Description("Visa")] [XmlEnum("01")] bcVisa,

        [Description("Mastercard")] [XmlEnum("02")] bcMasterCard,

        [Description("American Express")] [XmlEnum("03")] bcAmericanExpress,

        [Description("Sorocred")] [XmlEnum("04")] bcSorocred,

        [Description("Outros")] [XmlEnum("99")] bcOutros
    }

    /// <summary>
    ///     <para>1=Pagamento integrado com o sistema de automação da empresa(Ex.: equipamento TEF, Comércio Eletrônico);</para>
    ///     <para>Pagamento não integrado com o sistema de automação da empresa(Ex.: equipamento POS);</para>
    /// </summary>
    public enum TipoIntegracaoPagamento
    {
        [XmlEnum("1")]
        TipIntegradoAutomacao = 1,

        [XmlEnum("2")]
        TipNaoIntegrado = 2
    }
}