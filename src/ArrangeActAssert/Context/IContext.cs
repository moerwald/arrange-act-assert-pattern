namespace ArrangeActAssert.Context
{
    public interface IContext
    {
        void Add<T>(string name, T value);
        T Get<T>(string name);
    }
}
