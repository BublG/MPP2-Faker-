using System;
using Library.Faker;

namespace Library.Generator.Impl
{
    public class DateTimeGenerator : IGenerator
    {
        private static Random _random = new Random();

        public object Generate(Type type, IFaker faker)
        {
            return new DateTime(_random.Next(1, 2100), _random.Next(1, 13), _random.Next(1, 29),
                _random.Next(1, 24), _random.Next(1, 60), _random.Next(1, 60));
        }
        
        public bool CanGenerate(Type type)
        {
            return type == typeof(DateTime);
        }
    }
}