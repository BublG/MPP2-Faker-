using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Library.CustomException;
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
            new LongGenerator(),
            new FloatGenerator(),
            new DoubleGenerator(),
            new StringGenerator(),
            new ListGenerator()
        };

        private static string _pluginsPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent
                                                 .Parent.FullName + "/Library/Plugins";

        private ISet<Type> _usedTypes = new HashSet<Type>();

        public Faker()
        {
            InstallPlugins();
        }

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

            if (_usedTypes.Contains(type))
            {
                string classes = "";
                foreach (var usedType in _usedTypes)
                {
                    classes += usedType.Name + ", ";
                }

                throw new СyclicalDependencyException("Cyclical dependency in classes: " + classes);
            }

            _usedTypes.Add(type);

            object instance = GetInstanceByConstructor(type);
            if (instance == null)
            {
                return GetDefaultValue(type);
            }

            SetPublicFields(instance);
            SetPublicProperties(instance);
            _usedTypes.Remove(type);

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
                    catch (Exception)
                    {
                    }
                }
            }

            return null;
        }

        private void SetPublicFields(object instance)
        {
            Type type = instance.GetType();
            foreach (var field in type.GetFields())
            {
                if (Equals(field.GetValue(instance), GetDefaultValue(field.FieldType)))
                {
                    field.SetValue(instance, Create(field.FieldType));
                }
            }
        }

        private void SetPublicProperties(object instance)
        {
            Type type = instance.GetType();
            foreach (var property in type.GetProperties())
            {
                if (Equals(property.GetValue(instance), GetDefaultValue(property.PropertyType)))
                {
                    property.SetValue(instance, Create(property.PropertyType));
                }
            }
        }

        private void InstallPlugins()
        {
            var pluginFiles = Directory.GetFiles(_pluginsPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);
                var types = asm.GetTypes()
                    .Where(t => t.GetInterfaces()
                        .Any(i => i.FullName == typeof(IGenerator).FullName));
                foreach (var type in types)
                {
                    _generators.Add(asm.CreateInstance(type.FullName) as IGenerator);
                }
            }
        }
    }
}