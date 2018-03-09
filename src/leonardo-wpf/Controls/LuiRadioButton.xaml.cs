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
    /// Interaktionslogik für LuiRadioButton.xaml
    /// </summary>
    public partial class LuiRadioButton : UserControl
    {
        
        public LuiRadioButton()
        {
            InitializeComponent();
        }


        //For Auto-Grouping Behavior
        //All Radiobuttons in the same Parent are in the same Group, so we need a Group-ID
        private static Dictionary<object, String> GroupList = new Dictionary<object, string>();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(GroupName) && Parent != null)
            {
                if (!GroupList.ContainsKey(Parent))
                {
                    Guid newguid = Guid.NewGuid();
                    GroupList.Add(Parent, newguid.ToString());
                    
                }
                MainRadiobutton.GroupName = GroupList[Parent];
            }
        }

        #region Text - DP
        private string text;
        internal string Text_Internal
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    MainRadiobutton.Content = value;
                }
            }
        }
        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
         "Text", typeof(string), typeof(LuiRadioButton), new PropertyMetadata("", new PropertyChangedCallback(OnTextChanged)));


        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiRadioButton obj)
            {
                if (e.NewValue is string newvalue)
                {
                    obj.Text_Internal = newvalue;
                }
            }
        }
        #endregion

        #region IsChecked DP
        private bool isChecked;
        internal bool IsChecked_Internal
        {
            get { return isChecked; }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    MainRadiobutton.IsChecked = value;
                }
            }
        }
        public bool IsChecked
        {
            get { return (bool)this.GetValue(IsCheckedProperty); }
            set { this.SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(
         "IsChecked", typeof(bool), typeof(LuiRadioButton), new PropertyMetadata(false, new PropertyChangedCallback(OnIsCheckedChanged)));


        private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiRadioButton obj)
            {
                if (e.NewValue is bool newvalue)
                {
                    obj.IsChecked_Internal = newvalue;
                }
            }
        }
        #endregion

        #region GroupName - DP
        private string groupName;
        internal string GroupName_Internal
        {
            get { return groupName; }
            set
            {
                if (groupName != value)
                {
                    groupName = value;
                    MainRadiobutton.GroupName = value;
                }
            }
        }
        public string GroupName
        {
            get { return (string)this.GetValue(GroupNameProperty); }
            set { this.SetValue(GroupNameProperty, value); }
        }

        public static readonly DependencyProperty GroupNameProperty = DependencyProperty.Register(
         "GroupName", typeof(string), typeof(LuiRadioButton), new PropertyMetadata("", new PropertyChangedCallback(OnGroupNameChanged)));


        private static void OnGroupNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiRadioButton obj)
            {
                if (e.NewValue is string newvalue)
                {
                    obj.GroupName_Internal = newvalue;
                }
            }
        }
        #endregion

      
    }
}
