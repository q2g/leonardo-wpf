namespace leonardo.Controls
{
    #region Usings
    using System;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using leonardo.AttachedProperties;
    using leonardo.Resources;
    using NLog;
    #endregion

    /// <summary>
    /// Interaktionslogik für LuiToggleButton.xaml
    /// </summary>
    public partial class LuiToggleButton : ToggleButton
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region CTOR
        public LuiToggleButton()
        {
            InitializeComponent();
        }
        #endregion

        private LuiIconsEnum savedLeftIcon { get; set; }

        #region CheckedIcon - DP
        public LuiIconsEnum CheckedIcon
        {
            get { return (LuiIconsEnum)this.GetValue(CheckedIconProperty); }
            set { this.SetValue(CheckedIconProperty, value); }
        }

        public static readonly DependencyProperty CheckedIconProperty = DependencyProperty.Register(
         "CheckedIcon", typeof(LuiIconsEnum), typeof(LuiToggleButton), new FrameworkPropertyMetadata(LuiIconsEnum.lui_icon_none, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region Checked/Unchecked Events
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is LuiToggleButton tbutton)
                {
                    if (CheckedIcon != LuiIconsEnum.lui_icon_none)
                    {
                        savedLeftIcon = (LuiIconsEnum)tbutton.GetValue(ThemeProperties.IconLeftProperty);
                        tbutton.SetValue(ThemeProperties.IconLeftProperty, CheckedIcon);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is LuiToggleButton tbutton)
                {
                    if (CheckedIcon != LuiIconsEnum.lui_icon_none)
                    {
                        tbutton.SetValue(ThemeProperties.IconLeftProperty, savedLeftIcon);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion
    }
}
