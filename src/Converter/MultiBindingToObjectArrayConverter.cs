namespace leonardo.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Globalization;
    using System.Windows.Data;
    #endregion

    public class MultiBindingToObjectArrayConverter : IMultiValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return values.Clone();

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[2];
        }
    }
}
