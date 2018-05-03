namespace leonardo.Controls
{
    #region Usings
    using NLog;
    using System;
    using System.Windows;
    using leonardo.Resources;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Controls;
    using leonardo.AttachedProperties; 
    #endregion

    /// <summary>
    /// Interaktionslogik für LuiInputGroup.xaml
    /// </summary>
    public partial class LuiInputGroup : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region CTOR
        public LuiInputGroup()
        {
            InitializeComponent();
        } 
        #endregion

        #region Text - DP        
        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
         "Text", typeof(string), typeof(LuiInputGroup), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region LabelText - DP        
        public string LabelText
        {
            get { return (string)this.GetValue(LabelTextProperty); }
            set { this.SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
         "LabelText", typeof(string), typeof(LuiInputGroup), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region LeftCommand - DP        
        public ICommand LeftCommand
        {
            get { return (ICommand)this.GetValue(LeftCommandProperty); }
            set { this.SetValue(LeftCommandProperty, value); }
        }

        public static readonly DependencyProperty LeftCommandProperty = DependencyProperty.Register(
         "LeftCommand", typeof(ICommand), typeof(LuiInputGroup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region LeftCommandParameter - DP        
        public object LeftCommandParameter
        {
            get { return (object)this.GetValue(LeftCommandParameterProperty); }
            set { this.SetValue(LeftCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty LeftCommandParameterProperty = DependencyProperty.Register(
         "LeftCommandParameter", typeof(object), typeof(LuiInputGroup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region RightCommand - DP        
        public ICommand RightCommand
        {
            get { return (ICommand)this.GetValue(RightCommandProperty); }
            set { this.SetValue(RightCommandProperty, value); }
        }

        public static readonly DependencyProperty RightCommandProperty = DependencyProperty.Register(
         "RightCommand", typeof(ICommand), typeof(LuiInputGroup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region RightCommandParameter - DP        
        public object RightCommandParameter
        {
            get { return (object)this.GetValue(RightCommandParameterProperty); }
            set { this.SetValue(RightCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty RightCommandParameterProperty = DependencyProperty.Register(
         "RightCommandParameter", typeof(object), typeof(LuiInputGroup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region LeftCommandIcon - DP 
        private LuiIconsEnum leftCommandIcon = LuiIconsEnum.lui_icon_none;
        internal LuiIconsEnum LeftCommandIcon_Internal
        {
            get { return leftCommandIcon; }
            set
            {
                if (leftCommandIcon != value)
                {
                    leftCommandIcon = value;
                    if (leftCommandIcon != LuiIconsEnum.lui_icon_none)
                    {
                        maininputleftrounded.SetValue(ThemeProperties.CornerRadiusProperty, new CornerRadius(0));
                    }
                }
            }
        }
        public LuiIconsEnum LeftCommandIcon
        {
            get { return (LuiIconsEnum)this.GetValue(LeftCommandIconProperty); }
            set { this.SetValue(LeftCommandIconProperty, value); }
        }

        public static readonly DependencyProperty LeftCommandIconProperty = DependencyProperty.Register(
         "LeftCommandIcon", typeof(LuiIconsEnum), typeof(LuiInputGroup), new FrameworkPropertyMetadata(LuiIconsEnum.lui_icon_none, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnLeftCommandIconChanged)));


        private static void OnLeftCommandIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiInputGroup obj)
                {
                    if (e.NewValue is LuiIconsEnum newvalue)
                    {
                        obj.LeftCommandIcon_Internal = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region RightCommandIcon - DP        
        public LuiIconsEnum RightCommandIcon
        {
            get { return (LuiIconsEnum)this.GetValue(RightCommandIconProperty); }
            set { this.SetValue(RightCommandIconProperty, value); }
        }

        public static readonly DependencyProperty RightCommandIconProperty = DependencyProperty.Register(
         "RightCommandIcon", typeof(LuiIconsEnum), typeof(LuiInputGroup), new FrameworkPropertyMetadata(LuiIconsEnum.lui_icon_none, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region IsInputEnabled - DP        
        public bool IsInputEnabled
        {
            get { return (bool)this.GetValue(IsInputEnabledProperty); }
            set { this.SetValue(IsInputEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsInputEnabledProperty = DependencyProperty.Register(
         "IsInputEnabled", typeof(bool), typeof(LuiInputGroup), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region RightCommandForeground - DP        
        public Brush RightCommandForeground
        {
            get { return (Brush)this.GetValue(RightCommandForegroundProperty); }
            set { this.SetValue(RightCommandForegroundProperty, value); }
        }

        public static readonly DependencyProperty RightCommandForegroundProperty = DependencyProperty.Register(
         "RightCommandForeground", typeof(Brush), typeof(LuiInputGroup), new FrameworkPropertyMetadata(LuiPalette.Brushes.GRAYSCALE30, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region LeftCommandForeground - DP        
        public Brush LeftCommandForeground
        {
            get { return (Brush)this.GetValue(LeftCommandForegroundProperty); }
            set { this.SetValue(LeftCommandForegroundProperty, value); }
        }

        public static readonly DependencyProperty LeftCommandForegroundProperty = DependencyProperty.Register(
         "LeftCommandForeground", typeof(Brush), typeof(LuiInputGroup), new FrameworkPropertyMetadata(LuiPalette.Brushes.GRAYSCALE30, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion        
    }
}
