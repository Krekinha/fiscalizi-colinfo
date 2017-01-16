using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Observacoes
{
    /// <summary>
    ///     <para>0=SEFAZ;</para>
    ///     <para>1=Justiça Federal;</para>
    ///     <para>2=Justiça Estadual;</para>
    ///     <para>3=Secex/RFB;</para>
    ///     <para>9=Outros</para>
    /// </summary>
    public enum IndicadorProcesso
    {
        [XmlEnum("0")] ipSEFAZ,
        [XmlEnum("1")] ipJusticaFederal,
        [XmlEnum("2")] ipJusticaEstadual,
        [XmlEnum("3")] ipSecexRFB,
        [XmlEnum("9")] ipOutros
    }
}