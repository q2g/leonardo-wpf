namespace leonardo.Controls
{
    #region Usings
    using leonardo.Resources;
    using NLog;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// Interaktionslogik für LuiIcon.xaml
    /// </summary>
    public partial class LuiIcon : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const LuiIconsEnum DEFAULT = LuiIconsEnum.lui_icon_table;

        #region CTOR
        public LuiIcon()
        {
            InitializeComponent();
            mainText.Text = DEFAULT.GetIconText();
        }
        #endregion

        #region Icon - DP
        public LuiIconsEnum Icon
        {
            get { return (LuiIconsEnum)this.GetValue(IconProperty); }
            set { this.SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
         "Icon", typeof(LuiIconsEnum), typeof(LuiIcon), new FrameworkPropertyMetadata(DEFAULT, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnIconChanged)));

        private static void OnIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiIcon obj)
                {
                    if (e.NewValue is LuiIconsEnum newvalue)
                    {
                        obj.Icon_Internal = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private LuiIconsEnum icon = DEFAULT;
        internal LuiIconsEnum Icon_Internal
        {
            get { return icon; }
            set
            {
                if (icon != value || DEFAULT.GetIconText().Equals(mainText.Text))
                {
                    icon = value;
                    mainText.Text = value.GetIconText();
                }
            }
        }
        #endregion

        #region IconSize - DP
        private LuiFontSizeEnum iconsize = LuiFontSizeEnum.Normal;
        internal LuiFontSizeEnum IconSize_Internal
        {
            get { return iconsize; }
            set
            {
                if (iconsize != value)
                {
                    iconsize = value;
                    mainText.FontSize = value.GetFontSize();
                }
            }
        }
        public LuiFontSizeEnum IconSize
        {
            get { return (LuiFontSizeEnum)this.GetValue(IconSizeProperty); }
            set { this.SetValue(IconSizeProperty, value); }
        }

        public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register(
         "IconSize", typeof(LuiFontSizeEnum), typeof(LuiIcon), new FrameworkPropertyMetadata(LuiFontSizeEnum.Normal, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnIconSizeChanged)));

        private static void OnIconSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiIcon obj)
                {
                    if (e.NewValue is LuiFontSizeEnum newvalue)
                    {
                        obj.IconSize_Internal = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        #endregion

        #region CornerRadius - DP
        private CornerRadius cornerRadius = new CornerRadius(1.01);
        internal CornerRadius CornerRadius_Internal
        {
            get { return cornerRadius; }
            set
            {
                if (cornerRadius != value)
                {
                    cornerRadius = value;

                    SetCornerRadius();
                }
            }
        }
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)this.GetValue(CornerRadiusProperty); }
            set { this.SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
         "CornerRadius", typeof(CornerRadius), typeof(LuiIcon), new FrameworkPropertyMetadata(new CornerRadius(1.01), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnCornerRadiusChanged)));

        private static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiIcon obj)
                {
                    if (e.NewValue is CornerRadius newvalue)
                    {
                        obj.CornerRadius_Internal = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void SetCornerRadius()
        {
            mainText.Resources.Clear();
            Style style = new Style(typeof(Border));
            style.Setters.Add(new Setter(Border.CornerRadiusProperty, cornerRadius));
            mainText.Resources.Add(typeof(Border), style);
        }
        #endregion
    }
}
