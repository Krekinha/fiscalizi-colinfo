using NFe.Classes.Servicos.DistribuicaoDFe.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFPush.Model.NFe.Classes
{
    public class DFeObj
    {
        public int ID { get; set; }

        public short NSU { get; set; }
        public string schema { get; set; }

        public string xmlNFe { get; set; }

        public nfeProc nfeObj { get; set; }

        public resNFe resObj { get; set; }

        public procEventoNFe eventoNFe { get; set; }
    }
}
