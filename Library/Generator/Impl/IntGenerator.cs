﻿using System;

namespace Library.Generator.Impl
{
    public class IntGenerator : IGenerator
    {
        private static Random _random = new Random();
        public object GetValue()
        {
            return _random.Next();
        }
    }
}