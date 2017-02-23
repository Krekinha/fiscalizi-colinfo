﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PostSharp.Patterns.Model;

namespace FiscaliZi.Colinfo.Model
{
    [NotifyPropertyChanged]
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }

        #region Properties
        public int RegiaoCliente { get; set; }
        public int NumCliente { get; set; }
        public int Rota { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public string Situacao { get; set; }
        public string Razao { get; set; }
        public string Sigla { get; set; }
        public Info Info { get; set; }
        public retConsCad RetConsultaCadastro { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<Pedido> NavPedidos { get; set; }
        #endregion
        

    }
}
