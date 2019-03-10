namespace leonardo.Controls
{
    #region Usings
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using NLog;
    #endregion

    /// <summary>
    /// Interaktionslogik für LuiAccordionItem.xaml
    /// </summary>
    public partial class LuiAccordionItem : HeaderedContentControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region CTOR
        public LuiAccordionItem()
        {
            InitializeComponent();
            DataContext = this;
        }
        #endregion

        #region IsExpanded - DP
        public bool IsExpanded
        {
            get { return (bool)this.GetValue(IsExpandedProperty); }
            set { this.SetValue(IsExpandedProperty, value); }
        }

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
         "IsExpanded", typeof(bool), typeof(LuiAccordionItem), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region HeaderTemplate - DP
        public new DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)this.GetValue(HeaderTemplateProperty); }
            set { this.SetValue(HeaderTemplateProperty, value); }
        }

        public static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.Register(
         "HeaderTemplate", typeof(DataTemplate), typeof(LuiAccordionItem), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region Index - DP
        private int index;
        internal int Index_Internal
        {
            get { return index; }
            set
            {
                if (index != value)
                {
                    index = value;
                }
            }
        }
        public int Index
        {
            get { return (int)this.GetValue(IndexProperty); }
            set { this.SetValue(IndexProperty, value); }
        }

        public static readonly DependencyProperty IndexProperty = DependencyProperty.Register(
         "Index", typeof(int), typeof(LuiAccordionItem), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnIndexChanged)));

        private static void OnIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiAccordionItem obj)
                {
                    if (e.NewValue is int newvalue)
                    {
                        obj.Index_Internal = newvalue;
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
