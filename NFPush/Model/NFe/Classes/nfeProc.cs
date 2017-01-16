﻿using System.Xml.Serialization;
using NFPush.Model.NFe.Classes.Protocolo;

namespace NFPush.Model.NFe.Classes
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class nfeProc
    {
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        ///     XR02
        /// </summary>
        [XmlAttribute]
        public string versao { get; set; }

        /// <summary>
        ///     XR03 - Dados da NF-e, inclusive com os dados da assinatura (Anexo I)
        /// </summary>
        [XmlElement("NFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
        public NFeObj NFe { get; set; }

        /// <summary>
        ///     XR05 - Dados do Protocolo de Autorização de Uso (item 4.2.2)
        /// </summary>
        public protNFe protNFe { get; set; }
    }
}