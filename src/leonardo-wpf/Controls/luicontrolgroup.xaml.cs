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
    /// Interaktionslogik für LuiControlGroup.xaml
    /// </summary>
    [ContentProperty("Items")]
    public partial class LuiControlGroup : UserControl
    {
        #region Member
       
        #endregion
        public LuiControlGroup()
        {
            InitializeComponent();
            
        }


        public static readonly DependencyProperty ItemsSourceProperty =
       ItemsControl.ItemsSourceProperty.AddOwner(typeof(LuiControlGroup));


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
         "Rounded", typeof(bool), typeof(LuiControlGroup), new PropertyMetadata(false, new PropertyChangedCallback(OnRoundedChanged)));


        private static void OnRoundedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiControlGroup obj)
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
                    if (li[i] is IHasCornerRadius first)
                    {
                        if (rounded)
                        {
                            first.CornerRadius = new CornerRadius(14, 0, 0, 14);
                        }
                        else
                        {
                            first.CornerRadius = new CornerRadius(3, 0, 0, 3);
                        }
                    }
                }
                else if (i == li.Count-1)
                {
                    if (li[i] is IHasCornerRadius last)
                    {
                        if (rounded)
                        {
                            last.CornerRadius = new CornerRadius(0, 14, 14, 0);
                        }
                        else
                        {
                            last.CornerRadius = new CornerRadius(0, 3, 3, 0);
                        }
                    }
                }
                else
                {
                    if (li[i] is IHasCornerRadius between)
                    {

                        between.CornerRadius = new CornerRadius(0, 0, 0, 0);

                    }
                }
            }            
        }
        #endregion
    }
}
