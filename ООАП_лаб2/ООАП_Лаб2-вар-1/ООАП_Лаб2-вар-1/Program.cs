using System;
using System.Collections.Generic;

abstract class JewelryItem
{
    public abstract string Material { get; }
    public abstract double Weight { get; }
    public abstract double Price { get; }
    public abstract string Name { get; } 
}

class GoldJewelryItem : JewelryItem
{
    public override string Material => "Золото";
    public override double Weight { get; }
    public override double Price { get; }
    public override string Name { get; } 

    public GoldJewelryItem(string name, double weight, double price)
    {
        Name = name;
        Weight = weight;
        Price = price;
    }
}

class SilverJewelryItem : JewelryItem
{
    public override string Material => "Срібло";
    public override double Weight { get; }
    public override double Price { get; }
    public override string Name { get; } 

    public SilverJewelryItem(string name, double weight, double price)
    {
        Name = name;
        Weight = weight;
        Price = price;
    }
}

abstract class JewelryFactory
{
    public abstract JewelryItem CreateItem(string name, double weight, double price);
}

class GoldJewelryFactory : JewelryFactory
{
    public override JewelryItem CreateItem(string name, double weight, double price)
    {
        return new GoldJewelryItem(name, weight, price);
    }
}

class SilverJewelryFactory : JewelryFactory
{
    public override JewelryItem CreateItem(string name, double weight, double price)
    {
        return new SilverJewelryItem(name, weight, price);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<JewelryItem> goldCatalog = new List<JewelryItem>();
        List<JewelryItem> silverCatalog = new List<JewelryItem>();

        while (true)
        {
            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1. Переглянути каталог");
            Console.WriteLine("2. Додати новий виріб");
            Console.WriteLine("3. Вийти");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                DisplayCatalog(goldCatalog, silverCatalog);
            }
            else if (choice == "2")
            {
                AddNewJewelryItem(goldCatalog, silverCatalog);
            }
            else if (choice == "3")
            {
                Console.WriteLine("Дякуємо за використання програми!");
                break;
            }
        }
    }

    static void DisplayCatalog(List<JewelryItem> goldCatalog, List<JewelryItem> silverCatalog)
    {
        Console.WriteLine("Оберіть каталог для перегляду:");
        Console.WriteLine("1. Золото");
        Console.WriteLine("2. Срібло");

        string catalogChoice = Console.ReadLine();

        if (catalogChoice == "1")
        {
            Console.WriteLine("Каталог 'Золото':");
            foreach (var item in goldCatalog)
            {
                Console.WriteLine($"Назва: {item.Name}");
                Console.WriteLine($"Матеріал: {item.Material}");
                Console.WriteLine($"Вага: {item.Weight} г");
                Console.WriteLine($"Ціна: ${item.Price}");
                Console.WriteLine();
            }
        }
        else if (catalogChoice == "2")
        {
            Console.WriteLine("Каталог 'Срібло':");
            foreach (var item in silverCatalog)
            {
                Console.WriteLine($"Назва: {item.Name}");
                Console.WriteLine($"Матеріал: {item.Material}");
                Console.WriteLine($"Вага: {item.Weight} г");
                Console.WriteLine($"Ціна: ${item.Price}");
                Console.WriteLine();
            }
        }
    }

    static void AddNewJewelryItem(List<JewelryItem> goldCatalog, List<JewelryItem> silverCatalog)
    {
        Console.WriteLine("Додати новий виріб:");
        Console.WriteLine("Оберіть категорію:");
        Console.WriteLine("1. Золото");
        Console.WriteLine("2. Срібло");

        string categoryChoice = Console.ReadLine();
        Console.Write("Введіть назву виробу: ");
        string name = Console.ReadLine();

        if (categoryChoice == "1")
        {
            Console.Write("Введіть вагу золотого виробу (г): ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть ціну золотого виробу ($): ");
            double price = Convert.ToDouble(Console.ReadLine());

            JewelryFactory goldFactory = new GoldJewelryFactory();
            JewelryItem goldItem = goldFactory.CreateItem(name, weight, price);
            goldCatalog.Add(goldItem);
            Console.WriteLine("Золотий виріб додано до каталогу.");
        }
        else if (categoryChoice == "2")
        {
            Console.Write("Введіть вагу срібного виробу (г): ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть ціну срібного виробу ($): ");
            double price = Convert.ToDouble(Console.ReadLine());

            JewelryFactory silverFactory = new SilverJewelryFactory();
            JewelryItem silverItem = silverFactory.CreateItem(name, weight, price);
            silverCatalog.Add(silverItem);
            Console.WriteLine("Срібний виріб додано до каталогу.");
        }
    }
}
