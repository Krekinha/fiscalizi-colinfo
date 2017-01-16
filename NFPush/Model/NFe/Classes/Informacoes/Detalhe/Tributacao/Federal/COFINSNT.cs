using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal
{
    public class COFINSNT : COFINSBasico
    {
        /// <summary>
        ///     S06 - Código de Situação Tributária da COFINS
        /// </summary>
        public CSTCOFINS CST { get; set; }
    }
}