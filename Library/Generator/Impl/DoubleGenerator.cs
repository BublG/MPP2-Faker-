using System;

namespace Library.Generator.Impl
{
    public class DoubleGenerator : IGenerator
    {
        private static Random _random = new Random();
        public object GetValue()
        {
            return _random.NextDouble() * _random.Next();
        }
    }
}