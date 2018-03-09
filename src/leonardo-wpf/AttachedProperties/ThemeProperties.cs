using leonardo.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace leonardo.AttachedProperties
{  
    public static class ThemeProperties
    {       
        public static bool InvertedBrush(DependencyObject obj)
        {
            return (bool)obj.GetValue(InvertedProperty);
        }

        public static void SetInverted(DependencyObject obj, bool value)
        {
            obj.SetValue(InvertedProperty, value);
        }

        public static readonly DependencyProperty InvertedProperty =
            DependencyProperty.RegisterAttached(
                "Inverted",
                typeof(bool),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
    }
}
