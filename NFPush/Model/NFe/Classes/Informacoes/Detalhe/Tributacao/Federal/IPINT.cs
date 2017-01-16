using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal
{
    public class IPINT : IPIBasico
    {
        /// <summary>
        ///     O09 - Código da Situação Tributária do IPI:
        /// </summary>
        public CSTIPI CST { get; set; }
    }
}