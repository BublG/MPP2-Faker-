using System;
using System.Security.Principal;
using Library.Generator;
using Library.Generator.Impl;

namespace Library.Service.Impl
{
    public class DefaultGeneratorService : IGeneratorService
    {
        public IGenerator GetGenerator(Type t)
        {
            if (t == typeof(int))
            {
                return IntGenerator.GetInstance();
            }
            else if (t == typeof(double))
            {
                return DoubleGenerator.GetInstance();
            } else if (t == typeof(string))
            {
                return StringGenerator.GetInstance();
            }
            else return null;
        }
    }
}