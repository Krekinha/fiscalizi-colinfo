namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Produto_Específico
{
    public class med : ProdutoEspecifico
    {
        private decimal _qLote;
        private decimal _vPmc;

        /// <summary>
        ///     K02 - Número do Lote de medicamentos ou de matérias-primas farmacêuticas
        /// </summary>
        public string nLote { get; set; }

        /// <summary>
        ///     K03 - Quantidade de produto no Lote de medicamentos ou de matérias-primas farmacêuticas
        /// </summary>
        public decimal qLote
        {
            get { return _qLote; }
            set { _qLote = value.Arredondar(3); }
        }

        /// <summary>
        ///     K04 - Data de fabricação. Formato: “AAAA-MM-DD”
        /// </summary>
        public string dFab { get; set; }

        /// <summary>
        ///     K05 - Data de validade. Formato: “AAAA-MM-DD”
        /// </summary>
        public string dVal { get; set; }

        /// <summary>
        ///     K06 - Preço máximo consumidor
        /// </summary>
        public decimal vPMC
        {
            get { return _vPmc; }
            set { _vPmc = value.Arredondar(2); }
        }
    }
}