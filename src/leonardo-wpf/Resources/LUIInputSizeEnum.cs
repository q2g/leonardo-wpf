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
        Large,
        Custom

    }
    public static class LUIInputSizeEnumExtensions
    {
        public static double GetInputSize(this LUIInputSizeEnum i_inputsize)
        {
            double inputsize = 28;
            switch (i_inputsize)
            {
                case LUIInputSizeEnum.Default:
                    inputsize = 28;
                    break;
                case LUIInputSizeEnum.Large:
                    inputsize = 38;
                    break;
                case LUIInputSizeEnum.Custom:
                    inputsize = 0;
                    break;

                default:
                    inputsize = 28;
                    break;
            }
            return inputsize;
        }
    }
}
