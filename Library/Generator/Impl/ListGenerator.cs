using System;
using System.Collections.Generic;
using System.Reflection;
using Library.Faker;

namespace Library.Generator.Impl
{
    public class ListGenerator : IGenerator
    {
        private static Random _random = new Random();

        public object GetValue(Type type, IFaker faker)
        {
            List<object> list = new List<object>();
            int size = _random.Next(1, 10);
            for (int i = 0; i < size; i++)
            {
                list.Add(faker.Create(type));
            }

            return list;
        }
        
        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }
    }
}