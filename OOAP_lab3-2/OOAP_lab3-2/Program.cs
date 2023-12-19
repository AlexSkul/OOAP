using System;
using System.IO;
//VARIANT 4
//VARIANT 4
//VARIANT 4
//VARIANT 4
public sealed class Counter
{
    private static readonly Counter instance = new Counter();
    private int foodCount;
    private int medicineCount;
    private int clothingCount;
    private decimal totalSales;
    private string logFilePath;

    private Counter()
    {
        foodCount = 0;
        medicineCount = 0;
        clothingCount = 0;
        totalSales = 0;
        logFilePath = "sales_log.txt";
    }

    public static Counter Instance
    {
        get { return instance; }
    }

    public void RecordSale(string productType, decimal price, int quantity)
    {
        switch (productType.ToLower())
        {
            case "food":
                foodCount += quantity;
                totalSales += price * quantity * 1.05m;
                break;
            case "medicine":
                medicineCount += quantity;
                totalSales += price * quantity * 1.1m;
                break;
            case "clothing":
                clothingCount += quantity;
                totalSales += price * quantity * 1.15m;
                break;
            default:
                Console.WriteLine("Невідомий тип товару.");
                return;
        }

        string logEntry = $"{DateTime.Now}: Продано {quantity} одиниць товару типу {productType}.";
        File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
    }

    public void DisplayStatistics()
    {
        Console.WriteLine($"Продано продуктів харчування: {foodCount}");
        Console.WriteLine($"Продано ліків: {medicineCount}");
        Console.WriteLine($"Продано одягу: {clothingCount}");
        Console.WriteLine($"Загальна сумарна вартість продажів: {totalSales:C}");
    }

    public void SellProduct()
    {
        Console.WriteLine("Виберіть тип товару (food, medicine, clothing): ");
        string productType = Console.ReadLine();

        Console.WriteLine("Введіть ціну товару: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Некоректний формат ціни.");
            return;
        }

        Console.WriteLine("Введіть кількість товару: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
        {
            Console.WriteLine("Некоректна кількість товару.");
            return;
        }

        RecordSale(productType, price, quantity);

        Console.WriteLine($"Продано {quantity} одиниць товару типу {productType} за {price:C} кожна.");
    }
}

class Program
{
    static void Main()
    {
        Counter counter = Counter.Instance;

        while (true)
        {
            Console.WriteLine("1. Продати товар");
            Console.WriteLine("2. Вивести статистику");
            Console.WriteLine("3. Вийти");
            Console.Write("Оберіть опцію: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Некоректний вибір.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    counter.SellProduct();
                    break;
                case 2:
                    counter.DisplayStatistics();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некоректний вибір.");
                    break;
            }
        }
    }
}
