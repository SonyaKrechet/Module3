using System;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;

abstract class Delivery
{
    public string Address;
    public Delivery(string address)
    {
        Address = address;
    }
}

class HomeDelivery : Delivery
{
    public HomeDelivery(string address) : base(address) { }
}

class PickPointDelivery : Delivery
{
    public string Company;
    public PickPointDelivery(string address, string company) : base(address)
    {
        Company = company;
    }
}

class ShopDelivery : Delivery
{
    public ShopDelivery(string address) : base(address) { }
}

class Customer
{
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public List<Product> Cart { get; private set; } = new List<Product>(); //корзина для продуктов
    public Customer(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }
    public decimal CalculateTotal() //считаем сумму заказа
    {
        decimal total = 0;
        foreach (var product in Cart)
        {
            total += product.Price;
        }
        return total;
    }
}
class Product
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public Product (string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
class Program
{
    static void Main(string[] args)

    {
        List<Product> products = new List<Product> // создаем продукты
        {
            new Product("Пицца", 1000),
            new Product("Суши", 1500),
            new Product("Напиток", 200)
        };
        

        Console.WriteLine("Введите ваше имя");
        string name = Console.ReadLine();
        Console.WriteLine("Введите ваш телефон");
        string phone = Console.ReadLine();
        Customer customer = new Customer(name, phone);
        Console.WriteLine("Выберите продукты из списка. Перечислите выбранные продукты номерами через запятую. Для отмены введите 0");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].Name} — {products[i].Price} руб.");
        }
        string input = Console.ReadLine();
        if (input == "0")
        {
            Console.WriteLine("Вы отменили выбор продуктов.");
        }
        else
        {
            string[] choices = input.Split(',');
            foreach (var c in choices)
            {
                int index;
                if (int.TryParse(c, out index) && index > 0 && index <= products.Count)
                {
                    customer.Cart.Add(products[index - 1]);
                }
            }
        }
        decimal total = customer.CalculateTotal();
        Console.WriteLine($"Сумма заказа = {total}. Подтвердить y/n?");
        string answer = Console.ReadLine();
        if ( answer == "y" )
        {
              Console.WriteLine("Выберите тип доставки: 1 - Дом, 2 - ПВЗ, 3 - Магазин");
              string deliveryChoice = Console.ReadLine();
              Delivery delivery = null;
              switch (deliveryChoice)
                {
                    case "1":
                        Console.WriteLine("Введите адрес доставки:");
                        string homeAddress = Console.ReadLine();
                        delivery = new HomeDelivery(homeAddress);
                        break;
                    case "2":
                        Console.WriteLine("Введите адрес ПВЗ:");
                        string pickAddress = Console.ReadLine();
                        Console.WriteLine("Введите компанию доставки:");
                        string company = Console.ReadLine();
                        delivery = new PickPointDelivery(pickAddress, company);
                        break;
                    case "3":
                        Console.WriteLine("Введите адрес магазина:");
                        string shopAddress = Console.ReadLine();
                        delivery = new ShopDelivery(shopAddress);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор доставки");
                        break;
                }
            }
        else
        {
            Console.WriteLine("Вы отменили заказ");
        }
    }
    
}



    
