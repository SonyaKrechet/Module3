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
        var name = Console.ReadLine();
        Console.WriteLine("Enter your age");
        var age = checked((byte)int.Parse(Console.ReadLine()));
        Console.WriteLine("Your name is {0} and age is {1} ", name, age);

        Console.Write("What is your favorite day of week? ");

        var day = (DayOfWeek)int.Parse(Console.ReadLine());
        Console.WriteLine("Your favorite day is {0}", day);
        Console.WriteLine("Enter your birthday");
        var birthday = DateOnly.Parse(Console.ReadLine());
        Console.WriteLine("Your birthday date is {0}", birthday);


    }



}
