using System;
using System.Collections;
using System.Collections.Generic;
using Library.Faker;

namespace Library.Generator.Impl
{
    public class ListGenerator : IGenerator
    {
        private static Random _random = new Random();

        public object Generate(Type type, IFaker faker)
        {
            int size = _random.Next(1, 10);
            var list = (IList) Activator.CreateInstance(type);
            for (int i = 0; i < size; i++)
            {
                list.Add(faker.Create(type.GenericTypeArguments[0]));
            }

            return list;
        }
        
        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }
    }
}