using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leonardo.Resources
{
    public enum LUIFontSizeEnum
    {
        Small,
        Normal,
        Large
    }
    public static class LUIFontSizeEnumExtensions
    {
        public static double GetFontSize(this LUIFontSizeEnum i_iconsize)
        {
            double iconsize = 16;
            switch (i_iconsize)
            {
                case LUIFontSizeEnum.Small:
                    iconsize = 12;
                    break;
                case LUIFontSizeEnum.Normal:
                    iconsize = 16;
                    break;
                case LUIFontSizeEnum.Large:
                    iconsize = 20;
                    break;
                default:
                    iconsize = 16;
                    break;
            }
            return iconsize;
        }
    }
}
