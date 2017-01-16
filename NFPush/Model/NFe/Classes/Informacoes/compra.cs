using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes
{
    public class compra
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     ZB02 - Nota de Empenho
        /// </summary>
        public string xNEmp { get; set; }

        /// <summary>
        ///     ZB03 - Pedido
        /// </summary>
        public string xPed { get; set; }

        /// <summary>
        ///     ZB04 - Contrato
        /// </summary>
        public string xCont { get; set; }
    }
}