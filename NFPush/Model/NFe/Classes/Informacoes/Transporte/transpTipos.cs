using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Transporte
{
    /// <summary>
    ///     <para>0=Por conta do emitente;</para>
    ///     <para>1=Por conta do destinatário/remetente;</para>
    ///     <para>2=Por conta de terceiros;</para>
    ///     <para>9=Sem frete. (V2.0)</para>
    /// </summary>
    public enum ModalidadeFrete
    {
        [XmlEnum("0")] mfContaEmitente,
        [XmlEnum("1")] mfContaDestinatario,
        [XmlEnum("2")] mfContaTerceiros,
        [XmlEnum("9")] mfSemFrete
    }
}