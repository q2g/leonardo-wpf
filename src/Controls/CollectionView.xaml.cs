namespace leonardo.Controls
{
    #region Usings
    using leonardo.Resources;
    using NLog;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
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
    #endregion

    /// <summary>
    /// Interaction logic for CollectionView.xaml
    /// </summary>
    public partial class CollectionView : UserControl, INotifyPropertyChanged
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region CTOR
        public CollectionView()
        {
            InitializeComponent();

            SetValue(ProcessedCollectionProperty, new ObservableCollection<object>());
        }
        #endregion

        private void ProcessedCollectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (var item in e.NewItems)
                        {
                            itemsSource.Add(item);
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (var item in e.OldItems)
                        {
                            itemsSource.Remove(item);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        #region ProcessedCollection - DP
        private ObservableCollection<object> processedCollection;
        internal ObservableCollection<object> ProcessedCollection_Internal
        {
            get { return processedCollection; }
            set
            {
                if (processedCollection != value)
                {
                    if (processedCollection is INotifyCollectionChanged notifyCollection_old)
                    {
                        notifyCollection_old.CollectionChanged -= ProcessedCollectionChanged_CollectionChanged;
                    }
                    processedCollection = value;
                    RaisePropertyChanged(nameof(ProcessedCollection));
                    if (processedCollection is INotifyCollectionChanged notifyCollection_new)
                    {
                        notifyCollection_new.CollectionChanged += ProcessedCollectionChanged_CollectionChanged;
                    }

                }
            }
        }
        public ObservableCollection<object> ProcessedCollection
        {
            get { return (ObservableCollection<object>)this.GetValue(ProcessedCollectionProperty); }
            set { this.SetValue(ProcessedCollectionProperty, value); }
        }

        public static readonly DependencyProperty ProcessedCollectionProperty = DependencyProperty.Register(
         "ProcessedCollection", typeof(ObservableCollection<object>), typeof(CollectionView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnProcessedCollectionChanged)));
        private static void OnProcessedCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is CollectionView obj)
                {
                    if (e.NewValue is ObservableCollection<object> newvalue)
                    {
                        obj.ProcessedCollection_Internal = newvalue;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
        #endregion

        #region ItemsSource DP
        private System.Collections.IList itemsSource;
        internal System.Collections.IList ItemsSource_Internal
        {
            get { return itemsSource; }
            set
            {
                if (itemsSource != value)
                {
                    if (itemsSource is INotifyCollectionChanged notifyCollection_old)
                    {
                        notifyCollection_old.CollectionChanged -= ItemsSource_CollectionChanged;
                    }
                    itemsSource = value;

                    if (value is INotifyCollectionChanged notifyCollection_new)
                    {
                        notifyCollection_new.CollectionChanged += ItemsSource_CollectionChanged;
                    }

                    RefreshProcessedCollectionAsync();


                }
            }
        }

        private void ItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    RefreshProcessedCollectionAsync();
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    RefreshProcessedCollectionAsync();
                }
                if (e.Action == NotifyCollectionChangedAction.Reset)
                {
                    RefreshProcessedCollectionAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public System.Collections.IList ItemsSource
        {
            get { return (System.Collections.IList)this.GetValue(ItemsSourceProperty); }
            set { this.SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
         "ItemsSource", typeof(System.Collections.IList), typeof(CollectionView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnItemsSourceChanged)));
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is CollectionView obj)
                {
                    if (e.NewValue is System.Collections.IList newvalue)
                    {
                        obj.ItemsSource_Internal = newvalue;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
        #endregion

        #region FilterText - DP   
        private string filterText;
        internal string FilterText_Internal
        {
            get { return filterText; }
            set
            {
                if (filterText != value)
                {
                    filterText = value;
                    RefreshProcessedCollectionAsync();
                }
            }
        }

        public string FilterText
        {
            get { return (string)this.GetValue(FilterTextProperty); }
            set { this.SetValue(FilterTextProperty, value); }
        }

        public static readonly DependencyProperty FilterTextProperty = DependencyProperty.Register(
         "FilterText", typeof(string), typeof(CollectionView), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnFilterTextChanged)));
        private static void OnFilterTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is CollectionView obj)
                {
                    if (e.NewValue is string newvalue)
                    {
                        obj.FilterText_Internal = newvalue;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }

        private async void RefreshProcessedCollectionAsync()
        {
            if (itemsSource == null)
            {
                return;
            }
            ObservableCollection<object> newlist = new ObservableCollection<object>();
            try
            {
                //  newlist = await Task.Run<ObservableCollection<object>>(() =>
                //{
                try
                {
                    foreach (var item in itemsSource)
                    {
                        if (collectionViewFilter != null)
                        {
                            if (collectionViewFilter.Filter(item, (filterText + "")))
                            {
                                newlist.Add(item);
                            }
                        }
                        else
                        {
                            newlist.Add(item);
                        }
                    }
                    SortCollection(newlist);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
                //return newlist;
                //});
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            ProcessedCollection = newlist;
        }
        #endregion

        #region CollectionViewFilter  IComparer
        private ICollectionViewFilter collectionViewFilter;
        internal ICollectionViewFilter CollectionViewFilter_Internal
        {
            get { return collectionViewFilter; }
            set
            {
                if (collectionViewFilter != value)
                {
                    collectionViewFilter = value;
                    RefreshProcessedCollectionAsync();
                }
            }
        }
        public ICollectionViewFilter CollectionViewFilter
        {
            get { return (ICollectionViewFilter)this.GetValue(CollectionViewFilterTextProperty); }
            set { this.SetValue(CollectionViewFilterTextProperty, value); }
        }

        public static readonly DependencyProperty CollectionViewFilterTextProperty = DependencyProperty.Register(
         "CollectionViewFilter", typeof(ICollectionViewFilter), typeof(CollectionView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnCollectionViewFilterChanged)));
        private static void OnCollectionViewFilterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is CollectionView obj)
                {
                    if (e.NewValue is ICollectionViewFilter newvalue)
                    {
                        obj.CollectionViewFilter_Internal = newvalue;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
        #endregion

        #region CollectionViewComparer  
        private IComparer collectionViewComparer;
        internal IComparer CollectionViewComparer_Internal
        {
            get { return collectionViewComparer; }
            set
            {
                if (collectionViewComparer != value)
                {
                    collectionViewComparer = value;
                    SortCollection(processedCollection);
                }
            }
        }
        public IComparer CollectionViewComparer
        {
            get { return (IComparer)this.GetValue(CollectionViewComparerProperty); }
            set { this.SetValue(CollectionViewComparerProperty, value); }
        }

        public static readonly DependencyProperty CollectionViewComparerProperty = DependencyProperty.Register(
         "CollectionViewComparer", typeof(IComparer), typeof(CollectionView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnCollectionViewComparerChanged)));
        private static void OnCollectionViewComparerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is CollectionView obj)
                {
                    if (e.NewValue is IComparer newvalue)
                    {
                        obj.CollectionViewComparer_Internal = newvalue;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }

        private object SortCollection(ObservableCollection<object> list)
        {
            if (collectionViewComparer == null)
            {
                return null;
            }
            if (list == null)
            {
                return null;
            }

            //BubbleSort FTW!
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i != j)
                    {
                        if (!sortDescending)
                        {
                            if (collectionViewComparer.Compare(list[i], list[j]) > 0)
                            {
                                list.Move(j, i);
                            }
                            if (collectionViewComparer.Compare(list[i], list[j]) < 0)
                            {
                                list.Move(i, j);
                            }
                        }
                        else
                        {
                            if (collectionViewComparer.Compare(list[i], list[j]) < 0)
                            {
                                list.Move(j, i);
                            }
                            if (collectionViewComparer.Compare(list[i], list[j]) > 0)
                            {
                                list.Move(i, j);
                            }
                        }
                    }
                }
            }
            return new object();
        }
        #endregion

        #region SortDescending - DP   
        private bool sortDescending = false;
        internal bool SortDescending_Internal
        {
            get { return sortDescending; }
            set
            {
                if (sortDescending != value)
                {
                    sortDescending = value;
                    SortCollection(processedCollection);
                }
            }
        }
        public bool SortDescending
        {
            get { return (bool)this.GetValue(SortDescendingProperty); }
            set { this.SetValue(SortDescendingProperty, value); }
        }

        public static readonly DependencyProperty SortDescendingProperty = DependencyProperty.Register(
         "SortDescending", typeof(bool), typeof(CollectionView), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnSortDescendingChanged)));


        private static void OnSortDescendingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (d is CollectionView obj)
                {
                    if (e.NewValue is bool newvalue)
                    {
                        obj.SortDescending_Internal = newvalue;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex);
            }
        }
        #endregion
    }
}
