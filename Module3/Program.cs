using System;
using System.Collections.Generic;

public abstract class Delivery
{
    public string Address { get; set; }
    public virtual void GetDeliveryInfo()
    {
        Console.WriteLine($"Адрес доставки: {Address}");
        Console.WriteLine($"Покупатель: {Customer.Name}");
    }

    public Customer Customer { get; set; } // у каждой доставки есть заказ и покупатель

    public Delivery(string address, Customer customer)
    {
        Address = address;
        Customer = customer;
    }

    public abstract decimal CalculateDeliveryCost(); // абстрактный метод для расчета стоимости доставки
}

public class HomeDelivery : Delivery
{
    public string CourierName { get; private set; }

    public HomeDelivery(string address, Customer customer, string courierName)
        : base(address, customer)  // обращение к конструктору абстрактного класса
    {
        CourierName = courierName;
    }

    public override void GetDeliveryInfo()
    {
        Console.WriteLine($"Доставка на дом по адресу: {Address}");
        Console.WriteLine($"Курьер: {CourierName}");
    }

    public override decimal CalculateDeliveryCost()
    {
        return 200; // фиксированная стоимость для домашней доставки
    }
}

public class PickPointDelivery : Delivery
{
    public string Company { get; private set; }
    public string PickPointName { get; private set; }

    public PickPointDelivery(string address, Customer customer, string company, string pickPointName)
        : base(address, customer)
    {
        Company = company;
        PickPointName = pickPointName;
    }

    public override void GetDeliveryInfo()
    {
        Console.WriteLine($"Доставка в пункт выдачи: {PickPointName}");
        Console.WriteLine($"Компания: {Company}");
        Console.WriteLine($"Адрес: {Address}");
    }

    public override decimal CalculateDeliveryCost()
    {
        return 300; // фиксированная стоимость для доставки пикпоинт
    }
}

public class ShopDelivery : Delivery
{
    public string Shop { get; private set; }

    public ShopDelivery(string address, Customer customer, string shop)
        : base(address, customer)
    {
        Shop = shop;
    }

    public override void GetDeliveryInfo()
    {
        Console.WriteLine($"Доставка в магазин: {Shop}");
        Console.WriteLine($"Адрес: {Address}");
    }

    public override decimal CalculateDeliveryCost()
    {
        return 400; // фиксированная стоимость для доставки в магазин
    }
}

public class Product
{
    public string Name { get; set; }

    private decimal _price; // храним цену
    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0) // допустим что цена товара может быть 0
                throw new ArgumentException("Цена товара должна быть положительной");
            _price = value;
        }
    }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price; // проверяем price
    }
}

public class Customer
{
    public string Name { get; set; }
    private string _phone; // храним номер

    public string Phone
    {
        get => _phone;
        set
        {
            if (value.Length != 10)  // проверка длины
                throw new ArgumentException("Телефон должен содержать 10 символов");

            _phone = value;
        }
    }

    public Customer(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }

    public static Customer CreateCustomer(string name, string phone)
    {
        return new Customer(name, phone);
    }
}

public class Order<TDelivery> where TDelivery : Delivery
{
    public TDelivery Delivery;

    private static int _orderCounter = 0; // статический счётчик всех заказов
    public int Number { get; private set; } // номер заказа, уникальный

    private List<Product> products = new List<Product>(); // список товаров

    public Product this[int index]
    {
        get => products[index];
        set => products[index] = value;
    }

    public void DisplayAddress()
    {
        Console.WriteLine(Delivery.Address);
    }

    public void AddProducts<T>(List<T> items) where T : Product
    {
        foreach (var item in items)
            products.Add(item);
    }

    public Order(TDelivery delivery)
    {
        Delivery = delivery;
        Number = ++_orderCounter;
    }

    public List<Product> GetProducts()
    {
        return products;
    }
}

public static class OrderExtensions
{
    public static decimal TotalPrice<TDelivery>(this Order<TDelivery> order) where TDelivery : Delivery
    {
        decimal total = 0;
        foreach (var product in order.GetProducts())
        {
            total += product.Price;
        }
        return total;
    }
}

class PickPointOrder : Order<PickPointDelivery>
{
    public string PickupCode { get; set; }

    public PickPointOrder(PickPointDelivery delivery) : base(delivery) { }

    public void ShowPickupCode()
    {
        Console.WriteLine($"Код выдачи: {PickupCode}");
    }
}

class Program
{
    static void Main()
    {
        Customer customer = Customer.CreateCustomer("Маша", "9990009900");
        HomeDelivery homeDelivery = new HomeDelivery("ул. Пушкина, д.10", customer, "Сергей");

        Order<HomeDelivery> order = new Order<HomeDelivery>(homeDelivery);

        Product p1 = new Product("Товар1", 100);
        Product p2 = new Product("Товар2", 200);
        order.AddProducts(new List<Product> { p1, p2 });

        homeDelivery.GetDeliveryInfo();
        Console.WriteLine($"Стоимость доставки: {homeDelivery.CalculateDeliveryCost()}");

       
        Console.WriteLine($"Итоговая стоимость товаров: {order.TotalPrice()}");
    }
    // компилятор ругался на доступы поэтому сделала все классы публичными
}
