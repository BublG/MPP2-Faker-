using System;
using Library.Faker;

namespace Library.Generator
{
    public interface IGenerator
    {
        object GetValue(Type type, IFaker faker);

        bool CanGenerate(Type type);
    }
}