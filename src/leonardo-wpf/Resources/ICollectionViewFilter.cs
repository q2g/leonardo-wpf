using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leonardo_wpf.Resources
{
    public interface ICollectionViewFilter
    {
        bool Filter(object data, string searchString);
    }
}
