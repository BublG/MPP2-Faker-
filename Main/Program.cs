using System;
using Library.Faker;
using Library.Faker.Impl;
using Main.Classes;

namespace Main
{
    class Program
    {
        public static void Main(string[] args)
        {
            Person p = new Person();
            p.Age = 15;
            p.Name = "sdg";
            //Console.WriteLine(p.Age + p.Name);

            IFaker faker = new Faker();
            Person person = faker.Create<Person>();
            Console.WriteLine(person.Name + "   " + person.Age);
        }
    }
}
