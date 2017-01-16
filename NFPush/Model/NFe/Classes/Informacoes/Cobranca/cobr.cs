﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Cobranca
{
    public class cobr
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     Y02 - Grupo Fatura
        /// </summary>
        public fat fat { get; set; }

        /// <summary>
        ///     Y07 - Grupo Duplicata
        ///     <para>Ocorrência: 0-120</para>
        /// </summary>
        [XmlElement("dup")]
        public List<dup> dup { get; set; }
    }
}