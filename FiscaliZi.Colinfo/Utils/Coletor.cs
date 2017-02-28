using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FiscaliZi.Colinfo.Assert;
using FiscaliZi.Colinfo.Model;

namespace FiscaliZi.Colinfo.Utils
{
    public class Coletor
    {
        public static Vendedor getColeta(string path, string nome)
        {
            decimal val = 0;

            //var vm = ServiceLocator.Current.GetInstance<ColetaViewModel>();

            List<Cliente> clientes = new List<Cliente>();
            List<Pedido> peds = new List<Pedido>();

            var Lines = File.ReadLines(path).Select(a => a.Split('|'));

            foreach (var line in Lines)
            {
                if (line[0] == "CCLI.TXT")
                {
                    clientes.Add(new Cliente
                    {
                        RegiaoCliente = int.Parse(line[1]),
                        NumCliente = int.Parse(line[2]),
                        Razao = line[3],
                        CNPJ = MascararCNPJ(line[15]),
                        IE = line[17],
                        Rota = int.Parse(line[41]),
                        Situacao = CNPJVerif(line[15])
                    });
                }
            }

            foreach (var line in Lines)
            {
                if (line[0] == "CAPAPEDIDO.TXT")
                {
                    if (decimal.TryParse(line[18], out val))
                    {
                        val = decimal.Parse(line[18].Replace(".", ","));
                        Cliente cli = clientes.Find(x => x.RegiaoCliente == int.Parse(line[3]) && x.NumCliente == int.Parse(line[4]));
                        if (cli != null)
                        {
                            peds.Add(new Pedido
                            {
                                NumPedPalm = line[8],
                                ValorTotal = val,
                                FormPgt = line[21],
                                NumVendedor = int.Parse(line[2]),
                                Itens = new List<Item>(),
                                Cliente = cli
                            });
                        }
                        else
                        {
                            peds.Add(new Pedido
                            {
                                NumPedPalm = line[10],
                                ValorTotal = val
                            });
                            //Dialog.SimpleOK($"Cliente {int.Parse(line[3])}-{int.Parse(line[4])} não encontrado no arquivo {nome}", "Erro");
                        }

                    }

                }
            }
            foreach (var line in Lines)
            {
                if (line[0] == "ITEMPEDIDO.TXT")
                {

                    Item item = new Item
                    {
                        Produto = new Produto { Codigo = int.Parse(line[6]) },
                        Quantidade = int.Parse(line[8]),

                        ValorUnid = ToDecimal(line[16]),
                        ValorTotal = ToDecimal(line[11])
                    };

                    peds.Where(x => x.NumPedPalm == line[38]).ToList().ForEach(i => i.Itens.Add(item));
                }
            }

            if (peds.Count > 0)
            {
                #region Não duplicar vendedor
                /*var vends = ds.GetVendedores().Where(c => c.DataColeta == DateTime.Today && c.Numero == peds.First().Vendedor);

                if (vends.Count() > 0)
                {
                    foreach (var item in peds)
                    {
                        vends.First().Pedidos.Add(item);
                    }
                    ds.EditarVendedor(vends.First());
                }
                else
                {

                }*/
                #endregion

                var vend = new Vendedor
                {
                    NomeVendedor = "seu ze",
                    NumVendedor = peds.First().NumVendedor,
                    ArquivoVendedor = nome,
                    Pedidos = new List<Pedido>(),
                    DataEnvio = DateTime.Now,
                    DataColeta = DateTime.Now
                };
                foreach (var item in peds)
                {
                    vend.Pedidos.Add(item);
                }

                return vend;
            }
            return null;

        }

        private static string MascararCNPJ(string cnpj)
        {
            string _cnpj = string.Format(@"{0:00\.000\.000\/0000\-00}", long.Parse(cnpj));
            return _cnpj;
        }
        private static string DesmascararCNPJ(string cnpj)
        {
            return cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
        }
        private static string CNPJVerif(string cnpj)
        {
            if ((cnpj.Substring(9, 4) == "0000"))
            {
                return "P.FISICA";
            }
            else
            {
                return "CONSULTAR";
            }
        }
        private static decimal ToDecimal(string str)
        {
            decimal parsed;

            if (decimal.TryParse(str, out parsed))
            {
                return parsed;
            }
            else
            {
                return 0;
            }
        }
    }
}
