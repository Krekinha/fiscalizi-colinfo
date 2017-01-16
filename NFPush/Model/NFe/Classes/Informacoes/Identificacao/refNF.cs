﻿using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Identificacao
{
    public class refNF
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     BA04 - Código da UF do emitente
        /// </summary>
        public Estado cUF { get; set; }

        /// <summary>
        ///     BA05 - Ano e Mês de emissão da NF-e
        /// </summary>
        public string AAMM { get; set; }

        /// <summary>
        ///     BA06 - CNPJ do emitente
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        ///     BA07 - Modelo do Documento Fiscal
        /// </summary>
        public int mod { get; set; }

        /// <summary>
        ///     BA08 - Série do Documento Fiscal
        /// </summary>
        public int serie { get; set; }

        /// <summary>
        ///     BA09 - Número do Documento Fiscal
        /// </summary>
        public int nNF { get; set; }
    }
}