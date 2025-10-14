using System;
    class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Напиши три любиых цвета на английском с маленькой буквы и через запятую");
        string[] colors = ShowColor();
        Console.WriteLine("Ваши любиыме цвета:");
        foreach (string color in colors) 
        {
            Console.WriteLine(color);
        }
    }

    static string[] ShowColor()
    {
        
        string input = Console.ReadLine();
        string[] colors = input.Split(',');
        return colors;
    }
}