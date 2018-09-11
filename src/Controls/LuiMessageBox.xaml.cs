namespace leonardo.Controls
{
    #region Usings
    using leonardo.Resources;
    using NLog;
    using System;
    using System.Windows;
    using System.Windows.Interop;
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

        public static bool ShowDialog(string text, LuiIconsEnum messageIcon = LuiIconsEnum.lui_icon_none, IntPtr? ownerPtr = null, double height = -1, double width = -1)
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
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    MessageText = text
                };
                if (height != -1)
                    dialog.Height = height;
                if (width != -1)
                    dialog.Width = width;

                if (ownerPtr.HasValue)
                    new WindowInteropHelper(dialog).Owner = ownerPtr.Value;

                if (Application.Current != null && Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Opacity = 0.5;
                }

                bool? result = dialog.ShowDialog();
                returnvalue = (result.HasValue && result.Value);

                if (Application.Current != null && Application.Current.MainWindow != null)
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
