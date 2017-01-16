using System.Collections.Generic;
using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Transporte
{
    public class transp
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     X02 - Modalidade do frete
        /// </summary>
        public ModalidadeFrete modFrete { get; set; }

        /// <summary>
        ///     X03 - Grupo Transportador
        /// </summary>
        public transporta transporta { get; set; }

        /// <summary>
        ///     X11 - Grupo Retenção ICMS transporte
        /// </summary>
        public retTransp retTransp { get; set; }

        /// <summary>
        ///     X18 - Grupo Veículo Transporte
        /// </summary>
        public veicTransp veicTransp { get; set; }

        /// <summary>
        ///     X22 - Grupo Reboque
        ///     <para>Ocorrência: 0-5</para>
        /// </summary>
        [XmlElement("reboque")]
        public List<reboque> reboque { get; set; }

        /// <summary>
        ///     X26 - Grupo Volumes
        ///     <para>Ocorrência: 0-5000</para>
        /// </summary>
        [XmlElement("vol")]
        public List<vol> vol { get; set; }
    }
}