using System;

namespace Library.Generator.Impl
{
    public class ByteGenerator : IGenerator
    {
        private static Random _random = new Random();
        
        public object GetValue()
        {
            byte[] b = new byte[1];
            _random.NextBytes(b);
            return b[0];
        }
    }
}