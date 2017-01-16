using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual
{
    public class ICMS00 : ICMSBasico
    {
        private decimal _vBc;
        private decimal _pIcms;
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
        ///     N15 - Valor da BC do ICMS
        /// </summary>
        public decimal vBC
        {
            get { return _vBc.Arredondar(2); }
            set { _vBc = value.Arredondar(2); }
        }

        /// <summary>
        ///     N16 - Alíquota do imposto
        /// </summary>
        public decimal pICMS
        {
            get { return _pIcms.Arredondar(4); }
            set { _pIcms = value.Arredondar(4); }
        }

        /// <summary>
        ///     N17 - Valor do ICMS
        /// </summary>
        public decimal vICMS
        {
            get { return _vIcms.Arredondar(2); }
            set { _vIcms = value.Arredondar(2); }
        }
    }
}
