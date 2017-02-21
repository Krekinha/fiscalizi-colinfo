using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
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
            var items = (ObservableCollection<Vendedor>)value;
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
            var items = (ObservableCollection<Vendedor>)value;
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

            var total = items.Cast<Pedido>().Count(p => p.NumPedido > 0);
            return total;
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

    public class SitCadastroClienteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cli = (Cliente) value;
            var digts = Tools.SoString(cli.CNPJ);
            var idx = digts.Length - 6;
            if (digts.Substring(idx, 4) == "0000")
                return "ISENTO";

            if (cli?.RetConsultaCadastro == null)
            {
                if (cli.IE == "" || cli.IE == "ISENTO")
                {
                    return cli.RetConsultaCadastro != null && cli.RetConsultaCadastro.infCons.infCad.Count > 0 ? "ERRO" : "ISENTO";
                }
                return "CONSULTAR";
            }
                
            if (cli.RetConsultaCadastro.infCons.infCad.Count <= 0) return "CONSULTAR";

            if (cli.RetConsultaCadastro.ErrorCode == "err_divers") return "ERRO";

            var sit = cli.RetConsultaCadastro.infCons.infCad.Find(s => s.IE == cli.IE.Replace(".", "").Replace("/", ""));
            if (sit == null) return "CONSULTAR";
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
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
            var items = (ObservableCollection<Vendedor>)value;
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

    public class SituacaoCNPJIconVendConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vnd = (Vendedor)value;
            foreach (var ped in vnd.Pedidos)
            {
                if (ped.Cliente != null && ped.Cliente.RetConsultaCadastro != null)
                {
                    var sit =
                        ped.Cliente.RetConsultaCadastro.infCons.infCad.Find(
                            p => p.IE == ped.Cliente.IE.Replace(".", "").Replace("/", ""));

                    if (sit != null && sit.cSit == "0")
                        return PackIconKind.AccountOff;


                }
            }
            return PackIconKind.CheckCircle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
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
    }
}
