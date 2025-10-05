using System;

class Program
{
    static void Main(string[] args)
    {

        for (int k = 2; k >= 0; k--)
        {
            (string name, string surname, string login, int loginlength, bool pet, int age, string[] colors) user;
            Console.WriteLine("Ваше имя?");
            user.name = Console.ReadLine();
            Console.WriteLine("Ваша фамилия?");
            user.surname = Console.ReadLine();
            Console.WriteLine("Ваш логин?");
            user.login = Console.ReadLine();
            user.loginlength = user.login.Length;
            while (true)
            {
                Console.WriteLine("Есть ли у вас животные? Да или Нет");
                string answer = Console.ReadLine();
                if (answer == "Да")
                {
                    user.pet = true;
                    break;
                }
                if (answer == "Нет")
                {
                    user.pet = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Ответ да или нет");
                }
            }
            Console.WriteLine("Ваш возраст?");
            user.age = int.Parse(Console.ReadLine());


            Console.WriteLine("Введите три любимых цвета");
            user.colors = new string[3];

            for (int i = 0; i < 3; i++)
            {
                user.colors[i] = Console.ReadLine();
            }

        }
    }
}
