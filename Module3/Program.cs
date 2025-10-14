using System;
    class Program
{
    static void Main(string[] args)
    {
        
        int[] result = GetArrayFromConsole();
        
        foreach (int number in result)
        {
            Console.WriteLine(number);
        }
    }
    static int[] GetArrayFromConsole()
    {
       var result = new int[5];

       for (int i = 0; i < result.Length; i++)
       {
           Console.WriteLine("Введите элемент массива номер {0}", i + 1);
           result[i] = int.Parse(Console.ReadLine());
                
        }
        Array.Sort(result);
        return result;
        
    }
}