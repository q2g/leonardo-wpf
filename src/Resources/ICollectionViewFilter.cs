namespace leonardo.Resources
{
    public interface ICollectionViewFilter
    {
        bool Filter(object data, string searchString);
    }
}
