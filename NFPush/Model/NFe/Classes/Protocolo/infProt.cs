using System;
using NFPush.Model.NFe.Classes.Assinatura;
using NFPush.Model.NFe.Classes.Informacoes.Identificacao.Tipos;
using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Protocolo
{
    public class infProt
    {
        [XmlIgnore]
        public int ID { get; set; }
        /// <summary>
        ///     PR04 - Identificador da TAG a ser assinada, somente precisa ser informado se a UF assinar a resposta.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     PR05 - Identificação do Ambiente
        /// </summary>
        public TipoAmbiente tpAmb { get; set; }

        /// <summary>
        ///     PR06 - Versão do Aplicativo que processou a consulta.
        /// </summary>
        public string verAplic { get; set; }

        /// <summary>
        ///     PR07 - Chave de Acesso da NF-e
        /// </summary>
        public string chNFe { get; set; }

        /// <summary>
        ///     PR08 - Data e hora de recebimento
        /// </summary>
        public DateTime dhRecbto { get; set; }

        /// <summary>
        ///     PR09 - Número do Protocolo da NF-e
        /// </summary>
        public string nProt { get; set; }

        /// <summary>
        ///     PR10 - Digest Value da NF-e processada Utilizado para conferir a integridade da NFe original.
        /// </summary>
        public string digVal { get; set; }

        /// <summary>
        ///     PR11 - Código do status da resposta.
        /// </summary>
        public int cStat { get; set; }

        /// <summary>
        ///     PR12 - Descrição literal do status da resposta.
        /// </summary>
        public string xMotivo { get; set; }

        /// <summary>
        ///     PR13 - Assinatura XML do grupo identificado pelo atributo “Id”
        ///     A decisão de assinar a mensagem fica a critério da UF interessada.
        /// </summary>
        public Signature Signature { get; set; }
    }
}