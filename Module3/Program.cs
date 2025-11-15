using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

public interface ILogger
{
    void LogInfo(string message);   // События
    void LogError(string message);  // Ошибки
}

public class ConsoleLogger : ILogger
{
    public void LogInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue; 
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public void LogError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
public interface ICalculator
{
    int Add(int a, int b);
}

public class Calculator: ICalculator
{
    private readonly ILogger _logger;

    public Calculator(ILogger logger)
    {
        _logger = logger;
    }
    public int Add(int a, int b)
    {
        int result =  a + b;
        _logger.LogInfo($"Выполнено сложение: {a} + {b} = {result}");
        return result;
    }
}

class Program
{
    static void Main()
    {
        ILogger logger = new ConsoleLogger();
        Calculator calculator = new Calculator(logger);
        try
        {
            Console.WriteLine("Введите первое число:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите второе число:");
            int b = int.Parse(Console.ReadLine());

            int result = calculator.Add(a, b);
            Console.WriteLine($"Ответ: {result}");
        }
        catch (FormatException ex)
        {
            logger.LogError("Некорректный формат введенного числа!");
        }
        catch (Exception ex)
        {
            logger.LogError($"Произошла ошибка: {ex.Message}");
        }

    }
}
