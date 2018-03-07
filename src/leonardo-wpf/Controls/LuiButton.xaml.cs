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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace leonardo.Controls
{
    /// <summary>
    /// Interaktionslogik für LuiButton.xaml
    /// </summary>
    public partial class LuiButton : UserControl, IHasCornerRadius
    {
        private readonly CornerRadius ROUNDED = new CornerRadius(16);
        private readonly CornerRadius NOT_ROUNDED = new CornerRadius(3);
        #region Members
        private Border mainBorder;
        private LuiIcon iconRight;
        private LuiIcon iconLeft;
        private TextBlock contentTextBlock;
        private LUIiconsEnum buttonIconRight;
        private LUIiconsEnum buttonIconLeft;
        private String buttonContentText;
        private Button mainButton;
        private ICommand buttonCommand;
        private object buttonCommandParameter;
        #endregion
        #region ctor
        public LuiButton()
        {
            InitializeComponent();
        }
        #endregion
        #region Properrties
        internal LUIiconsEnum ButtonIconRight
        {
            get { return buttonIconRight; }
            set
            {
                if (buttonIconRight != value)
                {
                    buttonIconRight = value;
                    if (iconRight != null)
                    {
                        iconRight.Icon = value;
                    }
                }
            }
        }
        internal LUIiconsEnum ButtonIconLeft
        {
            get { return buttonIconLeft; }
            set
            {
                if (buttonIconLeft != value)
                {
                    buttonIconLeft = value;
                    if (iconLeft != null)
                    {
                        iconLeft.Icon = value;
                    }
                }
            }
        }
        internal String ButtonContentText
        {
            get { return buttonContentText; }
            set
            {
                if (buttonContentText != value)
                {
                    buttonContentText = value;
                    if (contentTextBlock != null)
                    {
                        contentTextBlock.Text = value;
                    }
                }
            }
        }
        internal ICommand ButtonCommand
        {
            get { return buttonCommand; }
            set
            {
                if (buttonCommand != value)
                {
                    buttonCommand = value;
                    if (mainButton != null)
                    {
                        mainButton.Command = value;
                    }
                }
            }
        }
        internal object ButtonCommandParameter
        {
            get { return buttonCommandParameter; }
            set
            {
                if (buttonCommandParameter != value)
                {
                    buttonCommandParameter = value;
                    if (mainButton != null)
                    {
                        mainButton.CommandParameter = value;
                    }
                }
            }
        }
        #endregion
        #region overrides
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // Code to get the Template parts as instance member            
            if (GetTemplateChild("MainButton") is Button button)
            {
                mainButton = button;
                mainButton.Command = Command;
                mainButton.CommandParameter = CommandParameter;

                //Zu diesem Zeitpunkt ist zwar das Template des Buttons geladen, nicht aber alle in dessen Styles verwendeten Controls.
                //Diese sind zum Zeitpunkt Button_Loaded geladen und können im Handler ausgelesen werden.
                mainButton.Loaded += MainButton_Loaded;

            }
        }

        private void MainButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (mainButton.Template.FindName("PART_Border", mainButton) is Border border)
            {
                mainBorder = border;
                SetCornerRadius();
                mainBorder.BorderBrush = LUIPalette.GRAYSCALE90;               
                SetButtonSize();
                SetBorderThicknes();


            }
            if (mainButton.Template.FindName("PART_IconRight", mainButton) is LuiIcon icon)
            {
                iconRight = icon;
                iconRight.Icon = IconRight;
            }
            if (mainButton.Template.FindName("PART_IconLeft", mainButton) is LuiIcon iconleft)
            {
                iconLeft = iconleft;
                iconLeft.Icon = IconLeft;
            }

            if (mainButton.Template.FindName("PART_Text", mainButton) is TextBlock contenttextblock)
            {
                contentTextBlock = contenttextblock;
                contentTextBlock.Text = ButtonText;
            }
            SetColors();


        }
        #endregion
        #region ButtonText - DP
        public string ButtonText
        {
            get { return (string)this.GetValue(ButtonTextProperty); }
            set { this.SetValue(ButtonTextProperty, value); }
        }

        public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register(
         "ButtonText", typeof(string), typeof(LuiButton), new PropertyMetadata("", new PropertyChangedCallback(OnButtonTextChanged)));


        private static void OnButtonTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is string newvalue)
                {
                    obj.ButtonContentText = newvalue;
                }
            }
        }
        #endregion

        #region IconRight - DP
        public LUIiconsEnum IconRight
        {
            get { return (LUIiconsEnum)this.GetValue(IconRightProperty); }
            set { this.SetValue(IconRightProperty, value); }
        }

        public static readonly DependencyProperty IconRightProperty = DependencyProperty.Register(
         "IconRight", typeof(LUIiconsEnum), typeof(LuiButton), new PropertyMetadata(LUIiconsEnum.lui_icon_none, new PropertyChangedCallback(OnIconRightChanged)));


        private static void OnIconRightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is LUIiconsEnum newvalue)
                {
                    obj.ButtonIconRight = newvalue;
                }
            }
        }
        #endregion

        #region IconLeft - DP
        public LUIiconsEnum IconLeft
        {
            get { return (LUIiconsEnum)this.GetValue(IconLeftProperty); }
            set { this.SetValue(IconLeftProperty, value); }
        }

        public static readonly DependencyProperty IconLeftProperty = DependencyProperty.Register(
         "IconLeft", typeof(LUIiconsEnum), typeof(LuiButton), new PropertyMetadata(LUIiconsEnum.lui_icon_none, new PropertyChangedCallback(OnIconLeftChanged)));


        private static void OnIconLeftChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is LUIiconsEnum newvalue)
                {
                    obj.ButtonIconLeft = newvalue;
                }
            }
        }
        #endregion

        #region Command - DP
        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
         "Command", typeof(ICommand), typeof(LuiButton), new PropertyMetadata(null, new PropertyChangedCallback(OnCommandChanged)));


        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is ICommand newvalue)
                {
                    obj.ButtonCommand = newvalue;
                }
            }
        }
        #endregion

        #region CommandParameter - DP
        public object CommandParameter
        {
            get { return (object)this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
         "CommandParameter", typeof(object), typeof(LuiButton), new PropertyMetadata(null, new PropertyChangedCallback(OnCommandParameterChanged)));


        private static void OnCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is object newvalue)
                {
                    obj.ButtonCommandParameter = newvalue;
                }
            }
        }
        #endregion

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
         "Rounded", typeof(bool), typeof(LuiButton), new PropertyMetadata(false, new PropertyChangedCallback(OnRoundedChanged)));


        private static void OnRoundedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is bool newvalue)
                {
                    obj.Rounded_Internal = newvalue;
                }
            }
        }

        private void SetCornerRadius()
        {
            if (mainBorder != null)
            {
                if (CornerRadius.BottomLeft == 1.11 && CornerRadius.BottomRight == 1.11 && CornerRadius.TopLeft == 1.11 && CornerRadius.TopRight == 1.11)
                {
                    if (rounded)
                    {
                        mainBorder.CornerRadius = ROUNDED;
                    }
                    else
                    {
                        mainBorder.CornerRadius = NOT_ROUNDED;
                    }
                }
                else
                {
                    mainBorder.CornerRadius = CornerRadius;
                }
            }
        }
        #endregion

        #region Inverse - DP
        private bool inverse;
        internal bool Inverse_Internal
        {
            get { return inverse; }
            set
            {
                if (inverse != value)
                {
                    inverse = value;

                    if (mainBorder != null)
                    {
                        SetColors();
                    }
                }
            }
        }
        public bool Inverse
        {
            get { return (bool)this.GetValue(InverseProperty); }
            set { this.SetValue(InverseProperty, value); }
        }

        public static readonly DependencyProperty InverseProperty = DependencyProperty.Register(
         "Inverse", typeof(bool), typeof(LuiButton), new PropertyMetadata(false, new PropertyChangedCallback(OnInverseChanged)));


        private static void OnInverseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is bool newvalue)
                {
                    obj.Inverse_Internal = newvalue;
                }
            }
        }
        #endregion

        #region LUIScheme - DP
        private LUISchemeEnum scheme;
        internal LUISchemeEnum LUIScheme_Internal
        {
            get { return scheme; }
            set
            {
                if (scheme != value)
                {
                    scheme = value;
                    SetColors();
                }
            }
        }
        public LUISchemeEnum LUIScheme
        {
            get { return (LUISchemeEnum)this.GetValue(LUISchemeProperty); }
            set { this.SetValue(LUISchemeProperty, value); }
        }

        public static readonly DependencyProperty LUISchemeProperty = DependencyProperty.Register(
         "LUIScheme", typeof(LUISchemeEnum), typeof(LuiButton), new PropertyMetadata(LUISchemeEnum.Default, new PropertyChangedCallback(OnLUISchemeChanged)));


        private static void OnLUISchemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is LUISchemeEnum newvalue)
                {
                    obj.LUIScheme_Internal = newvalue;
                }
            }
        }
        #endregion

        private void SetColors()
        {
            if (mainBorder != null)
            {
                if (iconLeft != null)
                {
                    iconLeft.Foreground = LUIPalette.GRAYSCALE100;
                }
                if (iconRight != null)
                {
                    iconRight.Foreground = LUIPalette.GRAYSCALE100;
                }
                if (contentTextBlock != null)
                {
                    contentTextBlock.Foreground = LUIPalette.GRAYSCALE100;
                }
                switch (scheme)
                {
                    case LUISchemeEnum.Info:
                        mainBorder.Background = LUIPalette.BLUE;
                        mainBorder.BorderBrush = LUIPalette.BLUE;
                        break;
                    case LUISchemeEnum.InvertedSearchbox:
                        mainBorder.Background = LUIPalette.GRAYSCALE40;
                        mainBorder.BorderBrush = LUIPalette.GRAYSCALE40;
                        break;
                    case LUISchemeEnum.Error:
                        mainBorder.Background = LUIPalette.RED;
                        mainBorder.BorderBrush = LUIPalette.RED;
                        break;
                    case LUISchemeEnum.Warning:
                        mainBorder.Background = LUIPalette.ORANGE;
                        mainBorder.BorderBrush = LUIPalette.ORANGE;
                        break;
                    case LUISchemeEnum.Success:
                        mainBorder.Background = LUIPalette.GREEN;
                        mainBorder.BorderBrush = LUIPalette.GREEN;
                        break;
                    default:
                    case LUISchemeEnum.Default:
                    case LUISchemeEnum.Toolbar:
                        if (inverse)
                        {
                            mainBorder.Background = LUIPalette.GRAYSCALE30;
                            mainBorder.BorderBrush = LUIPalette.GRAYSCALE40;


                            if (iconLeft != null)
                            {
                                iconLeft.Foreground = LUIPalette.GRAYSCALE100;
                            }
                            if (iconRight != null)
                            {
                                iconRight.Foreground = LUIPalette.GRAYSCALE100;
                            }
                            if (contentTextBlock != null)
                            {
                                contentTextBlock.Foreground = LUIPalette.GRAYSCALE100;
                            }
                        }
                        else
                        {
                            mainBorder.Background = LUIPalette.GRAYSCALE100;
                            mainBorder.BorderBrush = LUIPalette.GRAYSCALE80;

                            if (iconLeft != null)
                            {
                                iconLeft.Foreground = LUIPalette.GRAYSCALE28;
                            }
                            if (iconRight != null)
                            {
                                iconRight.Foreground = LUIPalette.GRAYSCALE28;
                            }
                            if (contentTextBlock != null)
                            {
                                contentTextBlock.Foreground = LUIPalette.GRAYSCALE28;
                            }
                        }
                        break;
                }
            }
        }

        private void MainButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mainBorder != null)
            {
                mainBorder.BorderBrush = LUIPalette.BLUE;
            }
            if (inverse)
            {
                if (mainBorder != null)
                {
                    mainBorder.Background = LUIPalette.GRAYSCALE5;
                }
                if (iconLeft != null)
                {
                    iconLeft.Foreground = LUIPalette.GRAYSCALE100;
                }
                if (iconRight != null)
                {
                    iconRight.Foreground = LUIPalette.GRAYSCALE100;
                }
                if (contentTextBlock != null)
                {
                    contentTextBlock.Foreground = LUIPalette.GRAYSCALE100;
                }
            }
            else
            {
                if (mainBorder != null)
                {
                    mainBorder.Background = LUIPalette.GRAYSCALE30;
                }
                if (iconLeft != null)
                {
                    iconLeft.Foreground = LUIPalette.GRAYSCALE100;
                }
                if (iconRight != null)
                {
                    iconRight.Foreground = LUIPalette.GRAYSCALE100;
                }
                if (contentTextBlock != null)
                {
                    contentTextBlock.Foreground = LUIPalette.GRAYSCALE100;
                }
            }
        }

        private void MainButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SetColors();
        }

        private void MainButton_LostFocus(object sender, RoutedEventArgs e)
        {
            if (inverse)
            {
                mainBorder.BorderBrush = LUIPalette.GRAYSCALE90;
            }
            else
            {
                mainBorder.BorderBrush = LUIPalette.GRAYSCALE28;

            }
        }

        private void MainButton_MouseEnter(object sender, MouseEventArgs e)
        {

            //var aa =(Storyboard) mainBorder.FindResource("sbFadeIn");
            //aa.Begin();

            if (sender is Button button)
            {
                if (button == mainButton && !button.IsFocused && (scheme == LUISchemeEnum.Default || scheme == LUISchemeEnum.Toolbar))
                {
                    if (inverse)
                    {
                        mainBorder.BorderBrush = LUIPalette.GRAYSCALE100;
                    }
                    else
                    {
                        mainBorder.BorderBrush = LUIPalette.GRAYSCALE5;
                    }
                    e.Handled = true;


                    //        var animation = new ColorAnimation();                    
                    //        animation.From = Colors.Orange;                    
                    //        animation.To = Colors.Gray;
                    //        animation.Duration = new Duration(TimeSpan.FromSeconds(1));
                    //        Storyboard sb = new Storyboard();
                    //        sb.Children.Add(animation);
                    //        Storyboard.SetTarget(animation, mainBorder.BorderBrush);
                    //        Storyboard.SetTargetProperty(animation, new PropertyPath(SolidColorBrush.ColorProperty));

                    //        sb.Begin(mainBorder);
                    //        //mainBorder.BorderBrush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                }
            }
        }

        private void MainButton_MouseLeave(object sender, MouseEventArgs e)
        {

            if (sender is Button button)
            {
                if (button == mainButton && !button.IsFocused)
                {
                    if (inverse)
                    {
                        mainBorder.BorderBrush = LUIPalette.GRAYSCALE40;
                    }
                    else
                    {
                        mainBorder.BorderBrush = LUIPalette.GRAYSCALE80;
                    }
                    e.Handled = true;
                }
            }
        }

        #region CornerRadius - DP
        private CornerRadius cornerRadius;
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
         "CornerRadius", typeof(CornerRadius), typeof(LuiButton), new PropertyMetadata(new CornerRadius(1.11), new PropertyChangedCallback(OnCornerRadiusChanged)));


        private static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is CornerRadius newvalue)
                {
                    obj.CornerRadius_Internal = newvalue;
                }
            }
        }
        #endregion

        #region LUIButtonSize - DP
        private LUIButtonSizeEnum buttonsize;
        internal LUIButtonSizeEnum LUIButtonSize_Internal
        {
            get { return buttonsize; }
            set
            {
                if (buttonsize != value)
                {
                    buttonsize = value;
                    SetButtonSize();
                }
            }
        }
        public LUIButtonSizeEnum LUIButtonSize
        {
            get { return (LUIButtonSizeEnum)this.GetValue(LUIButtonSizeProperty); }
            set { this.SetValue(LUIButtonSizeProperty, value); }
        }

        public static readonly DependencyProperty LUIButtonSizeProperty = DependencyProperty.Register(
         "LUIButtonSize", typeof(LUIButtonSizeEnum), typeof(LuiButton), new PropertyMetadata(LUIButtonSizeEnum.Default, new PropertyChangedCallback(OnLUIButtonSizeChanged)));


        private static void OnLUIButtonSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is LUIButtonSizeEnum newvalue)
                {
                    obj.LUIButtonSize_Internal = newvalue;
                }
            }
        }

        private void SetButtonSize()
        {
            if (mainBorder != null)
            {
                mainBorder.Height = LUIButtonSize.GetButtonSize();
            }
        }
        #endregion

        #region BorderThickness - DP
        private Thickness borderThickness=new Thickness(1.01);
        internal Thickness LUIBorderThickness_Internal
        {
            get { return borderThickness; }
            set
            {
                if (borderThickness!=value)
                {
                    borderThickness = value;
                    SetBorderThicknes();
                }
            }
        }
        public Thickness LUIBorderThickness
        {
            get { return (Thickness)this.GetValue(LUIBorderThicknessProperty); }
            set { this.SetValue(LUIBorderThicknessProperty, value); }
        }

        public static readonly DependencyProperty LUIBorderThicknessProperty = DependencyProperty.Register(
         "LUIBorderThickness", typeof(Thickness), typeof(LuiButton), new PropertyMetadata(new Thickness(1.01), new PropertyChangedCallback(OnBorderThicknessChanged)));


        private static void OnBorderThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiButton obj)
            {
                if (e.NewValue is Thickness newvalue)
                {
                    obj.LUIBorderThickness_Internal = newvalue;
                }
            }
        }
        private void SetBorderThicknes()
        {
            if (mainBorder!=null)
            {
                mainBorder.BorderThickness = LUIBorderThickness;
            }
        }
        #endregion


    }
}
