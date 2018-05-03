namespace leonardo.Converter
{
    #region Usings
    using System;
    using System.Globalization;
    using System.Windows.Data;
    #endregion

    public class ToStringAndAddStarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return value.ToString() + "*";

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public ToStringAndAddStarConverter()
        {
        }
    }
}
