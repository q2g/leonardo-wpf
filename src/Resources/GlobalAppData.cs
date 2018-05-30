using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leonardo.Resources
{
    public class GlobalAppData
    {
        public DataHolder DataHolder { get; set; }
        static GlobalAppData instance;
        public static GlobalAppData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalAppData();
                }
                return instance;
            }
        }

        public GlobalAppData()
        {
            DataHolder = new DataHolder();
        }

    }
}
