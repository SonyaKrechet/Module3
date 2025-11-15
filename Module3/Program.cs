using System;
using System.Collections.Generic;
using System.Linq;

public class MyException : Exception
{
    public MyException(string message) : base(message) { }
}

public class Human
{
    public string Surname { get; private set; }
    public Human(string surname)
    {
        Surname = surname;
    }
}

class Program
{
    static void Main()
    {
        List<Human> humans = new List<Human>() // создаем людишек
        {
            new Human("Иванов"),
            new Human("Петров"),
            new Human("Сидоров"),
            new Human("Алексеев"),
            new Human("Борисов")
        };

        Console.WriteLine("Введите 1 для сортировки от А до Я и 2 для сортировки от Я до А");

        try
        {
            int choice = int.Parse(Console.ReadLine());

            List<Human> sortedHumans;

            if (choice == 1)
            {
                // Сортировка от А до Я
                sortedHumans = humans.OrderBy(h => h.Surname).ToList();
                Console.WriteLine("Сортировка от А до Я:");
            }
            else if (choice == 2)
            {
                // Сортировка от Я до А
                sortedHumans = humans.OrderByDescending(h => h.Surname).ToList();
                Console.WriteLine("Сортировка от Я до А:");
            }
            else
            {
                sortedHumans = humans; // без сортировки по умолчанию
                Console.WriteLine("Выбрана сортировка по умолчанию:");
            }

            foreach (var human in sortedHumans)
            {
                Console.WriteLine(human.Surname);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Введено не число");
        }
        catch (MyException)
        {
            Console.WriteLine("Произошла неизвестная ошибка, обратитесь к администратору");
        }
        catch (TimeoutException)
        {
            Console.WriteLine("Время операции вышло");
        }
        catch (NotImplementedException)
        {
            Console.WriteLine("Метод не реализован");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Операция не поддерживается");
        }
        finally
        {
            Console.WriteLine("Довольны результатом y/n?");
            string answer = Console.ReadLine();
            if (answer == "y")
            {
                Console.WriteLine("Супер!");
            }
            else
            {
                Console.WriteLine("Увы...");
            }
        }
    }
}
