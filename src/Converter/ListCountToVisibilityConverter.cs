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
            int listCount = -10;
            if (value is int count)
                listCount = count;

            if (value is ICollection coll)
                listCount = coll.Count;
            if (listCount != -10)
            {
                if (IsExactMatch)
                    return listCount == CountToMatch ? this.CountMatchesVisibility : this.ElseVisibility;
                if (IsGreaterThanMatch)
                    return listCount > CountToMatch ? this.CountMatchesVisibility : this.ElseVisibility;
            }
            return ElseVisibility;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
