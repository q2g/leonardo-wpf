using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leonardo.Resources
{
    public interface ICollectionViewFilter
    {
        bool Filter(object data, string searchString);
    }
}
