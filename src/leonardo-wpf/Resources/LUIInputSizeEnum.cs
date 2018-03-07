using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leonardo.Resources
{
    public enum LUIInputSizeEnum
    {
        Default,
        Large
        
    }
    public static class LUIInputSizeEnumExtensions
    {
        public static double GetInputSize(this LUIInputSizeEnum i_iconsize)
        {
            double iconsize = 28;
            switch (i_iconsize)
            {
                case LUIInputSizeEnum.Default:
                    iconsize = 28;
                    break;
                case LUIInputSizeEnum.Large:
                    iconsize = 38;
                    break;
               
                default:
                    iconsize = 28;
                    break;
            }
            return iconsize;
        }
    }
}
