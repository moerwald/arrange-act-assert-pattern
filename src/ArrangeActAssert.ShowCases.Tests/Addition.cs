namespace ArrangeActAssert.ShowCases.Tests
{
    public interface IAddition
    {
        int Add();
    }

    public class Addition : IAddition
    {
        private readonly int _a;
        private readonly int _b;

        public Addition(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public int Add() => _a + _b;


    }
}
