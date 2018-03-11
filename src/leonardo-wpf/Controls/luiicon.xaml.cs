using leonardo.Resources;
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
    /// Interaktionslogik für LuiIcon.xaml
    /// </summary>
    public partial class LuiIcon : UserControl
    {
        private const LUIiconsEnum DEFAULT = LUIiconsEnum.lui_icon_table;
        public LuiIcon()
        {
            InitializeComponent();
            mainText.Text = DEFAULT.GetIconText();

        }     
       

        #region Icon - DP
        public LUIiconsEnum Icon
        {
            get { return (LUIiconsEnum)this.GetValue(IconProperty); }
            set { this.SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
         "Icon", typeof(LUIiconsEnum), typeof(LuiIcon), new FrameworkPropertyMetadata(DEFAULT, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnIconChanged)));


        private static void OnIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiIcon obj)
            {
                if (e.NewValue is LUIiconsEnum newvalue)
                {
                    obj.Icon_Internal = newvalue;
                }
            }
        }

        private LUIiconsEnum icon=DEFAULT;
        internal LUIiconsEnum Icon_Internal
        {
            get { return icon; }
            set
            {                
                if (icon != value || DEFAULT.GetIconText().Equals(mainText.Text))
                {
                    icon = value;
                    mainText.Text = value.GetIconText();
                }
            }
        }
        #endregion

        #region IconSize - DP
        private LUIFontSizeEnum iconsize = LUIFontSizeEnum.Normal;
        internal LUIFontSizeEnum IconSize_Internal
        {
            get { return iconsize; }
            set
            {
                if (iconsize != value)
                {
                    iconsize = value;
                    mainText.FontSize = value.GetFontSize();


                }
            }
        }
        public LUIFontSizeEnum IconSize
        {
            get { return (LUIFontSizeEnum)this.GetValue(IconSizeProperty); }
            set { this.SetValue(IconSizeProperty, value); }
        }

        public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register(
         "IconSize", typeof(LUIFontSizeEnum), typeof(LuiIcon), new FrameworkPropertyMetadata(LUIFontSizeEnum.Normal, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnIconSizeChanged)));


        private static void OnIconSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiIcon obj)
            {
                if (e.NewValue is LUIFontSizeEnum newvalue)
                {
                    obj.IconSize_Internal = newvalue;
                }
            }
        }

       
        #endregion

        #region CornerRadius - DP
        private CornerRadius cornerRadius = new CornerRadius(1.01);
        internal CornerRadius CornerRadius_Internal
        {
            get { return cornerRadius; }
            set
            {
                if (cornerRadius != value)
                {
                    cornerRadius = value;

                    SetCornerRadius();
                }
            }
        }
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)this.GetValue(CornerRadiusProperty); }
            set { this.SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
         "CornerRadius", typeof(CornerRadius), typeof(LuiIcon), new FrameworkPropertyMetadata(new CornerRadius(1.01), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnCornerRadiusChanged)));


        private static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiIcon obj)
            {
                if (e.NewValue is CornerRadius newvalue)
                {
                    obj.CornerRadius_Internal = newvalue;
                }
            }
        }


        private void SetCornerRadius()
        {
            mainText.Resources.Clear();
            Style style = new Style(typeof(Border));
            style.Setters.Add(new Setter(Border.CornerRadiusProperty, cornerRadius));
            mainText.Resources.Add(typeof(Border), style);
        }
        #endregion
    }
}
