using NFPush.Model.NFe.Classes;
using System;
using System.Globalization;
using System.Windows.Data;

namespace NFPush.Design
{
    public class EnvioStrConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class URI_NForRESConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dfe = (DFeObj)value;
            if (value != null)
            {
                if (dfe.nfeObj != null)
                {
                    return "/NFPush;component/Images/ok2.png";
                }
                else
                {
                    if (dfe.resObj != null)
                    {
                        return "/NFPush;component/Images/StatusWarning_24x.png";
                    }
                }
                return null;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class STR_xNomeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var v1 = values[0];
            var v2 = values[1];

            if (v1 == null)
                return v2;
            /*{
                if ((string)parameter == "xNome")
                    return dfe.nfeObj.NFe.infNFe.emit.xNome;

                if ((string)parameter == "CNPJ")
                    return dfe.nfeObj.NFe.infNFe.emit.CNPJ;

                if ((string)parameter == "chNFe")
                    return dfe.nfeObj.protNFe.infProt.chNFe;

                if ((string)parameter == "dhEmi")
                    return DateTime.Parse(dfe.nfeObj.NFe.infNFe.ide.dhEmi);

                if ((string)parameter == "vNF")
                    return dfe.nfeObj.NFe.infNFe.total.ICMSTot.vNF;
                }
                else
                {
                    if (dfe.resObj != null)
                    {
                        if ((string)parameter == "xNome")
                            return dfe.resObj.xNome;
                        if ((string)parameter == "CNPJ")
                            return dfe.resObj.CNPJ;
                        if ((string)parameter == "chNFe")
                            return dfe.resObj.chNFe;
                        if ((string)parameter == "dhEmi")
                            return dfe.resObj.dhEmi;
                        if ((string)parameter == "vNF")
                            return dfe.resObj.vNF;
                    }
                }
                return null;*/
            return v1;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class STRING_NForRESConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var v1 = values[0];
            var v2 = values[1];

            if (v1 == null)
                return v2;

            return v1.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class DATETIME_NForRESConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var v1 = values[0];
            var v2 = values[1];

            if (v1 == null)
                return v2;

            return v1.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class CURRENCY_NForRESConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var v1 = values[0];
            var v2 = values[1];

            if (v1 == null)
                return $"{v2:C}";

            return $"{v1:C}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

