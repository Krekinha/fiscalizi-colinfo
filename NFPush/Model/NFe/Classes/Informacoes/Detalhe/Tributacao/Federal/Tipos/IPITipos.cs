using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos
{
    /// <summary>
    ///     <para>00-Entrada com recuperação de crédito</para>
    ///     <para>49 - Outras entradas</para>
    ///     <para>50-Saída tributada</para>
    ///     <para>99-Outras saídas</para>
    ///     <para>01-Entrada tributada com alíquota zero</para>
    ///     <para>02-Entrada isenta</para>
    ///     <para>03-Entrada não-tributada</para>
    ///     <para>04-Entrada imune</para>
    ///     <para>05-Entrada com suspensão</para>
    ///     <para>51-Saída tributada com alíquota zero</para>
    ///     <para>52-Saída isenta</para>
    ///     <para>53-Saída não-tributada</para>
    ///     <para>54-Saída imune</para>
    ///     <para>55-Saída com suspensão</para>
    /// </summary>
    public enum CSTIPI
    {
        [XmlEnum("00")] ipi00,
        [XmlEnum("49")] ipi49,
        [XmlEnum("50")] ipi50,
        [XmlEnum("99")] ipi99,
        [XmlEnum("01")] ipi01,
        [XmlEnum("02")] ipi02,
        [XmlEnum("03")] ipi03,
        [XmlEnum("04")] ipi04,
        [XmlEnum("05")] ipi05,
        [XmlEnum("51")] ipi51,
        [XmlEnum("52")] ipi52,
        [XmlEnum("53")] ipi53,
        [XmlEnum("54")] ipi54,
        [XmlEnum("55")] ipi55
    }
}