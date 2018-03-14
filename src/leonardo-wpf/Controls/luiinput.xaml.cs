using leonardo.Resources;
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
    /// Interaktionslogik für LuiInput.xaml
    /// </summary>
    public partial class LuiInput : TextBox
    {
        public LuiInput()
        {
            InitializeComponent();
        }

        #region LabelText - DP       
        public string LabelText
        {
            get { return (string)this.GetValue(LabelTextProperty); }
            set { this.SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
         "LabelText", typeof(string), typeof(LuiInput), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region HintText - DP       
        public string HintText
        {
            get { return (string)this.GetValue(HintTextProperty); }
            set { this.SetValue(HintTextProperty, value); }
        }

        public static readonly DependencyProperty HintTextProperty = DependencyProperty.Register(
         "HintText", typeof(string), typeof(LuiInput), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion


        #region LUIInputSize - DP       
        public LUIInputSizeEnum LUIInputSize
        {
            get { return (LUIInputSizeEnum)this.GetValue(LUIInputSizeProperty); }
            set { this.SetValue(LUIInputSizeProperty, value); }
        }

        public static readonly DependencyProperty LUIInputSizeProperty = DependencyProperty.Register(
         "LUIInputSize", typeof(LUIInputSizeEnum), typeof(LuiInput), new FrameworkPropertyMetadata(LUIInputSizeEnum.Default, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));       
        #endregion

    }
}
