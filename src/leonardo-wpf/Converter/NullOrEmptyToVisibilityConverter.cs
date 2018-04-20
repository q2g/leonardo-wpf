namespace leonardo.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows;

    public class NullOrEmptyToVisibilityConverter : IValueConverter
    {
        public Visibility True { get; set; }
        public Visibility False { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null || (value is String && String.IsNullOrEmpty(value as String)))
                    return True;
                return False;
            }
            catch
            {

            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public NullOrEmptyToVisibilityConverter()
        {
            True = Visibility.Visible;
            False = Visibility.Collapsed;
        }
    }
}
