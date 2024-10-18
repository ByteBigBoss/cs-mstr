using System;

namespace FirstCSharpApp
{
    // BASE CLASS
    public class Person
    {
        // ENCAPSULATION: PRIVATE FIELD WITH PUBLIC PROPERTIES
        private string name;

        public string Name
        {
            get {return name;}
            set {name = value;}
        }

        public Person(string name)
        {
            this.name = name;
        }

        // VIRTUAL METHOD FOR POLYMORPHISM
        public virtual void Great()
        {
            Console.WriteLine($"Hello, my name is {Name}.");
        }
    }

    // DERIVED CLASS
    public class Employee : Person
    {
        public string JobTitle {get; set;}

        // INHERITANCE: USING BASE CLASS CONSTRUCTOR
        public Employee(string name, string jobTitle): base(name)
        {
            JobTitle = jobTitle;
        }

        //OVERRIDE METHOD FOR POLYMORPHISM
        public override void Great()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am a {JobTitle}.");
        }
    }

    //============MAIN===========//
    class Program
    {
        static void Main(string[] args)
        {
            //CREATING OBJECTS
            Person person = new Person("Alice");
            Employee employee = new Employee("Bob", "Software Engineer");

            // POLYMORPHISM: CALLING METHODS
            person.Great();
            employee.Great();
        }
    }
}