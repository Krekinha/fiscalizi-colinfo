using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Total
{
    /// <summary>
    ///     <para>1=Microempresa Municipal;</para>
    ///     <para>2=Estimativa;</para>
    ///     <para>3=Sociedade de Profissionais;</para>
    ///     <para>4=Cooperativa;</para>
    ///     <para>5=Microempresário Individual (MEI);</para>
    ///     <para>6=Microempresário e Empresa de Pequeno Porte (ME/EPP)</para>
    /// </summary>
    public enum RegTribISSQN
    {
        [XmlEnum("1")] TISSMicroempresaMunicipal,

        [XmlEnum("2")] RTISSEstimativa,

        [XmlEnum("3")] RTISSSociedadeProfissionais,

        [XmlEnum("4")] RTISSCooperativa,

        [XmlEnum("5")] RTISSMEI,

        [XmlEnum("6")] RTISSMEEPP
    }
}