using leonardo.AttachedProperties;
using leonardo.Resources;
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
    /// Interaktionslogik für LuiButtonGroup.xaml
    /// </summary>
    [ContentProperty("Items")]
    public partial class LuiButtonGroup : UserControl
    {
        #region Member
       
        #endregion
        public LuiButtonGroup()
        {
            InitializeComponent();            
        }


        public static readonly DependencyProperty ItemsSourceProperty =
       ItemsControl.ItemsSourceProperty.AddOwner(typeof(LuiButtonGroup));


        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public ItemCollection Items
        {
            get { return _itemsControl.Items; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetCornerRadius();            

            foreach (object item in Items)
            {
                if (item is LuiToggleButton tbutton)
                {                    
                    tbutton.Click += (s,ea)=> { CheckThis(tbutton); };
                }
            }
        }

        private void control_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            foreach (object item in Items)
            {
                if (item is LuiToggleButton tbutton)
                {
                    tbutton.Width = ActualWidth / Items.Count;                   
                }
            }
        }

        #region Rounded - DP
        private bool rounded;
        internal bool Rounded_Internal
        {
            get { return rounded; }
            set
            {
                if (rounded != value)
                {
                    rounded = value;

                    SetCornerRadius();
                }
            }
        }
        public bool Rounded
        {
            get { return (bool)this.GetValue(RoundedProperty); }
            set { this.SetValue(RoundedProperty, value); }
        }

        public static readonly DependencyProperty RoundedProperty = DependencyProperty.Register(
         "Rounded", typeof(bool), typeof(LuiButtonGroup), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnRoundedChanged)));


        private static void OnRoundedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButtonGroup obj)
            {
                if (e.NewValue is bool newvalue)
                {
                    obj.Rounded_Internal = newvalue;
                }
            }
        }

        private void SetCornerRadius()
        {
            List<object> li = new List<object>();

            foreach (object item in Items)
            {
                li.Add(item);
            }
            for (int i = 0; i < li.Count; i++)
            {
                if (i == 0)
                {
                    if (li[i] is FrameworkElement first)
                    {
                        if (rounded)
                        {
                            first.SetValue(ThemeProperties.CornerRadiusProperty, new CornerRadius(14, 0, 0, 14));
                        }
                        else
                        {
                            first.SetValue(ThemeProperties.CornerRadiusProperty, new CornerRadius(3, 0, 0, 3));
                        }
                    }
                }
                else if (i == li.Count-1)
                {
                    if (li[i] is FrameworkElement last)
                    {
                        if (rounded)
                        {
                            last.SetValue(ThemeProperties.CornerRadiusProperty, new CornerRadius(0, 14, 14, 0));
                        }
                        else
                        {
                            last.SetValue(ThemeProperties.CornerRadiusProperty, new CornerRadius(0, 3, 3, 0));
                        }
                    }
                }
                else
                {
                    if (li[i] is FrameworkElement between)
                    {

                        between.SetValue(ThemeProperties.CornerRadiusProperty, new CornerRadius(0, 0, 0, 0));

                    }
                }
            }            
        }
        #endregion

        #region Functions
        private void CheckThis(LuiToggleButton toCheck)
        {
            foreach (object item in Items)
            {
                if (item is LuiToggleButton tbutton)
                {
                    tbutton.IsChecked = tbutton == toCheck;
                }
            }
        }
        #endregion
    }
}
