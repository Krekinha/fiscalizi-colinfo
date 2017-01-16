using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual
{
    public class ICMSSN500 : ICMSBasico
    {
        private decimal? _vBcstRet;
        private decimal? _vIcmsstRet;

        /// <summary>
        ///     N11 - Origem da Mercadoria
        /// </summary>
        public OrigemMercadoria orig { get; set; }

        /// <summary>
        ///     N12a - Código de Situação da Operação – Simples Nacional
        /// </summary>
        public Csosnicms CSOSN { get; set; }

        /// <summary>
        ///     N26 - Valor da BC do ICMS ST retido
        /// </summary>
        public decimal? vBCSTRet
        {
            get { return _vBcstRet.Arredondar(2); }
            set { _vBcstRet = value.Arredondar(2); }
        }

        /// <summary>
        ///     N27 - Valor do ICMS ST retido
        /// </summary>
        public decimal? vICMSSTRet
        {
            get { return _vIcmsstRet.Arredondar(2); }
            set { _vIcmsstRet = value.Arredondar(2); }
        }

        public bool ShouldSerializevBCSTRet()
        {
            return vBCSTRet.HasValue;
        }

        public bool ShouldSerializevICMSSTRet()
        {
            return vICMSSTRet.HasValue;
        }
    }
}