namespace leonardo.Resources
{
    public interface IIndexProvider
    {
        void SetIndex(object objectWithIndexProperty, int indexValue);
        int GetIndex(object objectWithIndexProperty);
    }
}
