using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using FiscaliZi.Colinfo.Assets;
using FiscaliZi.Colinfo.Model;
using Microsoft.EntityFrameworkCore;
using NFe.Classes.Informacoes.Detalhe;

namespace FiscaliZi.Colinfo.Utils
{
    public class Coletor
    {
        public static Arquivo getArquivo(string path, string nome)
        {
            using (var context = new ColinfoContext())
            {
                decimal val = 0;

                var peds = new List<Pedido>();

                var Lines = File.ReadLines(path).Select(a => a.Split('|'));

                //Clientes
                var clientes = (from line in Lines
                    where line[0] == "CCLI.TXT"
                    select new Cliente
                    {
                        RegiaoCliente = int.Parse(line[1]),
                        NumCliente = int.Parse(line[2]),
                        Razao = line[3],
                        Sigla = line[4],
                        CNPJ = MascararCNPJ(line[15]),
                        IE = line[17],
                        Rota = int.Parse(line[41]),
                        Situacao = CNPJVerif(line[15])
                    }).ToList();
                //Pedidos
                foreach (var line in Lines)
                {
                    if (line[0] == "CAPAPEDIDO.TXT")
                    {
                        if (decimal.TryParse(line[18], out val))
                        {
                            val = decimal.Parse(line[18].Replace(".", ","));
                            var cli = clientes.Find(x => x.RegiaoCliente == int.Parse(line[3]) && x.NumCliente == int.Parse(line[4]));
                            var cli_context = context.Clientes.FirstOrDefault(x => x.CNPJ == cli.CNPJ);

                            if (cli_context != null)
                            {
                                if (cli != null)
                                {
                                    cli_context.RegiaoCliente = cli.RegiaoCliente;
                                    cli_context.NumCliente = cli.NumCliente;
                                    cli_context.Razao = cli.Razao;
                                    cli_context.Sigla = cli.Sigla;
                                    cli_context.CNPJ = cli.CNPJ;
                                    cli_context.IE = cli.IE;
                                    cli_context.Rota = cli.Rota;
                                    cli_context.Situacao = CNPJVerif(cli.CNPJ);

                                    peds.Add(new Pedido
                                    {
                                        NumPedPalm = line[8],
                                        ValorTotalPed = val,
                                        TipoPgt = int.Parse(line[21]),
                                        PrazoPgt = int.Parse(line[22]),
                                        CodVendedor = int.Parse(line[2]),
                                        Items = new List<Item>(),
                                        Cliente = cli_context
                                    });
                                }
                            }
                            else
                            {
                                peds.Add(new Pedido
                                {
                                    NumPedPalm = line[8],
                                    ValorTotalPed = val,
                                    TipoPgt = int.Parse(line[21]),
                                    PrazoPgt = int.Parse(line[22]),
                                    CodVendedor = int.Parse(line[2]),
                                    Items = new List<Item>(),
                                    Cliente = cli
                                });
                            }
                        }
                    }
                }
                //Items
                foreach (var line in Lines)
                {
                    if (line[0] == "ITEMPEDIDO.TXT")
                    {

                        var item = new Item
                        {
                            Produto = context.Produtos.FirstOrDefault(x => x.Codigo == line[6]),
                            QntCX = int.Parse(line[8]),

                            ValorUnid = ToDecimal(line[16]),
                            ValorTotal = ToDecimal(line[11])
                        };

                        peds.Where(x => x.NumPedPalm == line[38]).ToList().ForEach(i => i.Items.Add(item));
                    }
                }

                if (peds.Count > 0)
                {
                    #region Não duplicar vendedor

                    #endregion

                    var arq = new Arquivo
                    {
                        NomeVendedor = "seu ze",
                        CodVendedor = peds.First().CodVendedor,
                        ArquivoVendedor = nome,
                        Pedidos = new List<Pedido>(),
                        DataEnvio = DateTime.Now,
                        DataColeta = DateTime.Now
                    };
                    foreach (var item in peds)
                    {
                        arq.Pedidos.Add(item);
                    }

                    context.Arquivos.Add(arq);
                    context.SaveChanges();
                    return arq;
                }
                return null;
            }

        }
        public static List<Pedido> GetPedidos(string path, DateTime date)
        {
            var peds = new List<Pedido>();

            var Lines = File.ReadLines(path).Select(a => a.Split(';'));

            using (var context = new ColinfoContext())
            {
                foreach (var line in Lines)
                {
                    if (!IsValidPed(line, date)) continue;

                    var prod =  context.Produtos.FirstOrDefault(p => p.Codigo == line[34]);
                    if (prod == null)
                        prod = new Produto { Codigo = line[34] };

                    var item = new Item
                    {
                        Produto = prod,
                        Ocorrencia = line[53].Trim(),
                        MotOcorrencia = line[61],
                        NatOper = line[52],
                        Tabela = line[35],
                        QntCX = int.Parse(line[45]),
                        QntUND = int.Parse(line[46]),
                        ValorCusto = ToDecimal(line[40]),
                        ValorUnid = ToDecimal(line[39]),
                        ValorTotal = ToDecimal(line[37])
                    };
                    var ped = peds.Find(p => p.NumPedido == line[0]);

                    if (ped == null)
                    {
                        if (line[24] != "009")
                            peds.Add(
                                new Pedido
                                {
                                    NumPedido = line[0],
                                    CodVendedor = int.Parse(line[6]),
                                    ADFinanceiro = decimal.Parse(line[9]),
                                    TipoPgt = int.Parse(line[10]),
                                    PrazoPgt = int.Parse(line[11]),
                                    DataPedido = DateTime.Parse(line[29]),
                                    Items = new List<Item> { item },
                                    Cliente = GetClienteByCode(line[3]),
                                    Pasta = line[30],
                                    SitPed = line[24],
                                    ValorTotalPed = ToDecimal(line[37])//ToDecimal(line[37])
                                }
                            );
                    }
                    else
                    {
                        ped.Items.Add(item);
                    }


                }
            }
            
            return peds;

        }
        public static Arquivo GetRomaneio(string path, string _rom)
        {
            var peds = new List<Pedido>();

            try
            {
                var Lines = File.ReadLines(path).Select(a => a.Split(';'));

                using (var context = new ColinfoContext())
                {
                    foreach (var line in Lines)
                    {
                        if (!IsValidPed(line, _rom)) continue;

                        var prod = context.Produtos.FirstOrDefault(p => p.Codigo == line[34]);
                        if (prod == null)
                            prod = new Produto { Codigo = line[34] };

                        var item = new Item
                        {
                            Produto = prod,
                            Ocorrencia = line[53].Trim(),
                            MotOcorrencia = line[61],
                            NatOper = line[52],
                            Tabela = line[35],
                            QntCX = int.Parse(line[45]),
                            QntUND = int.Parse(line[46]),
                            ValorCusto = ToDecimal(line[40]),
                            ValorUnid = ToDecimal(line[39]),
                            ValorTotal = ToDecimal(line[37])
                        };
                        var ped = peds.Find(p => p.NumPedido == line[0]);
                        var cli =
                            context.Clientes.FirstOrDefault(
                                x => x.RegiaoCliente == int.Parse(line[3].Split('-')[0]) && x.NumCliente == int.Parse(line[3].Split('-')[1]));
                        if (cli == null)
                        {
                            cli = new Cliente
                            {
                                RegiaoCliente = int.Parse(line[3].Split('-')[0]),
                                NumCliente = int.Parse(line[3].Split('-')[1])
                            };
                        }
                        if (ped == null)
                        {
                            if (line[24] != "009")
                                peds.Add(
                                    new Pedido
                                    {
                                        NumPedido = line[0],
                                        CodVendedor = int.Parse(line[6]),
                                        DataPedido = DateTime.Parse(line[29]),
                                        Items = new List<Item> { item },
                                        Cliente = cli,
                                        Pasta = line[30],
                                        SitPed = line[24]
                                    }
                                );
                        }
                        else
                        {
                            ped.Items.Add(item);
                        }


                    }
                    if (peds.Count > 0)
                    {
                        var arq = new Arquivo
                        {
                            NomeVendedor = $"ROMANEIO",
                            ArquivoVendedor = $"ROM: {_rom}",
                            Pedidos = new List<Pedido>(),
                            DataEnvio = DateTime.Now,
                            DataColeta = DateTime.Now
                        };
                        foreach (var item in peds)
                        {
                            arq.Pedidos.Add(item);
                        }

                        context.Arquivos.Add(arq);
                        context.SaveChanges();
                        return arq;
                    }
                }
            }
            catch (Exception ex)
            {
                Funcoes.MostrarErro(ex);
            }

            return null;

        }
        public static void GetProdutos(string path)
        {
            var prods = new List<Produto>();

            var Lines = File.ReadLines(path).Select(a => a.Split(';'));

            using (var context = new ColinfoContext())
            {
                foreach (var line in Lines)
                {
                    if (!IsValidProduto(line)) continue;

                    var prod = context.Produtos.FirstOrDefault(p => p.Codigo == line[2]);

                    if (prod == null)
                    {
                        if (line[29] != "0")
                        {
                            var prd = new Produto
                            {
                                Codigo = line[2],
                                Descricao = line[4],
                                Sigla = line[8],
                                Familia = line[0],
                                Unidades = int.Parse(line[11]),
                                PesoUnd = ToDecimal(line[12]),
                                PesoEmb = ToDecimal(line[13]),
                            };
                            context.Produtos.Add(prd);
                            context.SaveChanges();
                        }

                    }
                    else
                    {
                        prod.Codigo = line[2];
                        prod.Descricao = line[4];
                        prod.Sigla = line[8];
                        prod.Familia = line[0];
                        prod.Unidades = int.Parse(line[11]);
                        prod.PesoUnd = ToDecimal(line[12]);
                        prod.PesoEmb = ToDecimal(line[13]);
                        context.Entry(prod).State = EntityState.Modified;
                        context.SaveChanges();
                    }


                }
                
            }
        }

