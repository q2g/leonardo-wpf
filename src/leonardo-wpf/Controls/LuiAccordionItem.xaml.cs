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
    /// Interaktionslogik für LuiAccordionItem.xaml
    /// </summary>
    public partial class LuiAccordionItem : HeaderedContentControl
    {
        public LuiAccordionItem()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region IsExpanded - DP
        public bool IsExpanded
        {
            get { return (bool)this.GetValue(IsExpandedProperty); }
            set { this.SetValue(IsExpandedProperty, value); }
        }

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
         "IsExpanded", typeof(bool), typeof(LuiAccordionItem), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region Index - DP
        private int index;
        internal int Index_Internal
        {
            get { return index; }
            set
            {
                if (index!= value)
                {
                    index = value;
                }
            }
        }
        public int Index
        {
            get { return (int)this.GetValue(IndexProperty); }
            set { this.SetValue(IndexProperty, value); }
        }

        public static readonly DependencyProperty IndexProperty = DependencyProperty.Register(
         "Index", typeof(int), typeof(LuiAccordionItem), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnIndexChanged)));


        private static void OnIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiAccordionItem obj)
            {
                if (e.NewValue is int newvalue)
                {
                    obj.Index_Internal = newvalue;
                }
            }
        }
        #endregion



    }
}
