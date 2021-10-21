using System;
using Library.Faker;

namespace Library.Generator.Impl
{
    public class LongGenerator : IGenerator
    {
        private static Random _random = new Random();
        
        public object Generate(Type type, IFaker faker)
        {
            byte[] b = new byte[8];
            _random.NextBytes(b);
            return BitConverter.ToInt64(b, 0);
        }
        
        public bool CanGenerate(Type type)
        {
            return type == typeof(long);
        }
    }
}