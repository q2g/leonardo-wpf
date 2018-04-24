using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace leonardo.Converter
{
    public class TypeToStyleSelector : StyleSelector
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Style ItemStyle1 { get; set; }
        public Type ItemType1 { get; set; }
        public Style ItemStyle2 { get; set; }
        public Type ItemType2 { get; set; }
        public Style ItemStyle3 { get; set; }
        public Type ItemType3 { get; set; }
        public Style ItemStyle4 { get; set; }
        public Type ItemType4 { get; set; }
        public Style DefaultStyle { get; set; }


        public override Style SelectStyle(object item, DependencyObject container)
        {
            try
            {
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
                    if (item.GetType() == ItemType3)
                    {
                        return ItemStyle3;
                    }
                    if (item.GetType() == ItemType4)
                    {
                        return ItemStyle4;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return DefaultStyle;
        }
    }
}
