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

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value is int)
                {
                    var state = (int)value;
                    if (targetType == typeof(T))
                    {
                        switch (state)
                        {
                            case /*StateEnumType.ALTERNATIVE*/ 4: if (ALTERNATIVE != null) return ALTERNATIVE; break;
                            case /*StateEnumType.DESELECTED*/ 3: if (DESELECTED != null) return DESELECTED; break;
                            case /*StateEnumType.EXCL_LOCKED*/ 7: if (EXCL_LOCKED != null) return EXCL_LOCKED; break;
                            case /*StateEnumType.EXCL_SELECTED*/ 6: if (EXCL_SELECTED != null) return EXCL_SELECTED; break;
                            case /*StateEnumType.EXCLUDED*/ 5: if (EXCLUDED != null) return EXCLUDED; break;
                            case /*StateEnumType.LOCKED*/ 0: if (LOCKED != null) return LOCKED; break;
                            case /*StateEnumType.NSTATES*/ 8: if (NSTATES != null) return NSTATES; break;
                            case /*StateEnumType.OPTION*/ 2: if (OPTION != null) return OPTION; break;
                            case /*StateEnumType.SELECTED*/ 1: if (SELECTED != null) return SELECTED; break;
                        }

                        return DEFAULT;
                    }
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
    }
    #endregion
}
