namespace leonardo.Resources
{
    public interface ICollectionViewFilter
    {
        bool Filter(object data, string searchString);
    }

    public class FilterNothing : ICollectionViewFilter
    {
        public bool Filter(object data, string searchString)
        {
            return true;
        }
    }
}
