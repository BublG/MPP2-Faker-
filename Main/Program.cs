using System;
using System.Collections.Generic;
using Library.Faker;
using Library.Faker.Impl;
using Main.Classes;

namespace Main
{
    class Program
    {
        public static void Main(string[] args)
        {
            IFaker faker = new Faker();
            Console.WriteLine(faker.Create<int>());
            Console.WriteLine(faker.Create<double>());
            Person p = faker.Create<Person>();
            Console.WriteLine(p.Age + "  " + p.Name);
            List<byte> list = faker.Create<List<byte>>();
            foreach (var b in list)
            {
                Console.Write(b + ", ");
            }
            Console.WriteLine();
            Console.WriteLine(faker.Create<DateTime>());
            //faker.Create<A>();
        }
    }
}