using System;
using System.Xml.Serialization;

namespace NFPush.Model.NFe.Classes.Informacoes
{
    public class entrega
    {
        private const string ErroCpfCnpjPreenchidos = "Somente preencher um dos campos: CNPJ ou CPF, para um objeto do tipo entrega!";
        private string cnpj;
        private string cpf;

        [XmlIgnore]
        public int ID { get; set; }

        /// <summary>
        ///     G02 - CNPJ
        /// </summary>
        public string CNPJ
        {
            get { return cnpj; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(cpf))
                    cnpj = value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjPreenchidos);
                }
            }
        }

        /// <summary>
        ///     G02a - CPF
        /// </summary>
        public string CPF
        {
            get { return cpf; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;
                if (string.IsNullOrEmpty(cnpj))
                    cpf = value;
                else
                {
                    throw new ArgumentException(ErroCpfCnpjPreenchidos);
                }
            }
        }

        /// <summary>
        ///     G03 - Logradouro
        /// </summary>
        public string xLgr { get; set; }

        /// <summary>
        ///     G04 - Número
        /// </summary>
        public string nro { get; set; }

        /// <summary>
        ///     G05 - Complemento
        /// </summary>
        public string xCpl { get; set; }

        /// <summary>
        ///     G06 - Bairro
        /// </summary>
        public string xBairro { get; set; }

        /// <summary>
        ///     G07 - Código do município
        ///     <para>Código do município (utilizar a tabela do IBGE), informar 9999999 para operações com o exterior.</para>
        /// </summary>
        public long cMun { get; set; }

        /// <summary>
        ///     G08 - Nome do município, informar EXTERIOR para operações com o exterior.
        /// </summary>
        public string xMun { get; set; }

        /// <summary>
        ///     G09 - Sigla da UF, informar EX para operações com o exterior.
        /// </summary>
        public string UF { get; set; }
    }
}