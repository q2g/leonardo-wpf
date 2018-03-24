using GongSolutions.Wpf.DragDrop;
using leonardo.Resources;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
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
    /// Interaktionslogik für LuiAccordion.xaml
    /// </summary>
    public partial class LuiAccordion : ItemsControl, IDropTarget
    {
        public LuiAccordion()
        {
            InitializeComponent();
            (Items as INotifyCollectionChanged).CollectionChanged +=
                (s, e) =>
                    {
                        if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove)
                        {
                            RefreshAllIndexes();    
                        }
                    };

            DeleteCommand = new RelayCommand((o) => true,
                (o) =>
                {
                    if (ItemContainerGenerator.ContainerFromItem(o) is LuiAccordionItem container)
                    {
                        int deleteIndex = ItemContainerGenerator.IndexFromContainer(container);
                        if (deleteIndex>=0)
                        {
                            if (ItemsSource != null)
                            {
                                if (ItemsSource is System.Collections.IList list)
                                {
                                    list.RemoveAt(deleteIndex);
                                }
                                else
                                {
                                    Items.RemoveAt(deleteIndex);
                                }
                            }
                        }
                    }
                });
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            if (item is LuiAccordionItem accordionitem)
            {
                DependencyPropertyDescriptor
                .FromProperty(LuiAccordionItem.IsExpandedProperty, typeof(LuiAccordionItem))
                .AddValueChanged(accordionitem, IsExpandedChanged);
                //accordionitem.SetValue(DockPanel.DockProperty, Dock.Top);

                return true;
            }
            return false;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            var retval = new LuiAccordionItem();
            //retval.SetValue(DockPanel.DockProperty, Dock.Top);
            DependencyPropertyDescriptor
             .FromProperty(LuiAccordionItem.IsExpandedProperty, typeof(LuiAccordionItem))
             .AddValueChanged(retval, IsExpandedChanged);

            return retval;

        }

        private void IsExpandedChanged(object sender, EventArgs e)
        {
            if (sender is LuiAccordionItem accitem)
            {
                if (accitem.IsExpanded == true)
                {
                    CollapseAllItems(accitem);
                }
            }
        }

        private void CollapseAllItems(LuiAccordionItem sender)
        {
            if (!collapseAllOnExpandSingle)
            {
                return;
            }

            

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
            //foreach (var item in Items)
            //{
            //    if (ItemContainerGenerator.ContainerFromItem(item) is LuiAccordionItem itemContainer)
            //    {
            //        itemContainer.SetValue(DockPanel.DockProperty, Dock.Top);
            //    }
            //}

            //for (int i = Items.Count - 1; i > ItemContainerGenerator.IndexFromContainer(sender); i--)
            ////for (int i = ItemContainerGenerator.IndexFromContainer(sender)+1; i < Items.Count ; i++)
            //{
            //    if (ItemContainerGenerator.ContainerFromItem(Items[i]) is LuiAccordionItem itemContainer)
            //    {
            //        if (itemContainer.Index > sender.Index)
            //        {
            //            itemContainer.SetValue(DockPanel.DockProperty, Dock.Bottom);
            //        }
            //    }
            //}           
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
            if (d is LuiAccordion obj)
            {
                if (e.NewValue is bool newvalue)
                {
                    obj.CollapseAllOnExpandSingle_Intern = newvalue;
                }
            }
        }
        #endregion

        #region IDropTarget
        private UIElement m_lastDragedOverElement;

        void IDropTarget.DragOver(IDropInfo dropInfo)
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

        void IDropTarget.Drop(IDropInfo dropInfo)
        {           
            if (ItemContainerGenerator.ContainerFromItem(dropInfo.Data) is LuiAccordionItem sourceContainer)
            {
                if (ItemContainerGenerator.ContainerFromItem(dropInfo.TargetItem) is LuiAccordionItem targetContainer)
                {
                    SwapItems(sourceContainer, targetContainer);
                    RefreshAllIndexes();
                }
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

        #region Functions
        private void RefreshAllIndexes()
        {
           
            foreach (var item in Items)
            {
                if (ItemContainerGenerator.ContainerFromItem(item) is LuiAccordionItem itemContainer)
                {
                    int index = ItemContainerGenerator.IndexFromContainer(itemContainer)+1;
                    if (itemContainer.Index_Internal != index)
                    {
                        itemContainer.Index = index;
                    }
                }
            }
        }

        private void ItemsControl_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshAllIndexes();           
        }

        private void SwapItems(LuiAccordionItem source, LuiAccordionItem target)
        {
    
            int sourceIndex = ItemContainerGenerator.IndexFromContainer(source);
            int targetIndex = ItemContainerGenerator.IndexFromContainer(target);

            if (ItemsSource != null)
            {
                if (ItemsSource is System.Collections.IList list)
                {
                    if (sourceIndex != targetIndex)
                    {
                        object value = list[sourceIndex];
                        list.RemoveAt(sourceIndex);
                        list.Insert(targetIndex, value);
                    }
                }
            }
            else
            {
                if (sourceIndex != targetIndex)
                {
                    object value = Items[sourceIndex];
                    Items.RemoveAt(sourceIndex);
                    Items.Insert(targetIndex, value);
                }
            }
            
        }
        #endregion

        #region DeleteCommand
        public ICommand DeleteCommand { get; set; }
        #endregion


    }
}
