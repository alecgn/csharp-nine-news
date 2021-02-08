using System;

namespace FitAndFinishFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("In C# 9.0, you can omit the type in a new expression when the created object's type is already known.");
            Console.WriteLine("Consider the following class:");
            Console.WriteLine("\npublic class Person");
            Console.WriteLine("{");
            Console.WriteLine("\tpublic Person(string name, int age)");
            Console.WriteLine("\t{");
            Console.WriteLine("\t\tName = name;");
            Console.WriteLine("\t\tAge = age;");
            Console.WriteLine("\t}\n");
            Console.WriteLine("\tpublic string Name { get; set; }");
            Console.WriteLine("\tpublic int Age { get; set; }");
            Console.WriteLine("}");
            Console.WriteLine("\nTo create a new instance, you can do simply as follows:");
            Console.WriteLine("\nPerson person = new(\"John\", 40);");
            Person person = new("John", 40);
            Console.WriteLine($"\nValue of {nameof(person)}.{nameof(Person.Name)}: {person.Name}.");
            Console.WriteLine($"Value of {nameof(person)}.{nameof(Person.Age)}: {person.Age}.");
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
