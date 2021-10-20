using System;
using Library.Generator;

namespace Library.Service
{
    public interface IGeneratorService
    {
        IGenerator GetGenerator(Type t);
    }
}