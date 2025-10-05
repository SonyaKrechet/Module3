using System;
class Program

{ static void Main(string[] args)
    {

        int[,] numbers = {
            { 1, 2, 3 },
            { 5, 7, 9 },
            { 10, 11, 12 },
            {13, 15, 17 }
        };
         for (int i = 0; i < numbers.GetUpperBound(1) + 1; i++)
        { for (int k = 0; k < numbers.GetUpperBound(0) + 1; k++)
            { Console.Write(numbers[k, i] + " "); }
            Console.WriteLine();
}


    }
    
        }
