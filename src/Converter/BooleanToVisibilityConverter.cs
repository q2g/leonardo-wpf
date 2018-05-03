namespace leonardo.Converter
{
    #region Usings
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows; 
    #endregion

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public Visibility True { get; set; }
        public Visibility False { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                return ((bool)value) ? True : False;

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public BooleanToVisibilityConverter()
        {
            True = Visibility.Visible;
            False = Visibility.Collapsed;
        }
    }

    public class BooleanToBrushConverter : IValueConverter
    {
        public System.Windows.Media.Brush True { get; set; }
        public System.Windows.Media.Brush False { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                return ((bool)value) ? True : False;

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public BooleanToBrushConverter()
        {
            True = null;
            False = null;
        }
    }
}
