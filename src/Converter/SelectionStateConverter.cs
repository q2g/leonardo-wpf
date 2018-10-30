namespace leonardo.Converter
{
    #region Usings
    using leonardo.Resources;
    using NLog;
    using System;
    using System.Windows.Data;
    #endregion

    #region Implementation of generic SelectionStateConverter<T>
    public class SelectionStateTextConverter : SelectionStateConverter<string> { }

    public class SelectionStateIconConverter : SelectionStateConverter<LuiIconsEnum> { }

    public class SelectionStateBrushConverter : SelectionStateConverter<System.Windows.Media.Brush> { }
    #endregion

    #region SelectionStateConverter<T>
    public class SelectionStateConverter<T> : IValueConverter
    {
        #region Variables & Properties
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public T ALTERNATIVE { get; set; }
        public T DESELECTED { get; set; }
        public T EXCL_LOCKED { get; set; }
        public T EXCL_SELECTED { get; set; }
        public T EXCLUDED { get; set; }
        public T LOCKED { get; set; }
        public T NSTATES { get; set; }
        public T OPTION { get; set; }
        public T SELECTED { get; set; }

        public T DEFAULT { get; set; }
        #endregion

        #region IValueConverter
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                T ValueOrDefault(T Value)
                {
                    if (Value != null)
                        return Value;

                    return DEFAULT;
                }

                var state = (int)value;
                if (targetType == typeof(T))
                {
                    switch (state)
                    {
                        case /*StateEnumType.ALTERNATIVE*/ 4:
                            return ValueOrDefault(ALTERNATIVE);
                        case /*StateEnumType.DESELECTED*/ 3:
                            return ValueOrDefault(DESELECTED);
                        case /*StateEnumType.EXCL_LOCKED*/ 7:
                            return ValueOrDefault(EXCL_LOCKED);
                        case /*StateEnumType.EXCL_SELECTED*/ 6:
                            return ValueOrDefault(EXCL_SELECTED);
                        case /*StateEnumType.EXCLUDED*/ 5:
                            return ValueOrDefault(EXCLUDED);
                        case /*StateEnumType.LOCKED*/ 0:
                            return ValueOrDefault(LOCKED);
                        case /*StateEnumType.NSTATES*/ 8:
                            return ValueOrDefault(NSTATES);
                        case /*StateEnumType.OPTION*/ 2:
                            return ValueOrDefault(OPTION);
                        case /*StateEnumType.SELECTED*/ 1:
                            return ValueOrDefault(SELECTED);
                    }
                    return DEFAULT;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        } 
        #endregion
    }
    #endregion
}
