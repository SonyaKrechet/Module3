using System;
using System.Xml.Linq;
enum DayOfWeeks
{
    Monday = 1,
    Tuesday = 2
}

class MainClass
{
    public static void Main(string[] args)
    
        {
      

      
        Console.WriteLine("Enter your name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter your age");
        int age = checked((int.Parse(Console.ReadLine())));

        Console.WriteLine("Your name is {0} and age is {1}", name, age);
        Console.WriteLine("What is your favourite day of week");
        byte day = checked((byte.Parse(Console.ReadLine())));
        Console.WriteLine("Your favourite day is {0}", (DayOfWeeks) day);

        Console.ReadKey();
        }


    
}
