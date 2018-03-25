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
    /// Interaktionslogik für LuiSearch.xaml
    /// </summary>
    public partial class LuiSearch : UserControl
    {
        public LuiSearch()
        {
            InitializeComponent();           
        }

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


        private void maininput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key== Key.Escape)
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
                    maininput.Text = "";
                }
            }
        }

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
    }
}
