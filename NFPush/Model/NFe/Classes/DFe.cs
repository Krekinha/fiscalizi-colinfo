using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFPush.Model.NFe.Classes
{
    public class DFe
    {
        public int ID { get; set; }
        /// <summary>
        /// B12 - NSU do documento fiscal
        /// </summary>
        public short NSU { get; set; }

        /// <summary>
        /// B13 - Identificação do Schema XML que será utilizado para validar o XML existente no campo seguinte.
        /// Vai identificar o tipo do documento e sua versão.
        /// Exemplos:
        /// - resNFe_v1.00.xsd
        /// - procNFe_v3.10.xsd
        /// - resEvento_1.00.xsd
        /// - procEventoNFe_v1.00.xsd
        /// </summary>
        public string schema { get; set; }

        /// <summary>
        /// Conteudo da Tag schema. 
        /// O conteúdo desta tag estará compactado no padrão gZip.O tipo do campo é base64Binary.
        /// </summary>
        public string xmlDFe { get; set; }

        
    }
}
