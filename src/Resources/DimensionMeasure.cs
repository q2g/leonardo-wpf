namespace leonardo.Resources
{
    #region Usings
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    #endregion


    public class DimensionMeasure
    {
        private string text;
        private string grouping;
        private bool? dimension;
        private string libID;
        private string formula;
        private string dimensionField;
        private bool isSingleFieldDimension;
        private bool isDrillDown;
        private string[] fieldList;
        private string dimensionDimName;
        private int belongsToHwnd;

        public string Text
        {
            get => text;
            set
            {
                if (text != value)
                {
                    text = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Grouping
        {
            get => grouping;
            set
            {
                if (grouping != value)
                {
                    grouping = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string DimensionField
        {
            get => dimensionField;
            set
            {
                if (dimensionField != value)
                {
                    dimensionField = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool IsSingleFieldDimension
        {
            get => isSingleFieldDimension;
            set
            {
                if (isSingleFieldDimension != value)
                {
                    isSingleFieldDimension = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool IsDrillDown
        {
            get => isDrillDown;
            set
            {
                if (isDrillDown != value)
                {
                    isDrillDown = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string[] FieldList
        {
            get => fieldList;
            set
            {
                if (fieldList != value)
                {
                    fieldList = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string Formula
        {
            get => formula;
            set
            {
                if (formula != value)
                {
                    formula = value;
                    RaisePropertyChanged();
                }
            }
        }
        public bool? Dimension
        {
            get => dimension;
            set
            {
                if (dimension != value)
                {
                    dimension = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string LibID
        {
            get => libID;
            set
            {
                if (libID != value)
                {
                    libID = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string DimensionDimName
        {
            get => dimensionDimName;
            set
            {
                if (dimensionDimName != value)
                {
                    dimensionDimName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int BelongsToHwnd
        {
            get => belongsToHwnd;
            set
            {
                if (belongsToHwnd != value)
                {
                    belongsToHwnd = value;
                    RaisePropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        public static DimensionMeasure GetDimensionMeasureByLibraryID(IEnumerable<DimensionMeasure> items, string libraryId, bool? dimension)
        {
            DimensionMeasure defaultValue = new DimensionMeasure() { Dimension = dimension, LibID = libraryId, Text = libraryId };
            if (items != null)
            {
                return items
                    .Where(ele => ele.LibID == libraryId && ele.Dimension == dimension)
                    .DefaultIfEmpty(defaultValue)
                    .Single();
            }
            return defaultValue;
        }
    }


}
