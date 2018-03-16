using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// Interaktionslogik für LuiAccordion.xaml
    /// </summary>
    public partial class LuiAccordion : ItemsControl
    {
        public LuiAccordion()
        {
            InitializeComponent();
            
        }        

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            if (item is LuiAccordionItem accordionitem)
            {
                DependencyPropertyDescriptor
                .FromProperty(LuiAccordionItem.IsExpandedProperty, typeof(LuiAccordionItem))
                .AddValueChanged(accordionitem, IsExpandedChanged);
                return true;
            }
            return false;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            var retval = new LuiAccordionItem();

            DependencyPropertyDescriptor
             .FromProperty(LuiAccordionItem.IsExpandedProperty, typeof(LuiAccordionItem))
             .AddValueChanged(retval, IsExpandedChanged);         

            return retval;

        } 
        
        private void IsExpandedChanged(object sender, EventArgs e)
        {
            if (sender is LuiAccordionItem accitem)
            {
                if (accitem.IsExpanded == true)
                {
                    CollapseAllItems(accitem);
                }
            }
        }

        private void CollapseAllItems(LuiAccordionItem sender)
        {

            foreach (var item in Items)
            {
                if(sender is LuiAccordionItem accordionitem)
                if (item != accordionitem.DataContext)
                {
                        var  itemContainer = ItemContainerGenerator.ContainerFromItem(item) as LuiAccordionItem;
                    if (itemContainer!=null)
                    {
                            itemContainer.IsExpanded = false;
                    }
                }
            }

        }

        #region CollapseAllOnExpandSingle
        public bool CollapseAllOnExpandSingle
        {
            get { return (bool)this.GetValue(CollapseAllOnExpandSingleProperty); }
            set { this.SetValue(CollapseAllOnExpandSingleProperty, value); }
        }

        public static readonly DependencyProperty CollapseAllOnExpandSingleProperty = DependencyProperty.Register(
         "CollapseAllOnExpandSingle", typeof(bool), typeof(LuiAccordionItem), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

    }
}
