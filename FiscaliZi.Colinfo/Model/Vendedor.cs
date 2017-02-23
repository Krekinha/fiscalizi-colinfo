using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PostSharp.Patterns.Model;

namespace FiscaliZi.Colinfo.Model
{
    [NotifyPropertyChanged]
    public class Vendedor
    {
        [Key]
        public int VendedorID { get; set; }      

        #region Properties
        public int NumVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string ArquivoVendedor { get; set; }
        public DateTime DataColeta { get; set; }
        public DateTime DataEnvio { get; set; }
        public List<Pedido> Pedidos { get; set; }
        #endregion

    }
}
