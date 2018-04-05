using leonardo.AttachedProperties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace leonardo.Controls
{
    /// <summary>
    /// Interaktionslogik für LuiCombobox.xaml
    /// </summary>

    public partial class LuiCombobox : ComboBox
    {
        public LuiCombobox()
        {
            InitializeComponent();
        }

        #region LabelText - DP  
        private string labelText;
        internal string LabelText_Internal
        {
            get { return labelText; }
            set
            {
                if (labelText != value)
                {
                    labelText = value;
                    this.SetValue(ThemeProperties.LabelTextAttachedProperty, labelText);
                }
            }
        }
        public string LabelText
        {
            get { return (string)this.GetValue(LabelTextProperty); }
            set { this.SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
         "LabelText", typeof(string), typeof(LuiCombobox), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnLabelTextChanged)));


        private static void OnLabelTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiCombobox obj)
            {
                if (e.NewValue is string newvalue)
                {
                    obj.LabelText_Internal = newvalue;
                }
            }
        }
        #endregion
    }
}
