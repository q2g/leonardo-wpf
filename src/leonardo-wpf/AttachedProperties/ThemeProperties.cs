using leonardo.Controls;
using leonardo.Resources;
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

        #region Rounded AP
        public static bool GetRounded(DependencyObject obj)
        {
            return (bool)obj.GetValue(RoundedProperty);
        }

        public static void SetRounded(DependencyObject obj, bool value)
        {
            obj.SetValue(RoundedProperty, value);
        }

        public static readonly DependencyProperty RoundedProperty =
            DependencyProperty.RegisterAttached(
                "Rounded",
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

        #region ButtonScheme AP
        public static LUIButtonSchemeEnum GetButtonScheme(DependencyObject obj)
        {
            return (LUIButtonSchemeEnum)obj.GetValue(ButtonSchemeProperty);
        }

        public static void SetButtonScheme(DependencyObject obj, LUIButtonSchemeEnum value)
        {
            obj.SetValue(ButtonSchemeProperty, value);
        }

        public static readonly DependencyProperty ButtonSchemeProperty =
            DependencyProperty.RegisterAttached(
                "ButtonScheme",
                typeof(LUIButtonSchemeEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LUIButtonSchemeEnum.Default, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region IconLeft AP
        public static LUIiconsEnum GetIconLeft(DependencyObject obj)
        {
            return (LUIiconsEnum)obj.GetValue(IconLeftProperty);
        }

        public static void SetIconLeft(DependencyObject obj, LUIiconsEnum value)
        {
            obj.SetValue(IconLeftProperty, value);
        }

        public static readonly DependencyProperty IconLeftProperty =
            DependencyProperty.RegisterAttached(
                "IconLeft",
                typeof(LUIiconsEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LUIiconsEnum.lui_icon_none, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region IconRight AP
        public static LUIiconsEnum GetIconRight(DependencyObject obj)
        {
            return (LUIiconsEnum)obj.GetValue(IconRightProperty);
        }

        public static void SetIconRight(DependencyObject obj, LUIiconsEnum value)
        {
            obj.SetValue(IconRightProperty, value);
        }

        public static readonly DependencyProperty IconRightProperty =
            DependencyProperty.RegisterAttached(
                "IconRight",
                typeof(LUIiconsEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LUIiconsEnum.lui_icon_none, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ButtonSize AP
        public static LUIButtonSizeEnum GetButtonSize(DependencyObject obj)
        {
            return (LUIButtonSizeEnum)obj.GetValue(ButtonSizeProperty);
        }

        public static void SetButtonSize(DependencyObject obj, LUIButtonSizeEnum value)
        {
            obj.SetValue(ButtonSizeProperty, value);
        }

        public static readonly DependencyProperty ButtonSizeProperty =
            DependencyProperty.RegisterAttached(
                "ButtonSize",
                typeof(LUIButtonSizeEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LUIButtonSizeEnum.Default, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region CornerRadius AP
        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached(
                "CornerRadius",
                typeof(CornerRadius),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(new CornerRadius(3), FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region BorderThickness AP
        public static Thickness GetBorderThickness(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(BorderThicknessProperty);
        }

        public static void SetBorderThickness(DependencyObject obj, Thickness value)
        {
            obj.SetValue(BorderThicknessProperty, value);
        }

        public static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.RegisterAttached(
                "BorderThickness",
                typeof(Thickness),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(new Thickness(1), FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region LuiTextboxSize AP
        public static LUIInputSizeEnum GetLuiTextboxSize(DependencyObject obj)
        {
            return (LUIInputSizeEnum)obj.GetValue(LuiTextboxSizeProperty);
        }

        public static void SetLuiTextboxSize(DependencyObject obj, LUIInputSizeEnum value)
        {
            obj.SetValue(LuiTextboxSizeProperty, value);
        }

        public static readonly DependencyProperty LuiTextboxSizeProperty =
            DependencyProperty.RegisterAttached(
                "LuiTextboxSize",
                typeof(LUIInputSizeEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LUIInputSizeEnum.Default, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region LuiFontSize AP
        public static LUIFontSizeEnum GetLuiFontSize(DependencyObject obj)
        {
            return (LUIFontSizeEnum)obj.GetValue(LuiFontSizeProperty);
        }

        public static void SetLuiFontSize(DependencyObject obj, LUIFontSizeEnum value)
        {
            obj.SetValue(LuiFontSizeProperty, value);
        }

        public static readonly DependencyProperty LuiFontSizeProperty =
            DependencyProperty.RegisterAttached(
                "LuiFontSize",
                typeof(LUIFontSizeEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LUIFontSizeEnum.Normal, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region LabelTextAttached AP Only used in Combobox, because can't get the visibility-trigger for the Label working right
        public static string GetLabelTextAttached(DependencyObject obj)
        {
            return (string)obj.GetValue(LabelTextAttachedProperty);
        }

        public static void SetLabelTextAttached(DependencyObject obj, string value)
        {
            obj.SetValue(LabelTextAttachedProperty, value);
        }

        public static readonly DependencyProperty LabelTextAttachedProperty =
            DependencyProperty.RegisterAttached(
                "LabelTextAttached",
                typeof(string),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region DisableCheckedStyle AP
        public static bool GetDisableCheckedStyle(DependencyObject obj)
        {
            return (bool)obj.GetValue(DisableCheckedStyleProperty);
        }

        public static void SetDisableCheckedStyle(DependencyObject obj, bool value)
        {
            obj.SetValue(DisableCheckedStyleProperty, value);
        }

        public static readonly DependencyProperty DisableCheckedStyleProperty =
            DependencyProperty.RegisterAttached(
                "DisableCheckedStyle",
                typeof(bool),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region LightCheckedStyle AP
        public static bool GetLightCheckedStyle(DependencyObject obj)
        {
            return (bool)obj.GetValue(LightCheckedStyleProperty);
        }

        public static void SetLightCheckedStyle(DependencyObject obj, bool value)
        {
            obj.SetValue(LightCheckedStyleProperty, value);
        }

        public static readonly DependencyProperty LightCheckedStyleProperty =
            DependencyProperty.RegisterAttached(
                "LightCheckedStyle",
                typeof(bool),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
        #endregion
    }

}
