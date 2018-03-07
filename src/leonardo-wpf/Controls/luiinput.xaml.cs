using leonardo.Resources;
using System;
using System.Collections;
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
    /// Interaktionslogik für LuiInput.xaml
    /// </summary>
    public partial class LuiInput : UserControl
    {

        public event EventHandler InputTextChanged;
        public LuiInput()
        {
            InitializeComponent();
            LabelText_Internal = "";
            MainTextBox.Height = 28;
        }

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
                    SetColors();
                }
            }
        }
        public bool Inverse
        {
            get { return (bool)this.GetValue(InverseProperty); }
            set { this.SetValue(InverseProperty, value); }
        }

        public static readonly DependencyProperty InverseProperty = DependencyProperty.Register(
         "Inverse", typeof(bool), typeof(LuiInput), new PropertyMetadata(false, new PropertyChangedCallback(OnInverseChanged)));


        private static void OnInverseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiInput obj)
            {
                if (e.NewValue is bool newvalue)
                {
                    obj.Inverse_Internal = newvalue;
                }
            }
        }

        private void SetColors()
        {
            if (inverse)
            {
                MainStackpanel.Background = LUIPalette.Brushes.GRAYSCALE28;
                MainLabel.Foreground = LUIPalette.Brushes.GRAYSCALE100;
                MainTextBox.Background = LUIPalette.Brushes.GRAYSCALE40;
                MainTextBox.Foreground = LUIPalette.Brushes.GRAYSCALE100;
                MainTextBox.BorderBrush = LUIPalette.Brushes.GRAYSCALE40;
            }
            else
            {
                MainStackpanel.Background = new SolidColorBrush(Colors.Transparent);
                MainLabel.Foreground = LUIPalette.Brushes.GRAYSCALE80;
                MainTextBox.Background = LUIPalette.Brushes.GRAYSCALE100;
                MainTextBox.Foreground = LUIPalette.Brushes.GRAYSCALE80;
                MainTextBox.BorderBrush = LUIPalette.Brushes.GRAYSCALE80;
            }
        }
        #endregion

        #region InputText - DP
        private string inputText;
        internal string InputText_Internal
        {
            get { return inputText; }
            set
            {
                if (inputText!=value)
                {
                    inputText = value;
                    MainTextBox.Text = value;
                }
            }
        }
        public string InputText
        {
            get { return (string)this.GetValue(InputTextProperty); }
            set { this.SetValue(InputTextProperty, value); }
        }

        public static readonly DependencyProperty InputTextProperty = DependencyProperty.Register(
         "InputText", typeof(string), typeof(LuiInput), new PropertyMetadata("", new PropertyChangedCallback(OnInputTextChanged)));


        private static void OnInputTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiInput obj)
            {
                if (e.NewValue is string newvalue)
                {
                    obj.InputText_Internal = newvalue;
                }
            }
        }
        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputText = MainTextBox.Text;
            InputTextChanged?.Invoke(this, new EventArgs());
        }
        #endregion

        #region LUIInputSize - DP
        private LUIInputSizeEnum inputSize = LUIInputSizeEnum.Default;
        internal LUIInputSizeEnum LUIInputSize_Internal
        {
            get { return inputSize; }
            set
            {
                if (inputSize != value)
                {
                    inputSize = value;
                    SetInputSize();                    
                }
            }
        }
        public LUIInputSizeEnum LUIInputSize
        {
            get { return (LUIInputSizeEnum)this.GetValue(LUIInputSizeProperty); }
            set { this.SetValue(LUIInputSizeProperty, value); }
        }

        public static readonly DependencyProperty LUIInputSizeProperty = DependencyProperty.Register(
         "LUIInputSize", typeof(LUIInputSizeEnum), typeof(LuiInput), new PropertyMetadata(LUIInputSizeEnum.Default, new PropertyChangedCallback(OnLUIInputSizeChanged)));


        private static void OnLUIInputSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiInput obj)
            {
                if (e.NewValue is LUIInputSizeEnum newvalue)
                {
                    obj.LUIInputSize_Internal = newvalue;
                }
            }
        }

        private void SetInputSize()
        {
            MainTextBox.Height = LUIInputSize.GetInputSize();
            if (LUIInputSize== LUIInputSizeEnum.Large)
            {
                MainTextBox.FontSize = LUIFontSizeEnum.Large.GetFontSize();
            }
        }
        #endregion

        #region LabelText - DP
        private string labelText;
        internal string LabelText_Internal
        {
            get { return labelText; }
            set
            {
                if (labelText != value)
                {
                    labelText = value;
                    SetLabelText();                   
                }
            }
        }
        public string LabelText
        {
            get { return (string)this.GetValue(LabelTextProperty); }
            set { this.SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
         "LabelText", typeof(string), typeof(LuiInput), new PropertyMetadata("", new PropertyChangedCallback(OnLabelTextChanged)));


        private static void OnLabelTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiInput obj)
            {
                if (e.NewValue is string newvalue)
                {
                    obj.LabelText_Internal = newvalue;
                }
            }
        }
        private void SetLabelText()
        {
            MainLabel.Text = labelText;
            MainLabel.Visibility = string.IsNullOrEmpty(labelText) ? Visibility.Collapsed : Visibility.Visible;
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
        public CornerRadius LUICornerRadius
        {
            get { return (CornerRadius)this.GetValue(LUICornerRadiusProperty); }
            set { this.SetValue(LUICornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty LUICornerRadiusProperty = DependencyProperty.Register(
         "LUICornerRadius", typeof(CornerRadius), typeof(LuiInput), new PropertyMetadata(new CornerRadius(1.01), new PropertyChangedCallback(OnCornerRadiusChanged)));


        private static void OnCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiInput obj)
            {
                if (e.NewValue is CornerRadius newvalue)
                {
                    obj.CornerRadius_Internal = newvalue;
                }
            }
        }


        private void SetCornerRadius()
        {
            MainTextBox.Resources.Clear();
            Style style = new Style(typeof(Border));
            style.Setters.Add(new Setter(Border.CornerRadiusProperty, LUICornerRadius));
            MainTextBox.Resources.Add(typeof(Border), style);
        }
        #endregion

        #region BorderThickness - DP
        private Thickness borderThickness= new Thickness(1.01);
        internal Thickness LUIBorderThickness_Internal
        {
            get { return borderThickness; }
            set
            {
                if (borderThickness != value)
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
         "LUIBorderThickness", typeof(Thickness), typeof(LuiInput), new PropertyMetadata(new Thickness(1.01), new PropertyChangedCallback(OnBorderThicknessChanged)));


        private static void OnBorderThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiInput obj)
            {
                if (e.NewValue is Thickness newvalue)
                {
                    obj.LUIBorderThickness_Internal = newvalue;
                }
            }
        }
        private void SetBorderThicknes()
        {
            if (MainTextBox != null)
            {
                MainTextBox.BorderThickness = LUIBorderThickness;                
            }
        }
        #endregion

        #region  TextBoxFocused DP
        private bool textboxFocused;
        internal bool TextBoxFocused_Internal
        {
            get { return textboxFocused; }
            set
            {
                if (textboxFocused!=value)
                {
                    textboxFocused = value;
                    if (value)
                    {
                        MainTextBox.Focus();
                    }
}
            }
        }
        public bool TextBoxFocused
        {
            get { return (bool)this.GetValue(TextBoxFocusedProperty); }
            set { this.SetValue(TextBoxFocusedProperty, value); }
        }

        public static readonly DependencyProperty TextBoxFocusedProperty = DependencyProperty.Register(
 "TextBoxFocused", typeof(bool), typeof(LuiInput), new PropertyMetadata(false, new PropertyChangedCallback(OnTextBoxFocusedChanged)));


        private static void OnTextBoxFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiInput obj)
            {
                if (e.NewValue is bool newvalue)
                {
                    obj.TextBoxFocused_Internal = newvalue;
                }
            }
        }


        private void MainTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxFocused = true;
        }

        private void MainTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBoxFocused = false;
        }
        #endregion
    }
}
