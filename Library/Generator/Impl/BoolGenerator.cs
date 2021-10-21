using System;
using Library.Faker;

namespace Library.Generator.Impl
{
    public class BoolGenerator : IGenerator
    {
        private static Random _random = new Random();
        
        public object Generate(Type type, IFaker faker)
        {
            return _random.Next(2) == 1;
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }
    }
}