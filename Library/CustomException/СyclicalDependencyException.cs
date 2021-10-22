using System;

namespace Library.CustomException
{
    public class СyclicalDependencyException : Exception
    {
        public СyclicalDependencyException(string message) : base(message)
        {
            
        }
    }
}