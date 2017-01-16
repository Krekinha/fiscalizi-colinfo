namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Produto_Específico
{
    public class comb : ProdutoEspecifico
    {
        private decimal? _pMixGn;
        private decimal? _qTemp;

        /// <summary>
        ///     LA02 - Código de produto da ANP
        /// </summary>
        public string cProdANP { get; set; }

        /// <summary>
        ///     LA03 - Percentual de Gás Natural para o produto GLP (cProdANP=210203001)
        /// </summary>
        public decimal? pMixGN
        {
            get { return _pMixGn.Arredondar(4); }
            set { _pMixGn = value.Arredondar(4); }
        }

        /// <summary>
        ///     LA04 - Código de autorização / registro do CODIF
        /// </summary>
        public string CODIF { get; set; }

        /// <summary>
        ///     LA05 - Quantidade de combustível faturada à temperatura ambiente
        /// </summary>
        public decimal? qTemp
        {
            get { return _qTemp.Arredondar(4); }
            set { _qTemp = value.Arredondar(4); }
        }

        /// <summary>
        ///     LA06 - Sigla da UF de consumo
        /// </summary>
        public string UFCons { get; set; }

        /// <summary>
        ///     LA07 - Informações da CIDE
        /// </summary>
        public CIDE CIDE { get; set; }

        /// <summary>
        /// LA11 - Informações do grupo de “encerrante”
        /// </summary>
        public encerrante encerrante { get; set; }

        public bool ShouldSerializepMixGN()
        {
            return pMixGN.HasValue;
        }

        public bool ShouldSerializeqTemp()
        {
            return qTemp.HasValue;
        }
    }
}