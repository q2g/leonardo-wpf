using leonardo.AttachedProperties;
using leonardo.Resources;
using NLog;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();

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
            try
            {
                SetCornerRadius();

                foreach (object item in Items)
                {
                    if (item is LuiToggleButton tbutton)
                    {
                        tbutton.Click += (s, ea) => { CheckThis(tbutton); };
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void control_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                foreach (object item in Items)
                {
                    if (item is LuiToggleButton tbutton)
                    {
                        tbutton.Width = ActualWidth / Items.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
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
            try
            {
                if (d is LuiButtonGroup obj)
                {
                    if (e.NewValue is bool newvalue)
                    {
                        obj.Rounded_Internal = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
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
                else if (i == li.Count - 1)
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

        #region SelectedIndex DP
        private int selectedIndex = -1;
        internal int SelectedIndex_Internal
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    int counter = 0;
                    foreach (object item in Items)
                    {
                        if (item is LuiToggleButton tbutton)
                        {
                            if (counter == selectedIndex)
                            {
                                CheckThis(tbutton);
                            }
                        }
                        counter++;
                    }
                }
            }
        }
        public int SelectedIndex
        {
            get { return (int)this.GetValue(SelectedIndexProperty); }
            set { this.SetValue(SelectedIndexProperty, value); }
        }

        public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register(
         "SelectedIndex", typeof(int), typeof(LuiButtonGroup), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnSelectedIndexChanged)));


        private static void OnSelectedIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiButtonGroup obj)
                {
                    if (e.NewValue is int newvalue)
                    {
                        obj.SelectedIndex_Internal = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void CheckThis(LuiToggleButton toCheck)
        {
            int index = 0;
            foreach (object item in Items)
            {
                if (item is LuiToggleButton tbutton)
                {
                    if (tbutton == toCheck)
                    {
                        SelectedIndex = index;
                    }
                    tbutton.IsChecked = tbutton == toCheck;

                }
                index++;
            }
        }
        #endregion
    }
}
