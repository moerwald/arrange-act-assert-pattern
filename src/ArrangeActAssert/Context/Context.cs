namespace ArrangeActAssert.Context
{
    public class Context  : IContext
    {
        public Context()
        {
        }

        public void Add<T>(string v, T a)
        {
            throw new System.NotImplementedException();
        }

        public T Get<T>(string v)
        {
            throw new System.NotImplementedException();
        }
    }
}