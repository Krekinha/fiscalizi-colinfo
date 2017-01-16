﻿using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes
{
    public class exporta
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     ZA02 - Sigla da UF de Embarque ou de transposição de fronteira
        /// </summary>
        public string UFSaidaPais { get; set; }

        /// <summary>
        ///     ZA03 - Descrição do Local de Embarque ou de transposição de fronteira
        /// </summary>
        public string xLocExporta { get; set; }

        /// <summary>
        ///     ZA04 - Descrição do local de despacho
        /// </summary>
        public string xLocDespacho { get; set; }
    }
}