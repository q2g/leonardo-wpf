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
    /// Interaktionslogik für LuiSearch.xaml
    /// </summary>
    public partial class LuiSearch : UserControl
    {
        public LuiSearch()
        {
            InitializeComponent();
            maininput.InputTextChanged += Maininput_InputTextChanged;
        }

        private void Maininput_InputTextChanged(object sender, EventArgs e)
        {
            SearchText = maininput.InputText;
        }

        private void PalceHolder_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            maininput.TextBoxFocused=true;
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
         "Inverse", typeof(bool), typeof(LuiSearch), new PropertyMetadata(false, new PropertyChangedCallback(OnInverseChanged)));


        private static void OnInverseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiSearch obj)
            {
                if (e.NewValue is bool newvalue)
                {
                    obj.Inverse_Internal = newvalue;
                }
            }
        }

        private void SetColors()
        {
            maininput.Inverse = inverse;
            mainbutton.Inverse = inverse;
            if (inverse)
            {                
                maingrid.Background= LUIPalette.Brushes.GRAYSCALE40;
                mainbutton.LUIScheme = LUISchemeEnum.InvertedSearchbox;
                mainicon.Foreground = LUIPalette.Brushes.GRAYSCALE80;
                
            }
            else
            {
                maingrid.Background = new SolidColorBrush(Colors.Transparent);
                mainbutton.LUIScheme = LUISchemeEnum.Default;
                mainicon.Foreground = LUIPalette.Brushes.GRAYSCALE0;
            }
        }
        #endregion

        #region SearchText - DP
        private string searchText;
        internal string SearchText_Internal
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    maininput.InputText = value;
                }
            }
        }
        public string SearchText
        {
            get { return (string)this.GetValue(SearchTextProperty); }
            set { this.SetValue(SearchTextProperty, value); }
        }

        public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register(
         "SearchText", typeof(string), typeof(LuiSearch), new PropertyMetadata("", new PropertyChangedCallback(OnSearchTextChanged)));


        private static void OnSearchTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiSearch obj)
            {
                if (e.NewValue is string newvalue)
                {
                    obj.SearchText_Internal = newvalue;
                }
            }
        }
        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchText = maininput.InputText;
        }
        #endregion
    }
}
