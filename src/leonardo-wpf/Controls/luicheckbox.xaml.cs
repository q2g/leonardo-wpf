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
                    MainCheckbox.Content = value;
                }
            }
        }
        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
         "Text", typeof(string), typeof(LuiCheckbox), new PropertyMetadata("", new PropertyChangedCallback(OnTextChanged)));


        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiCheckbox obj)
            {
                if (e.NewValue is string newvalue)
                {
                    obj.Text_Internal = newvalue;
                }
            }
        }
        #endregion

        #region IsChecked DP
        private bool isChecked;
        internal bool IsChecked_Internal
        {
            get { return isChecked; }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    MainCheckbox.IsChecked = value;
                }
            }
        }
        public bool IsChecked
        {
            get { return (bool)this.GetValue(IsCheckedProperty); }
            set { this.SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(
         "IsChecked", typeof(bool), typeof(LuiCheckbox), new PropertyMetadata(false, new PropertyChangedCallback(OnIsCheckedChanged)));


        private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiCheckbox obj)
            {
                if (e.NewValue is bool newvalue)
                {
                    obj.IsChecked_Internal = newvalue;
                }
            }
        }
        #endregion


    }
}
