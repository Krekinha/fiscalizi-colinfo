using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Municipal
{
    /// <summary>
    ///     <para>1=Sim;</para>
    ///     <para>2=Não;</para>
    /// </summary>
    public enum indIncentivo
    {
        [XmlEnum("1")] iiSim,
        [XmlEnum("2")] iiNao
    }

    /// <summary>
    ///     1=Exigível, 2=Não incidência; 3=Isenção; 4=Exportação; 5=Imunidade; 6=Exigibilidade Suspensa por Decisão Judicial; 7=Exigibilidade Suspensa por Processo Administrativo;
    /// </summary>
    public enum IndicadorISS
    {
        [XmlEnum("1")] iiExigivel,
        [XmlEnum("2")] iiNaoIncidencia,
        [XmlEnum("3")] iiIsencao,
        [XmlEnum("4")] iiExportacao,
        [XmlEnum("5")] iiImunidade,
        [XmlEnum("6")] iiExigSuspDecisaoJudicial,
        [XmlEnum("7")] iiExigSuspProcessoAdm
    }
}