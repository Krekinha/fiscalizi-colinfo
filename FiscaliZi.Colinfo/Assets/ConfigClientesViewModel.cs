using System;
using Caliburn.Micro;
using FiscaliZi.Colinfo.Utils;
using System.Collections.Generic;
using System.IO;
using FiscaliZi.Colinfo.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FiscaliZi.Colinfo.Assets
{
    public class ConfigClientesViewModel : PropertyChangedBase
    {
        private IEventAggregator _events;

        public ConfigClientesViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
            CliAdded = 0;
            CliAtivos = 0;
            CliAtualizados = 0;
        }

        public void AtualizaClientes()
        {
            var path = @"F:\SOF\VDWIN\EXP\CLIENTES.CSV";

            if (Environment.MachineName == "ATAIDE-PC")
                path = @"C:\Users\krekm\Desktop\CLIENTES.CSV";
            Task.Run(() =>
            {
                GetClientes(path);
            });
            
        }

        #region · Properties ·
        public int CliAtivos { get; set; }
        public int CliAdded { get; set; }
        public int CliAtualizados { get; set; }
        #endregion

        private void GetClientes(string path)
        {
            var clis = new List<Cliente>();

            var Lines = File.ReadLines(path).Select(a => a.Split(';'));
            CliAdded = 0;
            CliAtivos = 0;
            CliAtualizados = 0;
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
                    CliAtivos = clientes.Count();
                    NotifyOfPropertyChange(() => CliAtivos);
                    var cliOld = context.Clientes.FirstOrDefault(x => x.RegiaoCliente == cli.RegiaoCliente && x.NumCliente == cli.NumCliente);

                    if (cliOld == null)
                    {
                        context.Clientes.Add(cli);
                        context.SaveChanges();
                        CliAdded += 1;
                        NotifyOfPropertyChange(() => CliAdded);
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
                        CliAtualizados += 1;
                        NotifyOfPropertyChange(() => CliAtualizados);
                    }
                }

            }
        }

        private bool IsValidCliente(string[] line)
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
        private string CNPJVerif(string cnpj)
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
        private string ToCNPJ(string _cnpj)
        {
            var cnpjUnmask = DesmascararCNPJ(_cnpj);
            if (cnpjUnmask.Length == 15)
            {
                return MascararCNPJ(cnpjUnmask.Remove(0, 1));
            }
            return MascararCNPJ(cnpjUnmask);
        }
        private string MascararCNPJ(string cnpj)
        {
            string _cnpj = string.Format(@"{0:00\.000\.000\/0000\-00}", long.Parse(cnpj));
            return _cnpj;
        }
        private string DesmascararCNPJ(string cnpj)
        {
            return cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
        }
    }
}
