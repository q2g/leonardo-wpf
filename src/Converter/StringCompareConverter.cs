namespace leonardo.Converter
{
    #region Usings
    using NLog;
    using System;
    using System.Windows.Data;
    using System.Globalization; 
    #endregion

    public class StringCompareConverter : IMultiValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (values.Length != 2)
                {
                    return false;
                }
                if (values[0] is string stringval1)
                {
                    if (values[1] is string stringval2)
                    {
                        return stringval1 == stringval2;
                    }
                }
                return false;
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
            return false;

        }



        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[2];
        }
    }
}
