namespace leonardo.Controls
{
    #region Usings
    using NLog;
    using System;
    using System.Windows;
    using leonardo.Resources;
    using System.Windows.Media; 
    #endregion

    /// <summary>
    /// Interaction logic for LuiMessageBox.xaml
    /// </summary>
    public partial class LuiMessageBox : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region CTOR
        public LuiMessageBox()
        {
            InitializeComponent();
        } 
        #endregion

        public static bool ShowDialog(string text, LuiIconsEnum messageIcon = LuiIconsEnum.lui_icon_none)
        {
            bool returnvalue = false;
            try
            {

                Window dialog = new LuiMessageBox()
                {
                    MessageIcon = messageIcon,
                    WindowStyle = WindowStyle.None,
                    AllowsTransparency = true,
                    Background = new SolidColorBrush(Colors.Transparent),
                    Owner = null,//Application.Current.MainWindow,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    MessageText = text
                };
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Opacity = 0.5;
                }

                bool? result = dialog.ShowDialog();
                returnvalue = (result.HasValue && result.Value);

                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Opacity = 1;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return returnvalue;
        }

        public string MessageText { get; set; }

        private void LuiButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        #region MessageIcon - DP
        public LuiIconsEnum MessageIcon
        {
            get { return (LuiIconsEnum)this.GetValue(MessageIconProperty); }
            set { this.SetValue(MessageIconProperty, value); }
        }

        public static readonly DependencyProperty MessageIconProperty = DependencyProperty.Register(
         "MessageIcon", typeof(LuiIconsEnum), typeof(LuiMessageBox), new PropertyMetadata(LuiIconsEnum.lui_icon_none));
        #endregion
    }
}
