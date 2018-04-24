using leonardo.Resources;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace leonardo.Controls
{
    /// <summary>
    /// Interaction logic for LuiMessageBox.xaml
    /// </summary>
    public partial class LuiMessageBox : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public LuiMessageBox()
        {
            InitializeComponent();
        }

        public static bool ShowDialog(string text, LUIiconsEnum messageIcon = LUIiconsEnum.lui_icon_none)
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
                    Owner = Application.Current.MainWindow,
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
        public LUIiconsEnum MessageIcon
        {
            get { return (LUIiconsEnum)this.GetValue(MessageIconProperty); }
            set { this.SetValue(MessageIconProperty, value); }
        }

        public static readonly DependencyProperty MessageIconProperty = DependencyProperty.Register(
         "MessageIcon", typeof(LUIiconsEnum), typeof(LuiMessageBox), new PropertyMetadata(LUIiconsEnum.lui_icon_none));
        #endregion
    }
}
