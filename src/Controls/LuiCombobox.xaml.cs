namespace leonardo.Controls
{
    #region Usings
    using NLog;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using leonardo.AttachedProperties; 
    #endregion

    /// <summary>
    /// Interaktionslogik für LuiCombobox.xaml
    /// </summary>

    public partial class LuiCombobox : ComboBox
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public LuiCombobox()
        {
            InitializeComponent();
        }

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
                    this.SetValue(ThemeProperties.LabelTextAttachedProperty, labelText);
                }
            }
        }
        public string LabelText
        {
            get { return (string)this.GetValue(LabelTextProperty); }
            set { this.SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
         "LabelText", typeof(string), typeof(LuiCombobox), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnLabelTextChanged)));


        private static void OnLabelTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiCombobox obj)
                {
                    if (e.NewValue is string newvalue)
                    {
                        obj.LabelText_Internal = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion
    }
}