        private static Cliente GetClienteByCode(string code)
        {
            var cz = code.Split('-');
            using (var context = new ColinfoContext())
            {
                var cli = context.Clientes
                    .Include(x => x.Endereco)
                    .FirstOrDefault(cl => cl.RegiaoCliente == int.Parse(cz[0]) && cl.NumCliente == int.Parse(cz[1]));
                if (cli == null)
                {
                    return new Cliente
                    {
                        RegiaoCliente = int.Parse(cz[0]),
                        NumCliente = int.Parse(cz[1])
                    };
                }
                return cli;
            }

        }
        public static void GetClientes(string path)
        {
            var clis = new List<Cliente>();

            var Lines = File.ReadLines(path).Select(a => a.Split(';'));

            using (var context = new ColinfoContext())
            {
                var clientes = (from line in Lines
                                where IsValidCliente(line)
                                select new Cliente
                                {
                                    RegiaoCliente = int.Parse(line[0]),
                                    NumCliente = int.Parse(line[1]),
                                    Sigla = line[3],
                                    Razao = line[4],
                                    CNPJ = ToCNPJ(line[2]),
                                    IE = line[25],
                                    Rota = int.Parse(line[31].Last().ToString()),
                                    Situacao = CNPJVerif(line[2]),
                                    Endereco = new Endereco
                                    {
                                        xTPLgr = line[45],
                                        xPrepLgr = line[46],
                                        xLgr = line[48],
                                        nro = line[49],
                                        xMun = line[51],
                                        xBairro = line[52],
                                        cMun = line[53],
                                        CEP = line[54]
    }
                                }).ToList();
                foreach (var cli in clientes)
                {
                    var cliOld = context.Clientes.FirstOrDefault(x => x.RegiaoCliente == cli.RegiaoCliente && x.NumCliente == cli.NumCliente);

                    if (cliOld == null)
                    {
                        context.Clientes.Add(cli);
                        context.SaveChanges();
                    }
                    else
                    {
                        cliOld.RegiaoCliente = cli.RegiaoCliente;
                        cliOld.NumCliente = cli.NumCliente;
                        cliOld.Razao = cli.Razao;
                        cliOld.CNPJ = cli.CNPJ;
                        cliOld.IE = cli.IE;
                        cliOld.Rota = cli.Rota;
                        cliOld.Situacao = cli.Situacao;
                        cliOld.Endereco = cli.Endereco;
                        context.Entry(cliOld).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }

            }
        }
        private static Produto GetProdutoByCode(string _code)
        {
            using (var context = new ColinfoContext())
            {
                var prod = context.Produtos.FirstOrDefault(prd => prd.Codigo == _code);
                if (prod == null)
                {
                    context.Produtos.Add(new Produto
                    {
                        Codigo = _code
                    });
                    context.SaveChanges();
                }
                return context.Produtos.FirstOrDefault(prd => prd.Codigo == _code);
            }

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
        private static string ToCNPJ(string _cnpj)
        {
            var cnpjUnmask = DesmascararCNPJ(_cnpj);
            if (cnpjUnmask.Length == 15)
            {
                return MascararCNPJ(cnpjUnmask.Remove(0, 1));
            }
            return MascararCNPJ(cnpjUnmask);
        }
        private static bool IsValidCliente(string[] line)
        {
            try
            {
                if (line[0] == "Regiao") return false;

                if (line[31] == "9500") return false;

                if (line[41] == "20") return false;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return true;
            }

        }
        private static bool IsValidPed(string[] line, DateTime dataPed)
        {
            try
            {
                if (line[0] == "Pedido") return false;

                if (!dataPed.Equals(DateTime.Parse(line[29]))) return false;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return true;
            }

        }
        private static bool IsValidPed(string[] line, string _rom)
        {
            try
            {
                if (line[0] == "Pedido") return false;

                if (!_rom.Equals(line[2])) return false;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }
        private static bool IsValidProduto(string[] line)
        {
            try
            {
                if (line[0] == "Familia") return false;

                if (line[29] == "0") return false;

                if (int.Parse(line[47]) != 0 || int.Parse(line[48]) != 0) return true;

                if (line[22] != "01" && line[22] != "10" && line[22] != "20" && line[22] != "21" && line[22] != "22" && line[22] != "02" && line[22] != "17" && line[22] != "07")
                    return false;
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return true;
            }

        }
    }
}
