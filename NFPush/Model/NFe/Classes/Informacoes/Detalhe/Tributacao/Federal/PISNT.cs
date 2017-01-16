using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal
{
    public class PISNT : PISBasico
    {
        /// <summary>
        ///     Q06 - Código de Situação Tributária do PIS
        /// </summary>
        public CSTPIS CST { get; set; }
    }
}