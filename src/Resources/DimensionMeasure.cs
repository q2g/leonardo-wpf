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
