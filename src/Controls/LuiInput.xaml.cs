namespace leonardo.Controls
{
    #region Usings
    using System.Windows;
    using leonardo.Resources;
    using System.Windows.Controls; 
    #endregion

    /// <summary>
    /// Interaktionslogik für LuiInput.xaml
    /// </summary>
    public partial class LuiInput : TextBox
    {
        #region CTOR
        public LuiInput()
        {
            InitializeComponent();
        } 
        #endregion

        #region LabelText - DP       
        public string LabelText
        {
            get { return (string)this.GetValue(LabelTextProperty); }
            set { this.SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
         "LabelText", typeof(string), typeof(LuiInput), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region HintText - DP       
        public string HintText
        {
            get { return (string)this.GetValue(HintTextProperty); }
            set { this.SetValue(HintTextProperty, value); }
        }

        public static readonly DependencyProperty HintTextProperty = DependencyProperty.Register(
         "HintText", typeof(string), typeof(LuiInput), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region LUIInputSize - DP       
        public LuiInputSizeEnum LUIInputSize
        {
            get { return (LuiInputSizeEnum)this.GetValue(LUIInputSizeProperty); }
            set { this.SetValue(LUIInputSizeProperty, value); }
        }

        public static readonly DependencyProperty LUIInputSizeProperty = DependencyProperty.Register(
         "LUIInputSize", typeof(LuiInputSizeEnum), typeof(LuiInput), new FrameworkPropertyMetadata(LuiInputSizeEnum.Default, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));       
        #endregion

    }
}
