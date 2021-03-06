﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using DFe.Utils;
using FiscaliZi.Colinfo.Utils;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace FiscaliZi.Colinfo.Model
{
    public class ArquivoExistConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty(value.ToString())) return "ok";
            return "no";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class ArquivoExistColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var peds = (string)values[0];
            var res = (string)values[1];

            if (string.IsNullOrEmpty(peds))
            {
                if (!string.IsNullOrEmpty(res))
                {
                    return new SolidColorBrush(Colors.DodgerBlue);
                }
                return new SolidColorBrush(Colors.Red);
            }

            if (int.Parse(peds) < 5)
                return new SolidColorBrush(Colors.Red);
            return new SolidColorBrush(Colors.Black);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class CheckDuplePedIconConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var peds = (ICollection<Pedido>)value;

            var res = peds?.Select(x => x.DP).Distinct().ToArray();
            return res != null && res.Contains("S") ? PackIconKind.Animation : PackIconKind.CheckCircle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
    public class CheckDuplePedForegroundConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            switch ((PackIconKind)value)
            {
                case PackIconKind.Animation:
                    return new SolidColorBrush(Colors.Red);
                case PackIconKind.CheckCircle:
                    return new SolidColorBrush(Colors.Transparent);
                default:
                    return new SolidColorBrush(Colors.Transparent);
            }
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
    public class DatagridTotaisVendaHeight : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var cor = AppearanceManager.Current.AccentColor;
            //return new SolidColorBrush(cor);
            return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class EnderecoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var end = (Endereco)value;
            string prep = null;

            if (end != null)
            {
                var tpLgr = end.xTPLgr.Replace("|", "");

                if (!string.IsNullOrEmpty(end.xPrepLgr)) prep = $"{end.xPrepLgr} ";
                return $"{tpLgr} {prep}{end.xLgr}, {end.nro} - {end.xBairro} - {end.CEP}";

            }

            return null;
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
            return $"{reg.Substring(0, 6)}.{reg.Substring(6, 3)}/{reg.Substring(9, 4)}";
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
    public class IsDuplePedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var ped = (Pedido)values[1];
            var peds = ((List<Pedido>)values[0]).Except(new List<Pedido>{ped}).ToList();
            

            foreach (var p in peds)
            {
                if (ped.Equals(p))
                {
                    return "S";
                }
            }

            return "N";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class IsVisibleColunaVendedorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 333) return Visibility.Visible;
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class IsVisibleIfNotNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (((List< Pedido>)value).Count > 0)
                {
                    return Visibility.Visible;
                }
            }

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class NullatorCodVendedorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 0) return null;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class OcorrenciaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var oco = (string)value;
            if (!string.IsNullOrEmpty(oco))
            {
                switch (oco.Trim())
                {
                    case "001":
                        return "NOR";
                    case "004":
                        return "BON";
                    default:
                        return oco;

                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
    public class PedNumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pedn = value?.ToString();

            if (!string.IsNullOrEmpty(pedn))
            {
                if (pedn.Length > 8)
                    return pedn.Substring(8, 4);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class PesoPedidoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = ((Pedido)value).Items;
            if (items == null) return "";

            decimal tot = 0;
            foreach (var itm in items)
            {
                if (itm.Produto.Unidades != 0)
                    tot += ((((itm.QntCX * itm.Produto.Unidades) + itm.QntUND) / itm.Produto.Unidades) * itm.Produto.PesoUnd) + (itm.Produto.PesoEmb * itm.QntCX);
            }
            return tot.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
            /*var unds = items.Sum(itm => (itm.QntCX * itm.Produto.Unidades) + itm.QntUND);
            var und_por_cx = items.Produto.Unidades;
            var total = items.Sum(itm => ((((itm.QntCX * itm.Produto.Unidades) + itm.QntUND)/ itm.Produto.Unidades) * itm.Produto.PesoUnd) + itm.Produto.PesoEmb * itm.QntCX );
            return total.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));*/
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    public class PesoPedidoDetalheConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (List<Item>)value;
            if (items == null) return "";

            decimal tot = 0;
            foreach (var itm in items)
            {
                if (itm.Produto.Unidades != 0)
                    tot += ((((itm.QntCX * itm.Produto.Unidades) + itm.QntUND) / itm.Produto.Unidades) * itm.Produto.PesoUnd) + (itm.Produto.PesoEmb * itm.QntCX);
            }
            return tot.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
            /*var unds = items.Sum(itm => (itm.QntCX * itm.Produto.Unidades) + itm.QntUND);
            var und_por_cx = items.Produto.Unidades;
            var total = items.Sum(itm => ((((itm.QntCX * itm.Produto.Unidades) + itm.QntUND)/ itm.Produto.Unidades) * itm.Produto.PesoUnd) + itm.Produto.PesoEmb * itm.QntCX );
            return total.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));*/
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
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
    public class ResumoVendasConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vnd = (Venda) value;
            var resumo = new List<Resumo>();

            if (vnd?.Pedidos == null)
            {
                using (var context = new ColinfoContext())
                {
                    var arq = context.Arquivos
                        .Include(x => x.Pedidos)
                        .FirstOrDefault(x => x.CodVendedor == vnd.CodVendedor && x.Pedidos.Count > 4);
                    if (arq != null)
                    {
                        resumo.Add
                            (
                            new Resumo
                            {
                                QntCX = arq.Pedidos.Count(),
                                Sigla = arq.ArquivoVendedor
                            }
                        );
                        return resumo;
                        //return $"{arq.ArquivoVendedor} ({arq.Pedidos.Count()})";
                    }
                    return null;
                }
            };

            var items = vnd?.Pedidos?.SelectMany(it => it.Items);

            var rankedItems = Tools.RankProd(items);
            var rank2 = "?";
            if (rankedItems.Length > 1)
                rank2 = $"{rankedItems[1]?.QntCX} {Tools.GetItemNickProd(rankedItems[1]?.Produto)}";

            foreach (var item in rankedItems)
            {
                resumo.Add
                    ( 
                    new Resumo
                    {
                        QntCX = item.QntCX,
                        Sigla = Tools.GetItemNickProd(item.Produto)
                    }
                    );
            }

            return resumo;
            //return $"{rankedItems[0].QntCX} {Tools.GetItemNickProd(rankedItems[0].Produto)}  |  {rank2}";

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
            var arq = (Arquivo) value;
            if (arq?.NomeVendedor == "ROMANEIO") return null;

            var items = arq?.Pedidos;
            if (items == null) return "";
            if (items.Count == 0) return "";

            var total = items.Cast<Pedido>().Select(p => p.Cliente.Rota).Distinct();

            var Trota = total.Aggregate("", (current, rota) => current + (rota + ", "));
            return $"({Trota?.Remove(Trota.LastIndexOf(','))})";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class RotaConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (List<Pedido>)value;
            if (items == null) return "";

            var Tpasta = items.Cast<Pedido>().Select(p => p.Pasta[p.Pasta.Length - 1]).Distinct();

            var Trota = Tpasta.Aggregate("", (current, rota) => current + (rota + ", "));
            return Trota.Remove(Trota.LastIndexOf(','));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class RotaConverter3 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {


            var pasta = value?.ToString();

            var Tpasta = pasta[pasta.Length - 1];

            return Tpasta;

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
    public class SitCadastroClienteConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var consulta = (retConsCad)values[0];
            var cnpj = (string)values[1];
            var ie = (string) values[2];

            if (string.IsNullOrEmpty(cnpj)) return "???";
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
    public class SituacaoCNPJIconVendConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var peds = (ICollection<Pedido>)value;
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
                {
                    if (ped?.Cliente?.IE != "ISENTO")
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
    public class StringToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (int.TryParse((string)value, out int res))
            {
                return res;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
    public class TabelaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty((string)value))
            {
                return value.ToString().Substring(value.ToString().Length-2, 2);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

    }
    public class ToMoney : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            var total = (decimal)value;
            return total.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
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
                totBols += item.Pedidos?.Cast<Pedido>().Count(ped => ped.TipoPgt == 4);
            }
            return totBols;
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
    public class TotalPesoPedsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var peds = (List<Pedido>)value;
                decimal tot = 0;

                if (peds == null) return 0;

                foreach (var ped in peds)
                {
                    foreach (var itm in ped.Items)
                    {
                        if (itm.Produto.Unidades != 0)
                            tot += ((((itm.QntCX * itm.Produto.Unidades) + itm.QntUND) / itm.Produto.Unidades) * itm.Produto.PesoUnd) + (itm.Produto.PesoEmb * itm.QntCX);
                    }
                }

                return tot.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
            catch (Exception)
            {

                return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class TotalValItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = (List<Item>)value;
            if (items == null) return "";

            var total = items.Sum(itm => itm.ValorTotal);
            return total.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
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
            try
            {
                var peds = (ICollection<Pedido>)value;

                if (peds == null) return 0;
                var tot = peds.Sum(ped => ped.Items.Sum(it => it.ValorTotal));
                /*foreach (var ped in peds)
                {
                    if (ped.Items != null)
                    {
                        var tot = ped.Items.Sum(itm => itm.ValorTotal);
                        total += tot;
                    }
                }*/

                //var total = peds.Cast<Pedido>().Sum(ped => ped.ValorTotalPed);
                return tot.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
            catch (Exception)
            {

                return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class TotalValPedsEntradaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var peds = (ICollection<Pedido>)value;

                if (peds == null) return 0;
                var tot = peds.Sum(ped => ped.ValorTotalPed);

                return tot.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
            }
            catch (Exception)
            {

                return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class TotalValPedsColetadosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal total = 0;
            var peds = (ICollection<Pedido>)value;
            if (peds == null) return "";

            foreach (var ped in peds)
            {
                if (ped.Items != null)
                {
                    var tot = ped.Items.Sum(itm => itm.ValorTotal);
                    total += tot;
                }
            }

            //var total = peds.Cast<Pedido>().Sum(ped => ped.ValorTotalPed);
            return total.ToString("N2", CultureInfo.CreateSpecificCulture("pt-BR"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class TotalVendasConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(List<Pedido>))
            {
                var peds = (List<Pedido>)value;
                var items = peds?.SelectMany(it => it.Items);
                var rank = items?
                    .GroupBy(l => l.Produto.Codigo)
                    .Select(cl => new Item
                    {
                        Produto = cl.First().Produto,
                        QntCX = cl.Sum(c => c.QntCX),
                        ValorTotal = cl.Sum(c => c.ValorTotal)
                    })
                    .OrderByDescending(x => x.ValorTotal)
                    .ToList();

                return rank;
            }
            return null;
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
            if (!string.IsNullOrEmpty(str))
                return str.Replace(".", "").Replace("/", "").Replace("-", "");
            return null;
        }

        public static bool IsCNPJ(string cnpj)
        {
            if (!string.IsNullOrEmpty(cnpj))
            {
                var digts = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
                var idx = digts.Length - 6;

                return digts.Substring(idx, 4) != "0000";
            }
            return false;
        }

        public static Item[] RankProd(IEnumerable<Item> items)
        {
            var rank = items
                .GroupBy(l => l.Produto.Codigo)
                .Select(cl => new Item()
                {
                    Produto = cl.First().Produto,
                    QntCX = cl.Sum(c => c.QntCX),
                    ValorTotal = cl.Sum(c => c.ValorTotal),
                })
                .OrderByDescending(x => x.ValorTotal)
                .ToList();      

            if (rank.Count >= 2)
            {
                var best2 = rank.FindAll(Tools.FindItem).ToArray();

                if (best2.Length >= 2) return best2;
                if (best2.Length == 1) return new[] { best2[0], rank.Except(best2).First() };
            }
            else
            {
                if (rank.Count == 1) return new[] { rank.First() };
                if (rank.Count < 1) return null;
            }


            return rank.ToArray();
        }
        
        public static void Test()
        {
            var items = Coletor.GetPedidos(@"C:\Users\krekm\Desktop\PEDIDOS.CSV", DateTime.Now)
                .Where(x => x.CodVendedor == 307)
                .SelectMany(it => it.Items);

            var result = items
                .GroupBy(l => l.Produto)
                .Select(cl => new Item()
                {
                    Produto = cl.First().Produto,
                    QntCX = cl.Sum(c => c.QntCX),
                    ValorTotal = cl.Sum(c => c.ValorTotal),
                })
                .OrderByDescending(x => x.ValorTotal)
                .ToList();

            var best2 = result.FindAll(Tools.FindItem);

            foreach (var v in result)
            {
                var res = $"{v.QntCX} | {v.Produto} | {v.ValorTotal}";
                Console.WriteLine(res);
            }

            Console.WriteLine($"Best 2: {best2.Count()}");

            foreach (var v in best2)
            {
                var res = $"{v.QntCX} | {v.Produto} | {v.ValorTotal}";
                Console.WriteLine(res);
            }
        }

        public static bool FindItem(Item itm)
        {
            switch (itm.Produto.Codigo)
            {
                case "0000901133":
                    return true;
                case "0000900090":
                    return true;
                case "0000900416":
                    return true;
                case "0000900089":
                    return true;
                case "0000902411":
                    return true;
                case "0000902432":
                    return true;
                case "0000902410":
                    return true;
                case "0000902406":
                    return true;
                default:
                    return false;
            }

        }

        public static string GetItemNickProd(Produto prod)
        {
            switch (prod.Codigo)
            {
                case "0000901133":
                    return "GLALIT";
                case "0000900090":
                    return "GLA600";
                case "0000900416":
                    return "GLA473";
                case "0000900089":
                    return "GLALAT";
                case "0000902411":
                    return "SCH600";
                case "0000902432":
                    return "SCHLIT";
                case "0000902410":
                    return "SCH473";
                case "0000902406":
                    return "SCHLAT";
                default:
                {
                    return string.IsNullOrEmpty(prod.Sigla) ? prod.Codigo : prod.Codigo;
                }
                    
            }

        }

        public static string GetPastaToRota()
        {
            return null;
        }
    }
}
