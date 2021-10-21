using System;

namespace Library.Generator.Impl
{
    public class FloatGenerator : IGenerator
    {
        private static Random _random = new Random();
        
        public object GetValue()
        {
            return _random.NextDouble() * _random.Next(9999);
        }
    }
}