namespace leonardo.Converter
{
    using System.Windows.Data;
    using System;
    using System.Globalization;
    using System.Collections;
    using System.Windows;

    public class CountToVisibilityConverter : IValueConverter
    {
        public Visibility Empty { get; set; }
        public Visibility Full { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
                return (int)value == 0 ? this.Empty : this.Full;

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
