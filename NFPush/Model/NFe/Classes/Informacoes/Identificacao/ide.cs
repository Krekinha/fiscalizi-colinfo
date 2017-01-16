using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using NFPush.Model.NFe.Classes.Informacoes.Identificacao.Tipos;

namespace NFPush.Model.NFe.Classes.Informacoes.Identificacao
{
    public class ide
    {
        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     B02 - Código da UF do emitente do Documento Fiscal. Utilizar a Tabela do IBGE.
        /// </summary>
        public Estado cUF { get; set; }

        /// <summary>
        ///     B03 - Código numérico que compõe a Chave de Acesso. Número aleatório gerado pelo emitente para cada NF-e.
        /// </summary>
        public string cNF { get; set; }

        /// <summary>
        ///     B04 - Descrição da Natureza da Operação
        /// </summary>
        public string natOp { get; set; }

        /// <summary>
        ///     B05 - Indicador da forma de pagamento
        /// </summary>
        public IndicadorPagamento indPag { get; set; }

        /// <summary>
        ///     B06 - Modelo do Documento Fiscal
        /// </summary>
        public ModeloDocumento mod { get; set; }

        /// <summary>
        ///     B07 - Série do Documento Fiscal
        ///     <para>série normal 0-889</para>
        ///     <para>Avulsa Fisco 890-899</para>
        ///     <para>SCAN 900-999</para>
        /// </summary>
        public int serie { get; set; }

        /// <summary>
        ///     B08 - Número do Documento Fiscal
        /// </summary>
        public long nNF { get; set; }

        /// <summary>
        ///     B09 - Data de emissão do Documento Fiscal - V2.00 (Formato “AAAA-MM-DD”)
        /// </summary>
        public string dEmi { get; set; } //V2.00

        /// <summary>
        ///     B10 - Data de Saída ou da Entrada da Mercadoria/Produto - V2.00 (Formato “AAAA-MM-DD”)
        /// </summary>
        public string dSaiEnt { get; set; } //V2.00

        /// <summary>
        ///     B09 - Data e Hora de emissão do Documento Fiscal (AAAA-MM-DDThh:mm:ssTZD) ex.: 2012-09-01T13:00:00-03:00
        /// </summary>
        public DateTime dhEmi { get; set; }

        /// <summary>
        ///     B10 - Data e Hora da saída ou de entrada da mercadoria / produto (AAAA-MM-DDTHH:mm:ssTZD)
        /// </summary>
        public string dhSaiEnt { get; set; }

        /// <summary>
        ///     B11 - Tipo do Documento Fiscal
        /// </summary>
        public TipoNFe tpNF { get; set; }

        /// <summary>
        ///     B11a - Identificador de Local de destino da operação
        /// </summary>
        public DestinoOperacao? idDest { get; set; } //Nulable por conta da v2.00

        /// <summary>
        ///     B12 - Código do Município de Ocorrência do Fato Gerador (utilizar a tabela do IBGE)
        /// </summary>
        public long cMunFG { get; set; }

        /// <summary>
        ///     B21 - Formato de impressão do DANFE
        /// </summary>
        public TipoImpressao tpImp { get; set; }

        /// <summary>
        ///     B22 - Tipo de Emissão da NF-e
        /// </summary>
        public TipoEmissao tpEmis { get; set; }

        /// <summary>
        ///     B23 - Digito Verificador da Chave de Acesso da NF-e
        /// </summary>
        public int cDV { get; set; }

        /// <summary>
        ///     B24 - Identificação do Ambiente
        /// </summary>
        public TipoAmbiente tpAmb { get; set; }

        /// <summary>
        ///     B25a - Finalidade da emissão da NF-e
        /// </summary>
        public FinalidadeNFe finNFe { get; set; }

        /// <summary>
        ///     B25a - Indica operação com consumidor final
        /// </summary>
        public ConsumidorFinal? indFinal { get; set; } //Nulable por conta da v2.00

        /// <summary>
        ///     B25b - Indicador de presença do comprador no estabelecimento comercial no momento da operação
        /// </summary>
        public PresencaComprador? indPres { get; set; } //Nulable por conta da v2.00

        /// <summary>
        ///     B26 - Processo de emissão utilizado com a seguinte codificação:
        /// </summary>
        public ProcessoEmissao procEmi { get; set; }

        /// <summary>
        ///     B27 - versão do aplicativo utilizado no processo de emissão
        /// </summary>
        public string verProc { get; set; }

        /// <summary>
        ///     B28 - Informar apenas para tpEmis diferente de 1
        ///     <para>
        ///         Informar a data e hora de entrada em contingência contingência no formato  (AAAA-MM-DDThh:mm:ssTZD) ex.:
        ///         2012-09-01T13:00:00-03:00.
        ///     </para>
        /// </summary>
        public string dhCont { get; set; }

        /// <summary>
        ///     B29 - Informar a Justificativa da entrada
        /// </summary>
        public string xJust { get; set; }

        /// <summary>
        ///     BA01 - Informação de Documentos Fiscais referenciados
        /// </summary>
        [XmlElement("NFref")]
        public List<NFref> NFref { get; set; }

        public bool ShouldSerializeidDest()
        {
            return idDest.HasValue;
        }

        public bool ShouldSerializeindFinal()
        {
            return indFinal.HasValue;
        }

        public bool ShouldSerializeindPres()
        {
            return indPres.HasValue;
        }
    }
}