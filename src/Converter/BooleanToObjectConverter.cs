namespace leonardo.Converter
{
    #region Usings
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using NLog;
    #endregion

    [ValueConversion(typeof(bool), typeof(object))]
    public class BooleanToObjectConverter : IValueConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object TrueValue { get; set; }
        public object FalseValue { get; set; }
        public object NullValue { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return NullValue;
                }

                if (!(value is bool))
                    return null;
                return (bool)value ? TrueValue : FalseValue;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return NullValue;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (IsEqual(value, TrueValue))
                    return true;
                if (IsEqual(value, FalseValue))
                    return false;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return null;
        }

        private static bool IsEqual(object x, object y)
        {
            if (Equals(x, y))
                return true;

            IComparable c = x as IComparable;
            if (c != null)
                return (c.CompareTo(y) == 0);

            return false;
        }
    }
}
