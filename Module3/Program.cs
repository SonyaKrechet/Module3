using System;

class MainClass
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Your name?");
        string name = Console.ReadLine();
        Console.WriteLine("Your age?");
        byte age = byte.Parse(Console.ReadLine());
        Console.WriteLine("Have a pet?");
        bool pet = bool.Parse(Console.ReadLine());
        Console.WriteLine("Foot size?");
        double size = double.Parse(Console.ReadLine());

        Console.WriteLine("My name is {0} \n My age is {1}, \n Do I have a pet? {2}; \n My foot size {3}", name, age, pet, size);

        Console.ReadKey();

    }
}