using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes.Detalhe.Tributacao.Federal.Tipos
{
    public abstract class PISBasico
    {
        [XmlIgnore]
        public int ID { get; set; }
    }
}