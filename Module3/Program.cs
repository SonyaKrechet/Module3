using System;
using System.Net.NetworkInformation;

class MainClass
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите число");
        int number = int.Parse(Console.ReadLine());
        int result = Factorial(number);
        Console.WriteLine ($"Ответ {result}");
          
        }
    static int Factorial(in int number)
    {
        if (number == 0)
        {
            return 1;
        }
        else
        {
            return number * Factorial(number - 1);
        }
    }
}