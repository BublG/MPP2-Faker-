using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Library.Generator;
using Library.Generator.Impl;

namespace Library.Faker.Impl
{
    public class Faker : IFaker
    {
        private static List<IGenerator> _generators = new List<IGenerator>()
        {
            new BoolGenerator(),
            new ByteGenerator(),
            new IntGenerator(),
            new LongGenerator(),
            new FloatGenerator(),
            new DoubleGenerator(),
            new StringGenerator(),
            new DateTimeGenerator(),
            new ListGenerator()
        };

        public T Create<T>()
        {
            return (T) Create(typeof(T));
        }

        public object Create(Type type)
        {
            foreach (var generator in _generators)
            {
                if (generator.CanGenerate(type))
                {
                    return generator.Generate(type, this);
                }
            }

            object instance = GetInstanceByConstructor(type);
            if (instance == null)
            {
                GetDefaultValue(type);
            }

            SetPublicFields(instance);
            SetPublicProperties(instance);
            return instance;
        }

        private static object GetDefaultValue(Type t)
        {
            return t.IsValueType ? Activator.CreateInstance(t) : null;
        }

        private object GetInstanceByConstructor(Type type)
        {
            var constructors = type.GetConstructors();
            if (constructors.Length > 0)
            {
                Array.Sort(constructors, (x, y)
                    => y.GetParameters().Length - x.GetParameters().Length);
                for (int i = 0; i < constructors.Length; i++)
                {
                    ConstructorInfo constructor = constructors[i];
                    object[] parameters = new object[constructor.GetParameters().Length];
                    int j = 0;
                    foreach (var parameter in constructor.GetParameters())
                    {
                        parameters[j++] = Create(parameter.ParameterType);
                    }

                    try
                    {
                        return constructor.Invoke(parameters);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }

            return null;
        }

        private void SetPublicFields(object instance)
        {
        }

        private void SetPublicProperties(object instance)
        {
        }
    }
}