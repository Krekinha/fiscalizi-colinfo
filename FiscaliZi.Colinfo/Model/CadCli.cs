using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FiscaliZi.Colinfo.Model
{
    [XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe")]

    public class retConsCad : ICloneable
    {
        #region Clone

        public object Clone()
        {
            return this;
        }
        #endregion

        #region Properties
        [Key]
        public int retConsCadID { get; set; }
        [XmlAttribute]
        public string versao { get; set; }
        [XmlElement]
        public infCons infCons { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetail { get; set; }
        public int ClienteID { get; set; }
        #endregion
    }

    public class infCons
    {
        #region Properties
        [Key]
        public int InfConsID { get; set; }
        [XmlElement]
        public string verAplic { get; set; }
        [XmlElement]
        public string cStat { get; set; }
        [XmlElement]
        public string xMotivo { get; set; }
        [XmlElement]
        public string UF { get; set; }
        [XmlElement]
        public string CNPJ { get; set; }
        [XmlElement]
        public string dhCons { get; set; }
        [XmlElement]
        public string cUF { get; set; }
        [XmlElement("infCad")]
        public List<infCad> infCad { get; set; }

        public int retConsCadID { get; set; }

        #endregion
    }

    public class infCad
    {
        #region Properties
        [Key]
        public int infCadID { get; set; }
        [XmlElement]
        public string IE { get; set; }
        [XmlElement]
        public string CNPJ { get; set; }
        [XmlElement]
        public string UF { get; set; }
        [XmlElement]
        public string cSit { get; set; }
        [XmlElement]
        public string indCredNFe { get; set; }
        [XmlElement]
        public string indCredCTe { get; set; }
        [XmlElement]
        public string xNome { get; set; }
        [XmlElement]
        public string xFant { get; set; }
        [XmlElement]
        public string xRegApur { get; set; }
        [XmlElement]
        public string CNAE { get; set; }
        [XmlElement]
        public string dIniAtiv { get; set; }
        [XmlElement]
        public string dBaixa { get; set; }
        [XmlElement]
        public string IEAtual { get; set; }
        [XmlElement]
        public ender ender { get; set; }

        public int InfConsID { get; set; }
        #endregion
    }

    public class ender
    {
        #region Properties
        [Key]
        public int enderID { get; set; }
        [XmlElement]
        public string xPrepLgr { get; set; }
        [XmlElement]
        public string xTPLgr { get; set; }
        [XmlElement]
        public string xLgr { get; set; }
        [XmlElement]
        public string nro { get; set; }
        [XmlElement]
        public string xBairro { get; set; }
        [XmlElement]
        public string cMun { get; set; }
        [XmlElement]
        public string xMun { get; set; }
        [XmlElement]
        public string CEP { get; set; }

        public int infCadID { get; set; }
        #endregion
    }
}
