namespace Main.Classes
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public Person(string name)
        {
            Name = name;
        }
        
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        
        public Person(int age)
        {
            Age = age;
        }
        
        public Person()
        {
        }

        // private Person()
        // {
        //     
        // }
    }
}