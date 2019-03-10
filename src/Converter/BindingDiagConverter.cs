namespace leonardo.Converter
{
    #region Usings
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using NLog;
    #endregion

    public class BindingDiagConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value != null)
            {

            }
            return value;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
