using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos
{
    public abstract class COFINSBasico
    {
        [XmlIgnore]
        public int ID { get; set; }

        //public virtual COFINSOutr COFINSOutr { get; set; }
    }
}