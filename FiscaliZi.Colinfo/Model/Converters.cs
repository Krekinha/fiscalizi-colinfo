﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MaterialDesignThemes.Wpf;

namespace FiscaliZi.Colinfo.Model
{
    public class CurrentAccentColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var cor = AppearanceManager.Current.AccentColor;
            //return new SolidColorBrush(cor);
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class TotalValPedsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (List<Pedido>)value;
            if (items == null) return "";

            var total = items.Cast<Pedido>().Sum(ped => ped.ValorTotal);
            return total.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class TotalPedsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (ObservableCollection<Arquivo>)value;
            if (items == null) return 0;
            int totPeds = 0;
            foreach (var item in items)
            {
                if (item.Pedidos != null)
                    totPeds += item.Pedidos.Count;
            }
            return totPeds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class Total_FormPgtConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (ObservableCollection<Arquivo>)value;
            if (items == null) return 0;
            int? totBols = 0;
            foreach (var item in items)
            {
                totBols += item.Pedidos?.Cast<Pedido>().Count(ped => ped.FormPgt == "4");
            }
            return totBols;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class ColetadosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (List<Pedido>)value;
            if (items == null) return "";

            //var total = items.Cast<Pedido>().Count(p => p.NumPedido > 0);
            //return total;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class RotaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (List<Pedido>)value;
            if (items == null) return "";

            var total = items.Cast<Pedido>().Select(p => p.Cliente.Rota).Distinct();

            var Trota = total.Aggregate("", (current, rota) => current + (rota + ", "));
            return Trota.Remove(Trota.LastIndexOf(','));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class ResumoVendasConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var peds = (List<Pedido>)value;
            if (peds == null) return "";

            var items = peds?.SelectMany(it => it.Itens);

            var rankedItems = Tools.RankProd(items);

            return $"{rankedItems[0].QntCX} {rankedItems[0].Produto} | {rankedItems[1].QntCX} {rankedItems[1].Produto}";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class SitCadastroClienteConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var consulta = (retConsCad)values[0];
            var cnpj = (string)values[1];
            var ie = (string) values[2];

            var digts = Tools.SoString(cnpj);
            var idx = digts.Length - 6;
            if (digts.Substring(idx, 4) == "0000") return "ISENTO";

            if (consulta != null)
            {
                if (consulta.ErrorCode == "err_dives") return "ERRO";

                if (ie == "" || ie == "ISENTO")
                {
                    return consulta.infCons?.infCad?.Count > 0 ? "ERRO" : "ISENTO";
                }

                var sit = consulta.infCons?.infCad.Find(s => s.IE == ie.Replace(".", "").Replace("/", ""));
                if (sit == null)
                {
                    if (!string.IsNullOrEmpty(consulta.infCons.cStat))
                    {
                        return "ERRO";
                    }
                    return "CONSULTAR";
                }
                switch (sit.cSit)
                {
                    case "1":
                        return "HABILITADO";
                    case "0":
                        return "REJEIÇÃO";
                    default:
                        return "?????";
                }
            }
            else
            {
                if (ie == "" || ie == "ISENTO") return "ISENTO";
                return "CONSULTAR";
            }

           // if (consulta.infCons?.infCad?.Count <= 0) return "CONSULTAR";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SitCadastroClientecSitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value?.ToString())
            {
                case "1":
                    return "HABILITADO - ATIVO";
                case "0":
                    return "BAIXADA";
                default:
                    return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SituacaoCNPJColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "CONSULTAR":
                    return new SolidColorBrush(Colors.RoyalBlue);
                case "HABILITADO":
                    return new SolidColorBrush(Colors.MediumSeaGreen);
                case "ISENTO":
                    return new SolidColorBrush(Colors.LightSeaGreen);
                case "REJEIÇÃO":
                    return new SolidColorBrush(Colors.Red);
                case "ERRO":
                    return new SolidColorBrush(Colors.Red);
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }

