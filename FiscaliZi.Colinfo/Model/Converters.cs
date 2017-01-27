using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

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
            switch (value.ToString())
            {
                case "0":
                    return "Não Habilitado - Baixado";
                case "1":
                    return "Habilitado - Ativo";
            }
            return "";
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
            var items = (List<Pedido>)value;
            int err = 0;
            int con = 0;
            int hab = 0;

            if (items == null) return null;
            if (items.Count > 0)
            {
                foreach (var ped in items)
                {
                    switch (ped.Cliente.Situacao)
                    {
                        case "REJEIÇÃO":
                            err += 1;
                            break;
                        case "ERRO":
                            err += 1;
                            break;
                        case "CONSULTAR":
                            con += 1;
                            break;
                        case "HABILITADO":
                            hab += 1;
                            break;
                    }
                }
                return retornaImagem(err, con);
            }
            return retornaImagem(err, con);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        private DrawingBrush retornaImagem(int err, int con)
        {
            ResourceDictionary dic = new ResourceDictionary();
            dic = (ResourceDictionary)Application.LoadComponent(new Uri("/FiscaliZi.Colinfo;component/Resources/Dictionaries/dicImages.xaml", UriKind.RelativeOrAbsolute));

            if (err > 0)
            {
                return (DrawingBrush)dic["statusErro"];
            }
            else
            {
                if (con > 0)
                {
                    return (DrawingBrush)dic["statusWarning"];
                }
                return (DrawingBrush)dic["statusOK"];
            }
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
}
