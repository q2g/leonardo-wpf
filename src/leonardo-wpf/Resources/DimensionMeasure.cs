using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leonardo.Resources
{
    public class DimensionMeasure
    {
        public string Text { get; set; }
        public bool? Dimension { get; set; }
        public string LibID { get; set; }

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
