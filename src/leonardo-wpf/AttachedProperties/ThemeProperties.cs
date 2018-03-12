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
        #region Inverted AP
        public static bool GetInverted(DependencyObject obj)
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
        #endregion

        #region Gradient AP
        public static bool GetGradient(DependencyObject obj)
        {
            return (bool)obj.GetValue(GradientProperty);
        }

        public static void SetGradient(DependencyObject obj, bool value)
        {
            obj.SetValue(GradientProperty, value);
        }

        public static readonly DependencyProperty GradientProperty =
            DependencyProperty.RegisterAttached(
                "Gradient",
                typeof(bool),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
        #endregion
    }
}
