namespace leonardo.Resources
{
    public enum LuiFontSizeEnum
    {
        Small,
        Normal,
        Large
    }
    public static class LuiFontSizeEnumExtensions
    {
        public static double GetFontSize(this LuiFontSizeEnum i_iconsize)
        {
            double iconsize = 16;
            switch (i_iconsize)
            {
                case LuiFontSizeEnum.Small:
                    iconsize = 12;
                    break;
                case LuiFontSizeEnum.Normal:
                    iconsize = 16;
                    break;
                case LuiFontSizeEnum.Large:
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
