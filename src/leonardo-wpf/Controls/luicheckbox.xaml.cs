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
    /// Interaktionslogik für luicheckbox.xaml
    /// </summary>
    public partial class LuiCheckbox : UserControl
    {
        public LuiCheckbox()
        {
            InitializeComponent();
        }

        #region Inverse - DP
        private bool inverse;
        internal bool Inverse_Internal
        {
            get { return inverse; }
            set
            {
                if (inverse != value)
                {
                    inverse = value;
                    SetColors();
                }
            }
        }
        public bool Inverse
        {
            get { return (bool)this.GetValue(InverseProperty); }
            set { this.SetValue(InverseProperty, value); }
        }

        public static readonly DependencyProperty InverseProperty = DependencyProperty.Register(
         "Inverse", typeof(bool), typeof(LuiCheckbox), new PropertyMetadata(false, new PropertyChangedCallback(OnInverseChanged)));


        private static void OnInverseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiCheckbox obj)
            {
                if (e.NewValue is bool newvalue)
                {
                    obj.Inverse_Internal = newvalue;
                }
            }
        }

        private void SetColors()
        {
            if (inverse)
            {
               
            }
            else
            {
               
            }
        }
        #endregion

        #region Text - DP
        private string text;
        internal string Text_Internal
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;                 
                }
            }
        }
        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
         "InputText", typeof(string), typeof(LuiCheckbox), new PropertyMetadata("", new PropertyChangedCallback(OnInputTextChanged)));


        private static void OnInputTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiCheckbox obj)
            {
                if (e.NewValue is string newvalue)
                {
                    obj.Text_Internal = newvalue;
                }
            }
        }
        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        #endregion
    }


}
