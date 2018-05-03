namespace leonardo.Resources
{
    public enum LuiInputSizeEnum
    {
        Default,
        Large,
        Custom

    }
    public static class LuiInputSizeEnumExtensions
    {
        public static double GetInputSize(this LuiInputSizeEnum i_inputsize)
        {
            double inputsize = 28;
            switch (i_inputsize)
            {
                case LuiInputSizeEnum.Default:
                    inputsize = 28;
                    break;
                case LuiInputSizeEnum.Large:
                    inputsize = 38;
                    break;
                case LuiInputSizeEnum.Custom:
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
