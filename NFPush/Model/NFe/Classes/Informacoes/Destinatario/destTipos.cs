using System.ComponentModel;
using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Destinatario
{
    /// <summary>
    ///     <para>1 – Contribuinte ICMS;</para>
    ///     <para>2 – Contribuinte isento de inscrição;</para>
    ///     <para>9 – Não Contribuinte</para>
    /// </summary>
    public enum indIEDest
    {
        [Description("Contribuinte ICMS")]
        [XmlEnum("1")]
        ContribuinteICMS = 1,

        [Description("Contribuinte isento de inscrição")]
        [XmlEnum("2")]
        Isento = 2,

        [Description("Não Contribuinte")]
        [XmlEnum("9")]
        NaoContribuinte = 9
    }
}