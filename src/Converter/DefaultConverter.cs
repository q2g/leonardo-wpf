namespace leonardo.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    #endregion

    class DefaultConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Style DefaultValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value == null)
            {
                return DefaultValue;
            }

            return value;

        }



        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
