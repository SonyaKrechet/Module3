using System;
using System.Security.Cryptography.X509Certificates;

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите количество элементов массива");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Введите элементы массива");
        for (int i = 0; i < n; i++) 
        { Console.Write($"arr[{i}]=");
            arr[i] = int.Parse(Console.ReadLine());
        }
        SortArray(arr);
        Console.WriteLine(string.Join(", ", arr));
    }
    static void SortArray(int[] arr)
    {
        Array.Sort(arr);
        
    }


        
    
}