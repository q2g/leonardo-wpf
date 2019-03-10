namespace leonardo.AttachedProperties
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using leonardo.Controls;
    using leonardo.Resources;
    #endregion

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
        public static LuiButtonSchemeEnum GetButtonScheme(DependencyObject obj)
        {
            return (LuiButtonSchemeEnum)obj.GetValue(ButtonSchemeProperty);
        }

        public static void SetButtonScheme(DependencyObject obj, LuiButtonSchemeEnum value)
        {
            obj.SetValue(ButtonSchemeProperty, value);
        }

        public static readonly DependencyProperty ButtonSchemeProperty =
            DependencyProperty.RegisterAttached(
                "ButtonScheme",
                typeof(LuiButtonSchemeEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LuiButtonSchemeEnum.Default, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region IconLeft AP
        public static LuiIconsEnum GetIconLeft(DependencyObject obj)
        {
            return (LuiIconsEnum)obj.GetValue(IconLeftProperty);
        }

        public static void SetIconLeft(DependencyObject obj, LuiIconsEnum value)
        {
            obj.SetValue(IconLeftProperty, value);
        }

        public static readonly DependencyProperty IconLeftProperty =
            DependencyProperty.RegisterAttached(
                "IconLeft",
                typeof(LuiIconsEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LuiIconsEnum.lui_icon_none, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region IconRight AP
        public static LuiIconsEnum GetIconRight(DependencyObject obj)
        {
            return (LuiIconsEnum)obj.GetValue(IconRightProperty);
        }

        public static void SetIconRight(DependencyObject obj, LuiIconsEnum value)
        {
            obj.SetValue(IconRightProperty, value);
        }

        public static readonly DependencyProperty IconRightProperty =
            DependencyProperty.RegisterAttached(
                "IconRight",
                typeof(LuiIconsEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LuiIconsEnum.lui_icon_none, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region ButtonSize AP
        public static LuiButtonSizeEnum GetButtonSize(DependencyObject obj)
        {
            return (LuiButtonSizeEnum)obj.GetValue(ButtonSizeProperty);
        }

        public static void SetButtonSize(DependencyObject obj, LuiButtonSizeEnum value)
        {
            obj.SetValue(ButtonSizeProperty, value);
        }

        public static readonly DependencyProperty ButtonSizeProperty =
            DependencyProperty.RegisterAttached(
                "ButtonSize",
                typeof(LuiButtonSizeEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LuiButtonSizeEnum.Default, FrameworkPropertyMetadataOptions.Inherits));
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

        #region ButtonLeftIconMargin AP

        public static Thickness GetButtonLeftIconMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(ButtonLeftIconMarginProperty);
        }

        public static void SetButtonLeftIconMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(ButtonLeftIconMarginProperty, value);
        }

        public static readonly DependencyProperty ButtonLeftIconMarginProperty =
            DependencyProperty.RegisterAttached(
                "ButtonLeftIconMargin",
                typeof(Thickness),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(new Thickness(10, 0, 0, 0), FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region LuiTextboxSize AP
        public static LuiInputSizeEnum GetLuiTextboxSize(DependencyObject obj)
        {
            return (LuiInputSizeEnum)obj.GetValue(LuiTextboxSizeProperty);
        }

        public static void SetLuiTextboxSize(DependencyObject obj, LuiInputSizeEnum value)
        {
            obj.SetValue(LuiTextboxSizeProperty, value);
        }

        public static readonly DependencyProperty LuiTextboxSizeProperty =
            DependencyProperty.RegisterAttached(
                "LuiTextboxSize",
                typeof(LuiInputSizeEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LuiInputSizeEnum.Default, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region LuiFontSize AP
        public static LuiFontSizeEnum GetLuiFontSize(DependencyObject obj)
        {
            return (LuiFontSizeEnum)obj.GetValue(LuiFontSizeProperty);
        }

        public static void SetLuiFontSize(DependencyObject obj, LuiFontSizeEnum value)
        {
            obj.SetValue(LuiFontSizeProperty, value);
        }

        public static readonly DependencyProperty LuiFontSizeProperty =
            DependencyProperty.RegisterAttached(
                "LuiFontSize",
                typeof(LuiFontSizeEnum),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(LuiFontSizeEnum.Normal, FrameworkPropertyMetadataOptions.Inherits));
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

        #region Itemheight AP
        public const double DEFAULTITEMHEIGHT = 39.0;
        public static double GetItemheight(DependencyObject obj)
        {
            return (double)obj.GetValue(ItemheightProperty);
        }

        public static void SetItemheight(DependencyObject obj, double value)
        {
            obj.SetValue(ItemheightProperty, value);
        }

        public static readonly DependencyProperty ItemheightProperty =
            DependencyProperty.RegisterAttached(
                "Itemheight",
                typeof(double),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(DEFAULTITEMHEIGHT, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region InputLabelForegroundWhite AP
        public static bool GetInputLabelForegroundWhite(DependencyObject obj)
        {
            return (bool)obj.GetValue(InputLabelForegroundWhiteProperty);
        }

        public static void SetInputLabelForegroundWhite(DependencyObject obj, bool value)
        {
            obj.SetValue(InputLabelForegroundWhiteProperty, value);
        }

        public static readonly DependencyProperty InputLabelForegroundWhiteProperty =
            DependencyProperty.RegisterAttached(
                "InputLabelForegroundWhite",
                typeof(bool),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
        #endregion

        #region Hwnd AP
        public static int GetHwnd(DependencyObject obj)
        {
            return (int)obj.GetValue(HwndProperty);
        }

        public static void SetHwnd(DependencyObject obj, int value)
        {
            obj.SetValue(HwndProperty, value);
        }

        public static readonly DependencyProperty HwndProperty =
            DependencyProperty.RegisterAttached(
                "Hwnd",
                typeof(int),
                typeof(ThemeProperties),
                new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.Inherits));
        #endregion
    }
}
