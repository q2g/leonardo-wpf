namespace leonardo.Controls
{
    #region Usings
    using NLog;
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Controls;
    #endregion

    /// <summary>
    /// Interaktionslogik für LuiSearch.xaml
    /// </summary>
    public partial class LuiSearch : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region CTOR
        public LuiSearch()
        {
            InitializeComponent();
        }
        #endregion

        #region SearchText - DP        
        public string SearchText
        {
            get { return (string)this.GetValue(SearchTextProperty); }
            set { this.SetValue(SearchTextProperty, value); }
        }

        public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register(
         "SearchText", typeof(string), typeof(LuiSearch), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region Command - DP        
        public ICommand Command
        {
            get { return (ICommand)this.GetValue(CommandProperty); }
            set { this.SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
         "Command", typeof(ICommand), typeof(LuiSearch), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region CommandParameter - DP        
        public object CommandParameter
        {
            get { return (object)this.GetValue(CommandParameterProperty); }
            set { this.SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
         "CommandParameter", typeof(object), typeof(LuiSearch), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion


        #region Events
        private void maininput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Escape)
                {
                    if (string.IsNullOrEmpty(maininput.Text))
                    {
                        if (CancelCommand != null)
                        {
                            CancelCommand.Execute(null);
                        }
                    }
                    else
                    {
                        SearchText = "";
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void mainbutton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SearchText = "";
        }
        #endregion

        #region SearchCommand - DP        
        public ICommand SearchCommand
        {
            get { return (ICommand)this.GetValue(SearchCommandProperty); }
            set { this.SetValue(SearchCommandProperty, value); }
        }

        public static readonly DependencyProperty SearchCommandProperty = DependencyProperty.Register(
         "SearchCommand", typeof(ICommand), typeof(LuiSearch), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region CancelCommand - DP        
        public ICommand CancelCommand
        {
            get { return (ICommand)this.GetValue(CancelCommandProperty); }
            set { this.SetValue(CancelCommandProperty, value); }
        }

        public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(
         "CancelCommand", typeof(ICommand), typeof(LuiSearch), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion



        #region HintText - DP        
        public string HintText
        {
            get { return (string)this.GetValue(HintTextProperty); }
            set { this.SetValue(HintTextProperty, value); }
        }

        public static readonly DependencyProperty HintTextProperty = DependencyProperty.Register(
         "HintText", typeof(string), typeof(LuiSearch), new FrameworkPropertyMetadata("Search...", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
