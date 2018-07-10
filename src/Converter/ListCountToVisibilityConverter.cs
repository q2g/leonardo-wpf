namespace leonardo.Converter
{
    #region Usings
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    #endregion

    public class ListCountToVisibilityConverter : IValueConverter
    {
        public int CountToMatch { get; set; }
        public Visibility CountMatchesVisibility { get; set; }
        public Visibility ElseVisibility { get; set; }
        public bool IsExactMatch { get; set; }
        public bool IsGreaterThanMatch { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int count)
            {
                if (IsExactMatch)
                    return count == CountToMatch ? this.CountMatchesVisibility : this.ElseVisibility;
                if (IsGreaterThanMatch)
                    return count > CountToMatch ? this.CountMatchesVisibility : this.ElseVisibility;
            }

            return ElseVisibility;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
