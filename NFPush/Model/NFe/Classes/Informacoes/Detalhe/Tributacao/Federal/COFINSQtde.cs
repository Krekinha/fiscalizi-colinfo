using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal
{
    public class COFINSQtde : COFINSBasico
    {
        private decimal _qBcProd;
        private decimal _vAliqProd;
        private decimal _vCofins;

        /// <summary>
        ///     S06 - Código de Situação Tributária da COFINS
        /// </summary>
        public CSTCOFINS CST { get; set; }

        /// <summary>
        ///     S09 - Quantidade Vendida
        /// </summary>
        public decimal qBCProd
        {
            get { return _qBcProd; }
            set { _qBcProd = value.Arredondar(4); }
        }

        /// <summary>
        ///     S10 - Alíquota da COFINS (em reais)
        /// </summary>
        public decimal vAliqProd
        {
            get { return _vAliqProd; }
            set { _vAliqProd = value.Arredondar(4); }
        }

        /// <summary>
        ///     S11 - Valor da COFINS
        /// </summary>
        public decimal vCOFINS
        {
            get { return _vCofins; }
            set { _vCofins = value.Arredondar(2); }
        }
    }
}