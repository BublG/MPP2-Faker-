using System;
using Library.Faker;

namespace Library.Generator.Impl
{
    public class DoubleGenerator : IGenerator
    {
        private static Random _random = new Random();
        public object Generate(Type type, IFaker faker)
        {
            return _random.NextDouble() * _random.Next();
        }
        
        public bool CanGenerate(Type type)
        {
            return type == typeof(double);
        }
    }
}