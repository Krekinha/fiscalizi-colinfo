
using System;
using NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual.Tipos;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Estadual
{
    [Table("ICMS60")]
    public class ICMS60 : ICMSBasico
    {
        private decimal? _vBcstRet;
        private decimal? _vIcmsstRet;

        /// <summary>
        ///     N11 - Origem da Mercadoria
        /// </summary>
        public OrigemMercadoria orig { get; set; }

        /// <summary>
        ///     N12- Situação Tributária
        /// </summary>
        public Csticms CST { get; set; }

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