using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual
{
    public class ICMS70 : ICMSBasico
    {
        private decimal _pRedBc;
        private decimal _vBc;
        private decimal _pIcms;
        private decimal? _pMvast;
        private decimal? _pRedBcst;
        private decimal _vBcst;
        private decimal _pIcmsst;
        private decimal _vIcmsst;
        private decimal? _vIcmsDeson;
        private decimal _vIcms;

        /// <summary>
        ///     N11 - Origem da Mercadoria
        /// </summary>
        public OrigemMercadoria orig { get; set; }

        /// <summary>
        ///     N12- Situação Tributária
        /// </summary>
        public Csticms CST { get; set; }

        /// <summary>
        ///     N13 - Modalidade de determinação da BC do ICMS
        /// </summary>
        public DeterminacaoBaseIcms modBC { get; set; }

        /// <summary>
        ///     N14 - Percentual de redução da BC
        /// </summary>
        public decimal pRedBC
        {
            get { return _pRedBc; }
            set { _pRedBc = value.Arredondar(4); }
        }

        /// <summary>
        ///     N15 - Valor da BC do ICMS
        /// </summary>
        public decimal vBC
        {
            get { return _vBc; }
            set { _vBc = value.Arredondar(2); }
        }

        /// <summary>
        ///     N16 - Alíquota do imposto
        /// </summary>
        public decimal pICMS
        {
            get { return _pIcms; }
            set { _pIcms = value.Arredondar(4); }
        }

        /// <summary>
        ///     N17 - Valor do ICMS
        /// </summary>
        public decimal vICMS
        {
            get { return _vIcms; }
            set { _vIcms = value.Arredondar(2); }
        }

        /// <summary>
        ///     N18 - Modalidade de determinação da BC do ICMS ST
        /// </summary>
        public DeterminacaoBaseIcmsSt modBCST { get; set; }

        /// <summary>
        ///     N19 - Percentual da margem de valor Adicionado do ICMS ST
        /// </summary>
        public decimal? pMVAST
        {
            get { return _pMvast.Arredondar(4); }
            set { _pMvast = value.Arredondar(4); }
        }

        /// <summary>
        ///     N20 - Percentual da Redução de BC do ICMS ST
        /// </summary>
        public decimal? pRedBCST
        {
            get { return _pRedBcst.Arredondar(4); }
            set { _pRedBcst = value.Arredondar(4); }
        }

        /// <summary>
        ///     N21 - Valor da BC do ICMS ST
        /// </summary>
        public decimal vBCST
        {
            get { return _vBcst; }
            set { _vBcst = value.Arredondar(2); }
        }

        /// <summary>
        ///     N22 - Alíquota do imposto do ICMS ST
        /// </summary>
        public decimal pICMSST
        {
            get { return _pIcmsst; }
            set { _pIcmsst = value.Arredondar(4); }
        }

        /// <summary>
        ///     N23 - Valor do ICMS ST
        /// </summary>
        public decimal vICMSST
        {
            get { return _vIcmsst; }
            set { _vIcmsst = value.Arredondar(2); }
        }

        /// <summary>
        ///     N27a - Valor do ICMS desonerado
        /// </summary>
        public decimal? vICMSDeson
        {
            get { return _vIcmsDeson.Arredondar(2); }
            set { _vIcmsDeson = value.Arredondar(2); }
        }

        /// <summary>
        ///     N28 - Motivo da desoneração do ICMS
        /// </summary>
        public MotivoDesoneracaoIcms? motDesICMS { get; set; }

        public bool ShouldSerializepMVAST()
        {
            return pMVAST.HasValue;
        }

        public bool ShouldSerializepRedBCST()
        {
            return pRedBCST.HasValue;
        }

        public bool ShouldSerializevICMSDeson()
        {
            return vICMSDeson.HasValue;
        }

        public bool ShouldSerializemotDesICMS()
        {
            return motDesICMS.HasValue;
        }
    }
}