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
        public LuiMessageBox()
        {
            InitializeComponent();
        }

        public static bool ShowDialog(string text)
        {
            Window dialog = new LuiMessageBox()
            {
                WindowStyle = WindowStyle.None,
                AllowsTransparency = true,
                Background = new SolidColorBrush(Colors.Transparent),
                Owner = null,// Application.Current.MainWindow
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                MessageText = text
            };
            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Opacity = 0.5;
            }
            bool returnvalue = false;
            bool? result = dialog.ShowDialog();
            returnvalue = (result.HasValue && result.Value);

            if (Application.Current.MainWindow != null)
            {
                Application.Current.MainWindow.Opacity = 1;
            }

            return returnvalue;
        }

        public string MessageText { get; set; }

        private void LuiButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
