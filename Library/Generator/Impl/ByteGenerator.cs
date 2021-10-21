using System;
using Library.Faker;

namespace Library.Generator.Impl
{
    public class ByteGenerator : IGenerator
    {
        private static Random _random = new Random();
        
        public object Generate(Type type, IFaker faker)
        {
            byte[] b = new byte[1];
            _random.NextBytes(b);
            return b[0];
        }
        
        public bool CanGenerate(Type type)
        {
            return type == typeof(byte);
        }
    }
}