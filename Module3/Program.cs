using System;
using System.Drawing;
using System.Net.NetworkInformation;

class MainClass
{
    public static void Main(string[] args)
    {
        
        var user = Profile();
        string[] colors = ShowColor(user.name);
        
        Console.WriteLine($"You profile is: {user.name}, {user.age}");
        foreach (string color in colors)
        {
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
            Console.WriteLine($"Ваш любимый цвет: {color}");
        }
    }

    static (string name, int age) Profile()
    {
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();
        Console.Write("Введите возраст с цифрами: ");
        int age = Convert.ToInt32(Console.ReadLine());
        var user = (name, age);
        return user;
    }
    static string[] ShowColor(string name)
    {
        
        string[] colors = new string[3];

        int i = 0;
        while (i < colors.Length)
        {
            Console.Write($"{name} Введите любимый цвет #{i + 1}: ");
            colors[i] = Console.ReadLine();
            i++;
        }
        return colors;
    }

    
}