using System;
using System.Net.NetworkInformation;

class MainClass
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите число");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите степень");
        byte pow = byte.Parse(Console.ReadLine());
        int result = PowerUp(number, pow);
        Console.WriteLine ($"Ответ {result}");
          
        }
    private static int PowerUp(int number, byte pow)
    {
        if (pow == 0)
            return 1;            
        else
            return number * PowerUp(number, (byte)(pow - 1));
    }
}