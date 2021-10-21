using System;
using System.Linq;

namespace Library.Generator.Impl
{
    public class StringGenerator : IGenerator
    {
        private static Random _random = new Random();
        private static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public object GetValue()
        {
            return MakeRandomString(_random.Next(5, 15));
        }
        
        private string MakeRandomString(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}