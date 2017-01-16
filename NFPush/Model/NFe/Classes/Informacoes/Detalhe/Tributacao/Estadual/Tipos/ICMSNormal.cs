namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos
{
    public abstract class ICMSNormal : ICMSBasico
    {
        private decimal _vBc;
        private decimal _pIcms;
        private decimal _vIcms;

        /// <summary>
        ///     Modalidade de determinação da BC do ICMS
        ///     <para>0 - Margem Valor Agregado (%);</para>
        ///     <para>1 - Pauta (valor);</para>
        ///     <para>2 - Preço Tabelado Máximo (valor);</para>
        ///     <para>3 - Valor da Operação.</para>
        /// </summary>
        public DeterminacaoBaseIcms modBC { get; set; }

        /// <summary>
        ///     Valor da BC do ICMS
        /// </summary>
        public decimal vBC
        {
            get { return _vBc; }
            set { _vBc = value.Arredondar(2); }
        }

        /// <summary>
        ///     Alíquota do ICMS
        /// </summary>
        public decimal pICMS
        {
            get { return _pIcms; }
            set { _pIcms = value.Arredondar(4); }
        }

        /// <summary>
        ///     Valor do ICMS
        /// </summary>
        public decimal vICMS
        {
            get { return _vIcms; }
            set { _vIcms = value.Arredondar(2); }
        }
    }
}