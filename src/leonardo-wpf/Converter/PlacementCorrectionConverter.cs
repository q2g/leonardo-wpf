using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace leonardo_wpf.Converter
{
    [ValueConversion(typeof(PlacementMode), typeof(PlacementMode))]
    public class PlacementModeCorrectionConverter : IValueConverter
    {       
        public PlacementMode NullValue { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            
            if (!(value is PlacementMode) || value == null)
            {
                return NullValue;
            }

            if ((PlacementMode)value == PlacementMode.Left)
            {
                return PlacementMode.Right;
            }
            if ((PlacementMode)value == PlacementMode.Right)
            {
                return PlacementMode.Left;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }       
    }
}
