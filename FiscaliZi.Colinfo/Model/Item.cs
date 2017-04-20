using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FiscaliZi.Colinfo.Model
{
    public class Item : IEquatable<Item>
    {
        [Key]
        public int ItemID { get; set; }

        #region Properties
        public int QntCX { get; set; }
        public int QntUND { get; set; }
        public decimal ValorCusto { get; set; }
        public decimal ValorUnid { get; set; }
        public decimal ValorTotal { get; set; }
        public string Ocorrencia { get; set; }
        public string MotOcorrencia { get; set; }
        public string NatOper { get; set; }
        public string Tabela { get; set; }

        public virtual Produto Produto { get; set; }
        #endregion

        #region Foreign Keys
        public int PedidoID { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Pedido Pedido { get; set; }
        #endregion

        #region Compare
        public bool Equals(Item other)
        {
            if (this.Produto.Codigo != other.Produto.Codigo) return false;
            if (this.QntCX != other.QntCX) return false;
            if (this.QntUND != other.QntUND) return false;

            // TODO: Compare Members and return false if not the same

            return true;
        }
        #endregion
    }
}
