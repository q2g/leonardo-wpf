using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leonardo.Resources
{
    public class DataHolder
    {
        public DataHolder()
        {
            Data = new Dictionary<string, object>();
        }

        public T Get<T>(string Key) where T : class
        {
            if (Data.TryGetValue(Key, out var value))
            {
                return value as T;
            }
            return null;
        }

        public void Set(string Key, object value)
        {
            if (!Data.ContainsKey(Key))
            {
                Data.Add(Key, value);
            }
            Data[Key] = value;
        }

        public Dictionary<string, object> Data { get; set; }
    }
}
