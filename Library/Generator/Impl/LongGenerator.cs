using System;

namespace Library.Generator.Impl
{
    public class LongGenerator : IGenerator
    {
        private static Random _random = new Random();
        
        public object GetValue()
        {
            byte[] b = new byte[8];
            _random.NextBytes(b);
            return BitConverter.ToInt64(b, 0);
        }
    }
}