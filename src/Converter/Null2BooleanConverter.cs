namespace leonardo.Converter
{
    #region Usings   
    using System.Windows.Data;
    #endregion

    public class Null2BooleanConverter : IValueConverter
    {
        public bool NullIs { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return NullIs;

            return !NullIs;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        public Null2BooleanConverter()
        {
            NullIs = false;
        }
    }
}
