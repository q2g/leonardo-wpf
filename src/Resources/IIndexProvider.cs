using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leonardo.Resources
{
    public interface IIndexProvider
    {
        void SetIndex(object objectWithIndexProperty, int indexValue);
        int GetIndex(object objectWithIndexProperty);
    }
}
