using leonardo.AttachedProperties;
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
    /// Interaktionslogik für LuiInputGroup.xaml
    /// </summary>
    public partial class LuiInputGroup : UserControl
    {
        public LuiInputGroup()
        {
            InitializeComponent();           
        }

        #region SearchText - DP        
        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
         "Text", typeof(string), typeof(LuiInputGroup), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
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
        private LUIiconsEnum leftCommandIcon=LUIiconsEnum.lui_icon_none;
        internal LUIiconsEnum LeftCommandIcon_Internal
        {
            get { return leftCommandIcon; }
            set
            {
                if (leftCommandIcon!=value)
                {
                    leftCommandIcon = value;
                    if (leftCommandIcon!=LUIiconsEnum.lui_icon_none)
                    {
                        maininputleftrounded.SetValue(ThemeProperties.CornerRadiusProperty, new CornerRadius(0));
                    }
                }
            }
        }
        public LUIiconsEnum LeftCommandIcon
        {
            get { return (LUIiconsEnum)this.GetValue(LeftCommandIconProperty); }
            set { this.SetValue(LeftCommandIconProperty, value); }
        }

        public static readonly DependencyProperty LeftCommandIconProperty = DependencyProperty.Register(
         "LeftCommandIcon", typeof(LUIiconsEnum), typeof(LuiInputGroup), new FrameworkPropertyMetadata(LUIiconsEnum.lui_icon_none, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnLeftCommandIconChanged)));


        private static void OnLeftCommandIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LuiInputGroup obj)
            {
                if (e.NewValue is LUIiconsEnum newvalue)
                {
                    obj.LeftCommandIcon_Internal = newvalue;
                }
            }
        }
        #endregion

        #region RightCommandIcon - DP        
        public LUIiconsEnum RightCommandIcon
        {
            get { return (LUIiconsEnum)this.GetValue(RightCommandIconProperty); }
            set { this.SetValue(RightCommandIconProperty, value); }
        }

        public static readonly DependencyProperty RightCommandIconProperty = DependencyProperty.Register(
         "RightCommandIcon", typeof(LUIiconsEnum), typeof(LuiInputGroup), new FrameworkPropertyMetadata(LUIiconsEnum.lui_icon_none, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
    }
}
