using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Assinatura
{
    public class CanonicalizationMethod
    {
        [Key]
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        ///     XS04 - Atributo Algorithm de CanonicalizationMethod: http://www.w3.org/TR/2001/REC-xml-c14n-20010315
        /// </summary>
        [XmlAttribute]
        public string Algorithm { get; set; }

    }
}