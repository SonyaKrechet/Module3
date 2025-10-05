using System;
using System.Security.Cryptography;
using System.Xml.Linq;

class MainClass

{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите ваше имя");
        string name = Console.ReadLine();
        
        char[] letters = name.ToCharArray();
        Console.WriteLine("Ваше имя в обратном порядке:");
        for (int i = letters.Length - 1; i >= 0; i--)
        {
            Console.Write(letters[i] + " ");

                }
        
        Console.ReadKey();
    }

    

}
