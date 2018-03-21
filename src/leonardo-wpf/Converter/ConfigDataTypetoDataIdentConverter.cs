using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace leonardo_wpf.Converter
{
    public class ConfigDataTypetoDataIdentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string code = "";
            //if (value is ConfigDataType dataType)
            //{
            //    switch (dataType)
            //    {
            //        case ConfigDataType.Dimension:
            //            code = "DIM";
            //            break;
            //        case ConfigDataType.Kennzahl:
            //            code = "KEZ";
            //            break;
            //        case ConfigDataType.Formel:
            //            code = "KEZ";
            //            break;
            //        default:
            //            code = "???";
            //            break;
            //    }
            //}
            return code;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
