using System;
using Library.Faker;

namespace Library.Generator.Impl
{
    public class IntGenerator : IGenerator
    {
        private static Random _random = new Random();
        public object GetValue(Type type, IFaker faker)
        {
            return _random.Next();
        }
        
        public bool CanGenerate(Type type)
        {
            return type == typeof(int);
        }
    }
}