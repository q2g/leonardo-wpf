using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leonardo.Resources
{
    public enum LUIButtonSizeEnum
    {
        Default,
        Large,
        ExtraLarge
    }
    public static class LUIButtonSizeEnumExtensions
    {
        public static double GetButtonSize(this LUIButtonSizeEnum i_iconsize)
        {
            double iconsize = 28;
            switch (i_iconsize)
            {
                case LUIButtonSizeEnum.Default:
                    iconsize = 28;
                    break;
                case LUIButtonSizeEnum.Large:
                    iconsize = 38;
                    break;
                case LUIButtonSizeEnum.ExtraLarge:
                    iconsize = 54;
                    break;
                default:
                    iconsize = 28;
                    break;
            }
            return iconsize;
        }
    }
}
