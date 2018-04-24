using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace leonardowpf_Demo
{
    public class TypeToStyleSelector : StyleSelector
    {
        public Style ItemStyle1 { get; set; }
        public Type ItemType1 { get; set; }
        public Style ItemStyle2 { get; set; }
        public Type ItemType2 { get; set; }
        public Style DefaultStyle { get; set; }


        public override Style SelectStyle(object item, DependencyObject container)
        {
            //var key =  item.GetType().ToString();
            //if (container is FrameworkElement ele)
            //{
            //    return (Style)ele.FindResource(key);
            //}

            if (item != null)
            {
                if (item.GetType() == ItemType1)
                {
                    return ItemStyle1;
                }
                if (item.GetType() == ItemType2)
                {
                    return ItemStyle2;
                }
            }
            return DefaultStyle;
        }
    }
}
