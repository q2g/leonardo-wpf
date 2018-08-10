namespace leonardo.Resources
{
    #region Usings
    using System.Linq;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    #endregion


    public class DimensionMeasure
    {
        private string text;
        private bool? dimension;
        private string libID;
        private string formula;
        private string dimensionField;
        private bool isSingleFieldDimension;
        private bool isDrillDown;
        private string[] fieldList;

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
