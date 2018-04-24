using leonardo.AttachedProperties;
using leonardo.Resources;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaktionslogik für LuiToggleButton.xaml
    /// </summary>
    public partial class LuiToggleButton : ToggleButton
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public LuiToggleButton()
        {
            InitializeComponent();
        }
        private LUIiconsEnum savedLeftIcon { get; set; }

        #region CheckedIcon - DP
        public LUIiconsEnum CheckedIcon
        {
            get { return (LUIiconsEnum)this.GetValue(CheckedIconProperty); }
            set { this.SetValue(CheckedIconProperty, value); }
        }

        public static readonly DependencyProperty CheckedIconProperty = DependencyProperty.Register(
         "CheckedIcon", typeof(LUIiconsEnum), typeof(LuiToggleButton), new FrameworkPropertyMetadata(LUIiconsEnum.lui_icon_none, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is LuiToggleButton tbutton)
                {
                    if (CheckedIcon != LUIiconsEnum.lui_icon_none)
                    {
                        savedLeftIcon = (LUIiconsEnum)tbutton.GetValue(ThemeProperties.IconLeftProperty);
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
                    if (CheckedIcon != LUIiconsEnum.lui_icon_none)
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
    }
}
