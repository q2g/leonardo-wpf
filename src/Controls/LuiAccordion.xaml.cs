namespace leonardo.Controls
{
    #region Usings
    using GongSolutions.Wpf.DragDrop;
    using leonardo.AttachedProperties;
    using leonardo.Resources;
    using NLog;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    #endregion

    /// <summary>
    /// Interaktionslogik für LuiAccordion.xaml
    /// </summary>
    public partial class LuiAccordion : ItemsControl, IDropTarget
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region CTOR
        public LuiAccordion()
        {
            InitializeComponent();

            DeleteCommand = new RelayCommand(
                (o) =>
                {
                    try
                    {
                        if (ItemContainerGenerator.ContainerFromItem(o) is LuiAccordionItem container)
                        {
                            Delete(container.DataContext);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                }, (o) => true);

            DependencyPropertyDescriptor
                       .FromProperty(LuiAccordion.ItemsSourceProperty, typeof(LuiAccordion))
                       .AddValueChanged(this, ItemsSourceChanged);
        }

        #endregion

        private void ItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var item in e.NewItems)
                    {
                        if (ItemContainerGenerator.ContainerFromItem(item) is LuiAccordionItem itemContainer)
                        {
                            itemContainer.Index = Items.Count;
                        }
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var item in e.OldItems)
                    {
                        Dictionary<int, LuiAccordionItem> indexDict = GetIndexDictionary();
                        if (indexDict.Count != 0)
                        {
                            for (int i = 1; i <= Items.Count; i++)
                            {
                                if (!indexDict.ContainsKey(i))
                                {
                                    foreach (var accitem in indexDict.Where(ele => ele.Key > i).Select(ele => ele.Value).ToList())
                                    {
                                        accitem.Index--;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }


        private INotifyCollectionChanged lastItemssource = null;
        private void ItemsSourceChanged(object sender, EventArgs e)
        {
            if (lastItemssource is INotifyCollectionChanged old_collectionchanged)
            {
                old_collectionchanged.CollectionChanged -= ItemsSource_CollectionChanged;
            }

            if (ItemsSource is INotifyCollectionChanged new_collectionchanged)
            {
                new_collectionchanged.CollectionChanged += ItemsSource_CollectionChanged;
                lastItemssource = new_collectionchanged;
            }

            if (ItemsSource != null)
            {
                int counter = 1;
                foreach (var item in ItemsSource)
                {
                    if (GetItemIndex(item) < 1)
                        SetItemIndex(item, counter++);
                }
            }
        }



        private void Delete(object toDelete)
        {
            if (GetList() is System.Collections.IList list)
            {
                list.Remove(toDelete);
            }
        }

        private Dictionary<int, LuiAccordionItem> GetIndexDictionary()
        {
            Dictionary<int, LuiAccordionItem> retval = new Dictionary<int, LuiAccordionItem>();
            try
            {
                foreach (var item in Items)
                {
                    if (ItemContainerGenerator.ContainerFromItem(item) is LuiAccordionItem itemContainer)
                    {
                        if (!retval.ContainsKey(itemContainer.Index))
                        {
                            retval.Add(itemContainer.Index, itemContainer);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return retval;
        }

        LuiAccordionItem expandedItem;
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            try
            {
                if (item is LuiAccordionItem accordionitem)
                {
                    if (collapseAllOnExpandSingle)
                    {
                        DependencyPropertyDescriptor
                        .FromProperty(LuiAccordionItem.IsExpandedProperty, typeof(LuiAccordionItem))
                        .AddValueChanged(accordionitem, IsExpandedChanged);
                    }
                    if (accordionitem.IsExpanded)
                    {
                        expandedItem = accordionitem;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return false;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            var retval = new LuiAccordionItem();
            try
            {
                if (collapseAllOnExpandSingle)
                {
                    DependencyPropertyDescriptor
                     .FromProperty(LuiAccordionItem.IsExpandedProperty, typeof(LuiAccordionItem))
                     .AddValueChanged(retval, IsExpandedChanged);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return retval;

        }

        private bool itemHeightRead;
        private double itemHeight = ThemeProperties.DEFAULTITEMHEIGHT;
        private void IsExpandedChanged(object sender, EventArgs e)
        {
            if (!itemHeightRead)
            {
                itemHeight = (double)GetValue(ThemeProperties.ItemheightProperty);
                itemHeightRead = true;
            }
            if (sender is LuiAccordionItem accitem)
            {
                if (accitem.IsExpanded == true)
                {
                    ExpandedItemIndex = ItemContainerGenerator.IndexFromContainer(accitem);
                    if (collapseAllOnExpandSingle)
                        CollapseAllItems(accitem);
                    if (!IsItemsStretchEnabled)
                    {
                        if (Items.Count > 0)
                        {
                            accitem.Height = Math.Max(ActualHeight - ((Items.Count - 1) * itemHeight), itemHeight);
                        }
                    }
                }
                else
                {
                    if (!IsItemsStretchEnabled)
                    {
                        accitem.Height = ThemeProperties.DEFAULTITEMHEIGHT;
                    }
                }
            }
        }

        private void CollapseAllItems(LuiAccordionItem sender)
        {
            foreach (var item in Items)
            {

                if (item != sender.DataContext)
                {
                    if (ItemContainerGenerator.ContainerFromItem(item) is LuiAccordionItem itemContainer)
                    {
                        itemContainer.IsExpanded = false;
                    }
                }
            }
        }

        #region CollapseAllOnExpandSingle
        private bool collapseAllOnExpandSingle;
        internal bool CollapseAllOnExpandSingle_Intern
        {
            get { return collapseAllOnExpandSingle; }
            set
            {
                if (collapseAllOnExpandSingle != value)
                {
                    collapseAllOnExpandSingle = value;
                }
            }
        }
        public bool CollapseAllOnExpandSingle
        {
            get { return (bool)this.GetValue(CollapseAllOnExpandSingleProperty); }
            set { this.SetValue(CollapseAllOnExpandSingleProperty, value); }
        }

        public static readonly DependencyProperty CollapseAllOnExpandSingleProperty = DependencyProperty.Register(
         "CollapseAllOnExpandSingle", typeof(bool), typeof(LuiAccordion), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnCollapseAllOnExpandSingleChanged)));


        private static void OnCollapseAllOnExpandSingleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiAccordion obj)
                {
                    if (e.NewValue is bool newvalue)
                    {
                        obj.CollapseAllOnExpandSingle_Intern = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region IDropTarget
        private UIElement m_lastDragedOverElement;

        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            try
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Move;
                if (dropInfo.VisualTargetItem != null)
                {
                    if (m_lastDragedOverElement != null)
                    {
                        m_lastDragedOverElement.Opacity = 1;
                    }
                    m_lastDragedOverElement = dropInfo.VisualTargetItem;
                    dropInfo.VisualTargetItem.Opacity = 0.5;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            try
            {
                if (m_lastDragedOverElement != null)
                {
                    m_lastDragedOverElement.Opacity = 1;
                }
                if (DropCommand != null)
                    DropCommand.Execute(new Tuple<object, object>(dropInfo.Data, dropInfo.TargetItem));
                if (ItemContainerGenerator.ContainerFromItem(dropInfo.Data) is LuiAccordionItem sourceContainer)
                {
                    if (ItemContainerGenerator.ContainerFromItem(dropInfo.TargetItem) is LuiAccordionItem targetContainer)
                    {
                        DropItem(sourceContainer, targetContainer);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region IsDragDropEnabled DP
        public bool IsDragDropEnabled
        {
            get { return (bool)this.GetValue(IsDragDropEnabledProperty); }
            set { this.SetValue(IsDragDropEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsDragDropEnabledProperty = DependencyProperty.Register(
         "IsDragDropEnabled", typeof(bool), typeof(LuiAccordion), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region DropCommand DP
        public ICommand DropCommand
        {
            get { return (ICommand)this.GetValue(DropCommandProperty); }
            set { this.SetValue(DropCommandProperty, value); }
        }

        public static readonly DependencyProperty DropCommandProperty = DependencyProperty.Register(
         "DropCommand", typeof(ICommand), typeof(LuiAccordion), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region ExpandedItemIndex DP
        public int ExpandedItemIndex
        {
            get { return (int)this.GetValue(ExpandedItemIndexProperty); }
            set { this.SetValue(ExpandedItemIndexProperty, value); }
        }

        public static readonly DependencyProperty ExpandedItemIndexProperty = DependencyProperty.Register(
         "ExpandedItemIndex", typeof(int), typeof(LuiAccordion), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region IsItemsStretchEnabled DP
        public bool IsItemsStretchEnabled
        {
            get { return (bool)this.GetValue(IsItemsStretchEnabledProperty); }
            set { this.SetValue(IsItemsStretchEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsItemsStretchEnabledProperty = DependencyProperty.Register(
         "IsItemsStretchEnabled", typeof(bool), typeof(LuiAccordion), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region IndexProvider DP
        public IIndexProvider IndexProvider
        {
            get { return (IIndexProvider)this.GetValue(IndexProviderProperty); }
            set { this.SetValue(IndexProviderProperty, value); }
        }

        public static readonly DependencyProperty IndexProviderProperty = DependencyProperty.Register(
         "IndexProvider", typeof(IIndexProvider), typeof(LuiAccordion), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region IsDragDropChangesUnderlyingCollection DP
        private bool isDragDropChangesUnderlyingCollection = true;

        internal bool IsDragDropChangesUnderlyingCollection_Internal
        {
            get { return isDragDropChangesUnderlyingCollection; }
            set
            {
                if (isDragDropChangesUnderlyingCollection != value)
                {
                    isDragDropChangesUnderlyingCollection = value;
                }
            }
        }
        public bool IsDragDropChangesUnderlyingCollection
        {
            get { return (bool)this.GetValue(IsDragDropChangesUnderlyingCollectionProperty); }
            set { this.SetValue(IsDragDropChangesUnderlyingCollectionProperty, value); }
        }

        public static readonly DependencyProperty IsDragDropChangesUnderlyingCollectionProperty = DependencyProperty.Register(
         "IsDragDropChangesUnderlyingCollection", typeof(bool), typeof(LuiAccordion), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnIsDragDropChangesUnderlyingChanged)));


        private static void OnIsDragDropChangesUnderlyingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is LuiAccordion obj)
                {
                    if (e.NewValue is bool newvalue)
                    {
                        obj.IsDragDropChangesUnderlyingCollection_Internal = newvalue;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        #endregion

        #region Functions
        private void DropItem(LuiAccordionItem source, LuiAccordionItem target)
        {
            if (GetList() is System.Collections.IList list)
            {
                MoveItem(list, source, target);
            }
        }

        private System.Collections.IList GetList()
        {
            if (ItemsSource != null)
            {
                if (ItemsSource is System.Collections.IList list)
                {
                    return list;
                }

                if (ItemsSource is ListCollectionView view)
                {
                    if (view.SourceCollection is System.Collections.IList viewlist)
                    {
                        return viewlist;
                    }
                }

            }
            else
            {
                return Items;
            }
            return null;
        }

        private void MoveItem(System.Collections.IList list, LuiAccordionItem source, LuiAccordionItem target)
        {
            int sourceIndex = ItemContainerGenerator.IndexFromContainer(source);
            int targetIndex = ItemContainerGenerator.IndexFromContainer(target);
            int sortindexsource = source.Index;
            int sortindextarget = target.Index;

            if (isDragDropChangesUnderlyingCollection)
            {
                object valueToMove = list[sourceIndex];
                if (sourceIndex != targetIndex)
                {
                    if (list is ObservableCollection<object> olist)
                    {
                        olist.Move(sourceIndex, targetIndex);
                    }
                    else
                    {
                        list.RemoveAt(sourceIndex);
                        list.Insert(targetIndex, valueToMove);
                    }


                    foreach (var listitem in list)
                    {
                        if (ItemContainerGenerator.ContainerFromItem(listitem) is LuiAccordionItem itemContainer)
                        {
                            if (sortindexsource > sortindextarget)
                            {
                                if (IsInbitween(itemContainer.Index, sortindexsource, sortindextarget))
                                {
                                    itemContainer.Index++;
                                }
                            }
                            if (sortindexsource < sortindextarget)
                            {
                                if (IsInbitween(itemContainer.Index, sortindexsource, sortindextarget))
                                {
                                    itemContainer.Index--;
                                }
                            }
                        }
                    }

                    if (ItemContainerGenerator.ContainerFromItem(valueToMove) is LuiAccordionItem movedItemContainer)
                    {
                        movedItemContainer.Index = sortindextarget;
                    }
                }
            }
            else
            {
                foreach (var listitem in list)
                {
                    if (ItemContainerGenerator.ContainerFromItem(listitem) is LuiAccordionItem itemContainer)
                    {
                        if (sortindexsource > sortindextarget)
                        {
                            if (IsInbitween(itemContainer.Index, sortindexsource, sortindextarget))
                            {
                                itemContainer.Index++;
                            }
                        }
                        if (sortindexsource < sortindextarget)
                        {
                            if (IsInbitween(itemContainer.Index, sortindexsource, sortindextarget))
                            {
                                itemContainer.Index--;
                            }
                        }
                    }
                }

                source.Index = sortindextarget;
            }
        }
        private bool IsInbitween(int index, int bound1, int bound2)
        {
            if (bound1 == bound2)
            {
                return false;
            }
            if (bound1 > bound2)
            {
                return index >= bound2 && index <= bound1;
            }
            if (bound1 < bound2)
            {
                return index >= bound1 && index <= bound2;
            }
            return false;
        }

        private void SetItemIndex(object item, int index)
        {
            if (IndexProvider != null)
            {
                IndexProvider.SetIndex(item, index);
            }
            else
            {
                if (ItemContainerGenerator.ContainerFromItem(item) is LuiAccordionItem itemContainer)
                {
                    itemContainer.Index = index;
                }
            }
        }
        private int GetItemIndex(object item)
        {
            if (IndexProvider != null)
            {
                return IndexProvider.GetIndex(item);
            }
            else
            {
                if (ItemContainerGenerator.ContainerFromItem(item) is LuiAccordionItem itemContainer)
                {
                    return itemContainer.Index;
                }
            }
            return -2;
        }
        #endregion

        #region DeleteCommand
        public ICommand DeleteCommand { get; set; }
        #endregion

        private void ItemsControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (expandedItem != null)
            {
                IsExpandedChanged(expandedItem, null);
            }
            return;
        }

        private void ItemsControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (Items != null)
            {
                foreach (var item in Items)
                {
                    if (ItemContainerGenerator.ContainerFromItem(item) is LuiAccordionItem accitem)
                    {
                        if (accitem.IsExpanded)
                        {
                            IsExpandedChanged(accitem, null);
                        }
                    }
                }
            }
        }
    }






}

