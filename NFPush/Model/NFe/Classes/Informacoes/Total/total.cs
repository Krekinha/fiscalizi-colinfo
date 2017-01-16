﻿using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Total
{
    public class total
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     W02 - Grupo Totais referentes ao ICMS
        /// </summary>
        public ICMSTot ICMSTot { get; set; }

        /// <summary>
        ///     W17 - Grupo Totais referentes ao ISSQN
        /// </summary>
        public ISSQNtot ISSQNtot { get; set; }

        /// <summary>
        ///     W23 - Grupo Retenções de Tributos
        /// </summary>
        public retTrib retTrib { get; set; }
    }
}