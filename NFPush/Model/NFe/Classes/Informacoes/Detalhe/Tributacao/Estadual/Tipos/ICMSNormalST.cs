namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos
{
    public abstract class ICMSNormalST : ICMSNormal
    {
        private decimal _pMvast;
        private decimal _pRedBcst;
        private decimal _vBcst;
        private decimal _pIcmsst;
        private decimal _vIcmsst;

        /// <summary>
        ///     Modalidade de determinação da BC do ICMS ST:
        ///     <para>0 – Preço tabelado ou máximo  sugerido;</para>
        ///     <para>1 - Lista Negativa (valor);</para>
        ///     <para>2 - Lista Positiva (valor);</para>
        ///     <para>3 - Lista Neutra (valor);</para>
        ///     <para>4 - Margem Valor Agregado (%);</para>
        ///     <para>5 - Pauta (valor);</para>
        /// </summary>
        public int modBCST { get; set; }

        /// <summary>
        ///     Percentual da Margem de Valor Adicionado ICMS ST
        /// </summary>
        public decimal pMVAST
        {
            get { return _pMvast; }
            set { _pMvast = value.Arredondar(4); }
        }

        /// <summary>
        ///     Percentual de redução da BC ICMS ST
        /// </summary>
        public decimal pRedBCST
        {
            get { return _pRedBcst; }
            set { _pRedBcst = value.Arredondar(4); }
        }

        /// <summary>
        ///     Valor da BC do ICMS ST
        /// </summary>
        public decimal vBCST
        {
            get { return _vBcst; }
            set { _vBcst = value.Arredondar(2); }
        }

        /// <summary>
        ///     Alíquota do ICMS ST
        /// </summary>
        public decimal pICMSST
        {
            get { return _pIcmsst; }
            set { _pIcmsst = value.Arredondar(4); }
        }

        /// <summary>
        ///     Valor do ICMS ST
        /// </summary>
        public decimal vICMSST
        {
            get { return _vIcmsst; }
            set { _vIcmsst = value.Arredondar(2); }
        }
    }
}