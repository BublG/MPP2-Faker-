using System;
using System.Collections;
using System.Reflection;

namespace Library.Faker.Impl
{
    public class Faker : IFaker
    {
        public T Create<T>()
        {
            Type type = typeof(T);
            var constructors = type.GetConstructors();
            Array.Sort(constructors, (x, y)
                => y.GetParameters().Length - x.GetParameters().Length);
            ConstructorInfo constructorInfo = constructors[0];
            Console.WriteLine(constructorInfo);
            T obj = (T) constructorInfo.Invoke(new object[] {"Artyom", 19});
            return obj;
        }
    }
}