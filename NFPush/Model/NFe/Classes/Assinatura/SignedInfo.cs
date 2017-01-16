﻿using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Assinatura
{
    public class SignedInfo
    {
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        ///     XS03 - Grupo do Método de Canonicalização
        /// </summary>
        public CanonicalizationMethod CanonicalizationMethod { get; set; }

        /// <summary>
        ///     XS05 - Grupo do Método de Assinatura
        /// </summary>
        public SignatureMethod SignatureMethod { get; set; }

        /// <summary>
        ///     XS07 - Grupo Reference
        /// </summary>
        public Reference Reference { get; set; }
    }
}