    public class SituacaoCNPJIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case "CONSULTAR":
                    return PackIconKind.HelpCircle;
                case "HABILITADO":
                    return PackIconKind.CheckCircle;
                case "ISENTO":
                    return PackIconKind.CheckCircle;
                case "REJEIÇÃO":
                    return PackIconKind.AccountOff;
                case "ERRO":
                    return PackIconKind.Alert;
                default:
                    return PackIconKind.Read;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }

    public class RejeicoesCNPJConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (List<Pedido>)value;
            int rej = 0;
            int err = 0;
            int hab = 0;
            if (items == null) return 0;
            if (items.Count > 0)
            {
                foreach (var ped in items)
                {
                    switch (ped.Cliente.Situacao)
                    {
                        case "REJEIÇÃO":
                            rej += 1;
                            break;
                        case "ERRO":
                            err += 1;
                            break;
                        case "HABILITADO":
                            hab += 1;
                            break;
                    }
                }

                switch (parameter.ToString())
                {
                    case "REJ":
                        return rej;
                    case "ERR":
                        return err;
                    case "HAB":
                        return hab;
                }
            }

            //var total = items.Cast<Vendedor>().Where(p => p.Pedidos.Select());
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class Total_RejeicoesCNPJConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (ObservableCollection<Arquivo>)value;
            int rej = 0;
            int err = 0;
            int hab = 0;
            if (items == null) return 0;
            if (items.Count > 0)
            {
                foreach (var vnd in items)
                {
                    if (vnd.Pedidos != null && vnd.Pedidos.Count > 0)
                    {
                        foreach (var ped in vnd.Pedidos)
                        {
                            switch (ped.Cliente.Situacao)
                            {
                                case "REJEIÇÃO":
                                    rej += 1;
                                    break;
                                case "ERRO":
                                    err += 1;
                                    break;
                                case "HABILITADO":
                                    hab += 1;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        return $"Err: sem pedidos no arquivo: {vnd.ArquivoVendedor}";
                    }

                }
                return rej;
                /*switch (parameter.ToString())
                {
                    case "REJ":
                        return rej;
                    case "ERR":
                        return err;
                    case "HAB":
                        return hab;
                }*/
            }
            return 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class SimplificaNomeVendedorConverter : IValueConverter
    {
        private string res = string.Empty;


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var nome = value.ToString().Split();

            if (nome.Count() > 1)
            {
                res = $"{nome[0]} {nome[1].Substring(0, 1)}";
                return res;
            }

            if (nome.Count() == 1)
            {
                res = nome[0];
                return res;
            }

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class IsCNPJConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Tools.IsCNPJ((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public class ShowConsultaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return true;
            };
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    
    public class SituacaoCNPJIconVendConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var peds = (List<Pedido>)value;
            foreach (var ped in peds)
            {
                var sit =
                    ped.Cliente?.RetConsultaCadastro?.infCons?.infCad.Find(
                        p => p.IE == ped.Cliente.IE.Replace(".", "").Replace("/", ""));

                if (sit != null && sit.cSit == "0")
                    return PackIconKind.AccountOff;

            }

            foreach (var ped in peds)
            {
                if (ped.Cliente?.RetConsultaCadastro?.ErrorCode == "err_dives")
                {
                        return PackIconKind.CloseCircle;
                }
            }

            foreach (var ped in peds)
            {
                if (ped?.Cliente?.CNPJ != null && (Tools.IsCNPJ(ped?.Cliente?.CNPJ) && ped?.Cliente?.RetConsultaCadastro?.infCons == null))
                {if(ped?.Cliente?.IE != "ISENTO")
                    return PackIconKind.HelpCircle;
                }
            }

            return PackIconKind.CheckCircle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
    public class SituacaoCNPJIconVendBackgroundConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            switch ((PackIconKind)value)
            {
                case PackIconKind.AccountOff:
                    return new SolidColorBrush(Colors.Red);
                case PackIconKind.CloseCircle:
                    return new SolidColorBrush(Colors.Red);
                case PackIconKind.HelpCircle:
                    return new SolidColorBrush(Colors.RoyalBlue);
                case PackIconKind.CheckCircle:
                    return new SolidColorBrush(Colors.MediumSeaGreen);
                default:
                    return new SolidColorBrush(Colors.DimGray);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
    public class FormatIEConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var reg = (string)value;
            return $"{reg.Substring(0,6)}.{reg.Substring(6, 3)}/{reg.Substring(9, 4)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    public static class Tools
    {
        public static string SoString(string str)
        {
            return str.Replace(".", "").Replace("/", "").Replace("-", "");
        }

        public static bool IsCNPJ(string cnpj)
        {
            var digts = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
            var idx = digts.Length - 6;

            return digts.Substring(idx, 4) != "0000";
        }

        public static Item[] RankProd(IEnumerable<Item> items)
        {
            var RankItems = new string[]{ "900090", "900090", "900090", "900090", "900090" };

            /*var rank = items
                .OrderBy(x => x.Produto == RankItems[0])
                .ThenBy(x => x.Produto == RankItems[1])
                .ThenBy(x => x.Produto == RankItems[2])
                .ThenBy(x => x.Produto == RankItems[3])
                .ThenBy(x => x.Produto == RankItems[4])
                .OrderByDescending(x => x.QntCX)
                .ToList();*/
            //var rnk = rank.Find(p => p.Produto == "900090");

            var rank = items
                .GroupBy(x => x.Produto)
                .SelectMany(x => x)
                .ToList();

            return rank.ToArray();
        }
        
        public static void Test()
        {
            
            var items = new List<Item>
            {
                new Item{ Produto = "900090", QntCX = 50, ValorTotal = 300},
                new Item{ Produto = "900090", QntCX = 40, ValorTotal = 20},
                new Item{ Produto = "900023", QntCX = 25, ValorTotal = 520}
            };

            var rank = items
                .GroupBy(x => x.Produto)
                .SelectMany(x => x)
                .ToList();

            var res = $"{rank[0].QntCX} {rank[0].Produto} | {rank[1].QntCX} {rank[1].Produto}";

            Console.WriteLine(res);

        }
    }
}
