using System;
using System.ComponentModel.Design;
using System.Globalization;


class MainClass
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Ваше имя");
        string name = Console.ReadLine();
        Console.WriteLine("Ваша фамилия");
        string surname = Console.ReadLine();
        Console.WriteLine("Ваш возраст");
        string ageCheck = Console.ReadLine();
        int age = CheckInt(ageCheck);
        Console.WriteLine("Есть ли у вас питомцы?");
        string petsCheck = Console.ReadLine();
        bool pets = CheckBool(petsCheck);
        string[] petNames = null;
        if (pets == true)
        {
            Console.WriteLine("Сколько у вас питомцев?");
            string petCheck = Console.ReadLine();
            int petNumber = CheckInt(petCheck);
            petNames = PetNames(petNumber);

        }
        else petNames = new string[0];
            Console.WriteLine("Сколько у вас любимых цветов?");
        string colorsCheck = Console.ReadLine();
        int colorNumber = CheckInt(colorsCheck);
        string[] colors = Colors(colorNumber);
        var anketa = (name: name, surname: surname, age: age, pets: string.Join(",", petNames), colors: string.Join(",", colors));
        Console.WriteLine($"Имя: {anketa.name}, Фамилия: {anketa.surname}, Возраст: {anketa.age}");
        Console.WriteLine($"Питомцы: {anketa.pets}");
        Console.WriteLine($"Любимые цвета: {anketa.colors}");
    }
     public static string[] PetNames (int PetNumber)
    {
        string[] pets = new string[PetNumber];
        for (int i = 0; i < PetNumber; i++)
        {
            Console.WriteLine($"Введите кличку питомца {i + 1}");
            pets[i] = Console.ReadLine();
            
        }
        return pets;
    }
    public static string[] Colors(int ColorNumber)
    {
        string[] colors = new string[ColorNumber];
        for (int i = 0; i < ColorNumber; i++)
        {
            Console.WriteLine($"Введите любимый цвет {i + 1}");
            colors[i] = Console.ReadLine();
            
        }
        return colors;
    }
    public static bool CheckBool(string petsCheck)
    {
        while (true)
        {

            if (petsCheck == "true")
                return true;
            if (petsCheck == "false")
                return false;

            else

                Console.WriteLine("Ошибка: нужно ввести true/false. Попробуйте снова.");
            petsCheck = Console.ReadLine();
        }
    }
    public static int CheckInt(string intCheck)
    {
        while (true)
        {

            if (int.TryParse(intCheck, out int result))
            { 
                if (result != 0)
                
                    return result;
                else
                        Console.WriteLine("Ошибка: число не может быть меньше или равно 0. Попробуйте снова.");
             }
            else

                Console.WriteLine("Ошибка: нужно ввести число. Попробуйте снова.");
            intCheck = Console.ReadLine();
        }
        
    }

}
    
