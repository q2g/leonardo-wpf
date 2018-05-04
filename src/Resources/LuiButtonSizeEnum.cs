namespace leonardo.Resources
{
    public enum LuiButtonSizeEnum
    {
        Default,
        Large,
        ExtraLarge
    }
    public static class LuiButtonSizeEnumExtensions
    {
        public static double GetButtonSize(this LuiButtonSizeEnum i_iconsize)
        {
            double iconsize = 28;
            switch (i_iconsize)
            {
                case LuiButtonSizeEnum.Default:
                    iconsize = 28;
                    break;
                case LuiButtonSizeEnum.Large:
                    iconsize = 38;
                    break;
                case LuiButtonSizeEnum.ExtraLarge:
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
