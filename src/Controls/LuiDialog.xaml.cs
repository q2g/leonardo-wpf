namespace leonardo.Controls
{
    #region Usings
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using NLog;
    #endregion

    /// <summary>
    /// Interaktionslogik für LuiDialog.xaml
    /// </summary>
    [TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
    [TemplatePart(Name = "PART_Canvas", Type = typeof(Canvas))]
    [TemplatePart(Name = "PART_Path", Type = typeof(Path))]
    [TemplatePart(Name = "PART_ContentPresenter", Type = typeof(ContentPresenter))]
    public partial class LuiDialog : UserControl
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region Member
        //Controls in Template
        private Path path;
        private ContentPresenter contentPresenter;
        private Popup mainPopup;
        private Panel canvas;

        //Member for properties
        private Brush pathFill;
        private double canvasHeight;
        private double canvasWidth;
        private bool isPopupOpen;
        private UIElement popupPlacemenTarget;
        private PlacementMode popupPlacementMode;

        #endregion

        #region Event
        public event EventHandler PopupClosed;
        #endregion

        #region ctor
        public LuiDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        internal Brush PathFill
        {
            get { return pathFill; }
            set
            {
                pathFill = value;
                if (path != null)
                {
                    path.Fill = value;
                }
                RefreshPath();
            }
        }
        internal double CanvasHeight
        {
            get { return canvasHeight; }
            set
            {
                canvasHeight = value;
                if (canvas != null)
                {
                    canvas.Height = value;
                }
                RefreshPath();
            }
        }
        internal double CanvasWidth
        {
            get { return canvasWidth; }
            set
            {
                canvasWidth = value;
                if (canvas != null)
                {
                    canvas.Width = value;
                }
                RefreshPath();
            }
        }
        internal bool IsPopupOpen
        {
            get { return isPopupOpen; }
            set
            {
                isPopupOpen = value;
                if (mainPopup != null)
                {
                    mainPopup.IsOpen = value;
                }
            }
        }
        internal UIElement PopUpPlacementTarget
        {
            get { return popupPlacemenTarget; }
            set
            {
                popupPlacemenTarget = value;
                if (mainPopup != null)
                {
                    mainPopup.PlacementTarget = value;
                }
                RefreshPath();
            }
        }
        internal PlacementMode PopUpPlacementMode
        {
            get { return popupPlacementMode; }
            set
            {
                popupPlacementMode = value;
                if (mainPopup != null)
                {
                    mainPopup.Placement = value;
                }
                RefreshPath();
            }
        }
        #endregion

        #region overrides
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            try
            {
                // Code to get the Template parts as instance member
                mainPopup = GetTemplateChild("PART_Popup") as Popup;
                canvas = GetTemplateChild("PART_Canvas") as Canvas;
                path = GetTemplateChild("PART_Path") as Path;
                contentPresenter = GetTemplateChild("PART_ContentPresenter") as ContentPresenter;

                mainPopup.Closed += (sender, e) => { PopupClosed?.Invoke(sender, e); };
                mainPopup.IsOpen = IsOpen;
                canvas.Width = PanelWidth;
                canvas.Height = PanelHeight;
                RefreshPath();
                mainPopup.PlacementTarget = PlacementTarget;
                mainPopup.Placement = Placement;
                path.Fill = Fill;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region Functions
        private void RefreshPath()
        {
            try
            {
                if (path == null)
                {
                    return;
                }
                Int32 width = Math.Max((Int32)Double.Parse(GetValue(PanelWidthProperty).ToString()), 30);
                Int32 height = Math.Max((Int32)Double.Parse(GetValue(PanelHeightProperty).ToString()), 30);

                switch (Placement)
                {
                    case PlacementMode.Right:
                        path.Data = Geometry.Parse(String.Format("M10,10 L{0},10 L{0},{1} L10,{1} L10,{2} L0,{3} L10,{4} Z", width - 10, height - 10, (height / 2) + 10, height / 2, (height / 2) - 10));
                        break;
                    case PlacementMode.Left:
                        path.Data = Geometry.Parse(String.Format("M10,10 L{0},10 L{0},{2} L{1},{3} L{0},{4} L{0},{5} L10,{5} Z", width - 10, width, (height / 2) - 10, height / 2, (height / 2) + 10, width - 10, height - 10, height - 10));
                        break;
                    case PlacementMode.Top:
                        path.Data = Geometry.Parse(String.Format("M10,10 L{0},10 L{0},{1} L{2},{1} L{3},{4} L{5},{1} L10,{1} Z", width - 10, height - 10, (width / 2) + 10, width / 2, height, (width / 2) - 10));
                        break;
                    case PlacementMode.Bottom:
                    default:
                        path.Data = Geometry.Parse(String.Format("M10,10 L{0},10 L{1},0 L{2},10 L{3},10  L{3},{4} L10,{4} Z", (width / 2) - 10, width / 2, (width / 2) + 10, width - 10, height - 10));
                        break;
                }

                contentPresenter.Width = width - 30;
                contentPresenter.Height = height - 30;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region PlacementTarget - DP
        public UIElement PlacementTarget
        {
            get { return (UIElement)this.GetValue(PlacementTargetProperty); }
            set { this.SetValue(PlacementTargetProperty, value); }
        }

        public static readonly DependencyProperty PlacementTargetProperty = DependencyProperty.Register(
         "PlacementTarget", typeof(UIElement), typeof(LuiDialog), new PropertyMetadata(null, new PropertyChangedCallback(OnPlacementTargetChanged)));

        private static void OnPlacementTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiDialog obj)
                {
                    if (e.NewValue is UIElement newvalue)
                    {
                        obj.PopUpPlacementTarget = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region IsOpen - DP
        public bool IsOpen
        {
            get { return (bool)this.GetValue(IsOpenProperty); }
            set { this.SetValue(IsOpenProperty, value); }
        }

        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(
         "IsOpen", typeof(bool), typeof(LuiDialog), new PropertyMetadata(false, new PropertyChangedCallback(OnIsOpenChanged)));

        private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var obj = d as LuiDialog;
                if (d != null)
                {
                    if (e.NewValue is Boolean newvalue)
                    {
                        obj.IsPopupOpen = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region PanelWidth - DP
        public double PanelWidth
        {
            get { return (double)this.GetValue(PanelWidthProperty); }
            set { this.SetValue(PanelWidthProperty, value); }
        }

        public static readonly DependencyProperty PanelWidthProperty = DependencyProperty.Register(
         "PanelWidth", typeof(double), typeof(LuiDialog), new PropertyMetadata(200.0, new PropertyChangedCallback(OnPanelWidthChanged)));

        private static void OnPanelWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiDialog obj)
                {
                    if (e.NewValue is Double newvalue)
                    {
                        obj.CanvasWidth = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region PanelHeight - DP
        public double PanelHeight
        {
            get { return (double)this.GetValue(PanelHeightProperty); }
            set { this.SetValue(PanelHeightProperty, value); }
        }

        public static readonly DependencyProperty PanelHeightProperty = DependencyProperty.Register(
         "PanelHeight", typeof(double), typeof(LuiDialog), new PropertyMetadata(Double.Parse("200"), new PropertyChangedCallback(OnPanelHeightChanged)));

        private static void OnPanelHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiDialog obj)
                {
                    if (e.NewValue is Double newvalue)
                    {
                        obj.CanvasHeight = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region Placement - DP
        public PlacementMode Placement
        {
            get { return (PlacementMode)this.GetValue(PlacementProperty); }
            set { this.SetValue(PlacementProperty, value); }
        }

        public static readonly DependencyProperty PlacementProperty = DependencyProperty.Register(
         "Placement", typeof(PlacementMode), typeof(LuiDialog), new PropertyMetadata(PlacementMode.Bottom, new PropertyChangedCallback(OnPlacementChanged)));

        private static void OnPlacementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiDialog obj)
                {
                    if (e.NewValue is PlacementMode newvalue)
                    {
                        obj.PopUpPlacementMode = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region Fill - DP
        public Brush Fill
        {
            get { return (Brush)this.GetValue(FillProperty); }
            set { this.SetValue(FillProperty, value); }
        }

        public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
         "Fill", typeof(Brush), typeof(LuiDialog), new PropertyMetadata(new SolidColorBrush(Colors.White), new PropertyChangedCallback(OnFillChanged)));

        private static void OnFillChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiDialog obj)
                {
                    if (e.NewValue is Brush newvalue)
                    {
                        obj.PathFill = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region HorizontalOffset - DP
        private double horizontalOffset;
        internal double HorizontalOffset_Internal
        {
            get { return horizontalOffset; }
            set
            {
                horizontalOffset = value;
                if (mainPopup != null)
                {
                    mainPopup.HorizontalOffset = value;
                }
            }
        }
        public double HorizontalOffset
        {
            get { return (double)this.GetValue(HorizontalOffsetProperty); }
            set { this.SetValue(HorizontalOffsetProperty, value); }
        }

        public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.Register(
         "HorizontalOffset", typeof(double), typeof(LuiDialog), new PropertyMetadata(0.0, new PropertyChangedCallback(OnHorizontalOffsetChanged)));

        private static void OnHorizontalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiDialog obj)
                {
                    if (e.NewValue is Double newvalue)
                    {
                        obj.HorizontalOffset_Internal = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region VerticalOffset - DP
        private double verticalOffset;
        internal double VerticalOffset_Internal
        {
            get { return verticalOffset; }
            set
            {
                verticalOffset = value;
                if (mainPopup != null)
                {
                    mainPopup.VerticalOffset = value;
                }
            }
        }
        public double VerticalOffset
        {
            get { return (double)this.GetValue(VerticalOffsetProperty); }
            set { this.SetValue(VerticalOffsetProperty, value); }
        }

        public static readonly DependencyProperty VerticalOffsetProperty = DependencyProperty.Register(
         "VerticalOffset", typeof(double), typeof(LuiDialog), new PropertyMetadata(0.0, new PropertyChangedCallback(OnVerticalOffsetChanged)));

        private static void OnVerticalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiDialog obj)
                {
                    if (e.NewValue is Double newvalue)
                    {
                        obj.VerticalOffset_Internal = newvalue;
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
