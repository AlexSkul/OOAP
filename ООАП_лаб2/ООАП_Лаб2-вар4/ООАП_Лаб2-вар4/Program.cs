using System;

class CarConfiguration
{
    public string EngineType { get; set; }
    public double EngineVolume { get; set; }
    public bool HasABS { get; set; }
    public bool HasESP { get; set; }
    public int SafetyAirbags { get; set; }
    public bool HasComputer { get; set; }
    public bool HasAC { get; set; }
    public string InteriorTrim { get; set; }

    public void ShowConfiguration()
    {
        Console.WriteLine($"Двигун: {EngineType}, Об'єм двигуна: {EngineVolume} л");
        Console.WriteLine($"ABS: {HasABS}, ESP: {HasESP}");
        Console.WriteLine($"Подушки безпеки: {SafetyAirbags}");
        Console.WriteLine($"Бортовий комп'ютер: {HasComputer}");
        Console.WriteLine($"Кондиціонер: {HasAC}");
        Console.WriteLine($"Обшивка салону: {InteriorTrim}");
    }
}

class CarConfigurationBuilder
{
    private CarConfiguration carConfiguration = new CarConfiguration();

    public CarConfigurationBuilder SetEngine(string engineType, double engineVolume)
    {
        carConfiguration.EngineType = engineType;
        carConfiguration.EngineVolume = engineVolume;
        return this;
    }

    public CarConfigurationBuilder SetSafetyFeatures(bool hasABS, bool hasESP, int safetyAirbags)
    {
        carConfiguration.HasABS = hasABS;
        carConfiguration.HasESP = hasESP;
        carConfiguration.SafetyAirbags = safetyAirbags;
        return this;
    }

    public CarConfigurationBuilder SetAdditionalFeatures(bool hasComputer, bool hasAC)
    {
        carConfiguration.HasComputer = hasComputer;
        carConfiguration.HasAC = hasAC;
        return this;
    }

    public CarConfigurationBuilder SetInterior(string interiorTrim)
    {
        carConfiguration.InteriorTrim = interiorTrim;
        return this;
    }

    public CarConfiguration Build()
    {
        return carConfiguration;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Оберіть комплектацію автомобіля:");
        Console.WriteLine("1. Базова");
        Console.WriteLine("2. Стандарт");
        Console.WriteLine("3. Покращена");
        Console.WriteLine("4. Преміум");
        Console.Write("Ваш вибір (1-4): ");

        int userChoice;
        if (int.TryParse(Console.ReadLine(), out userChoice) && userChoice >= 1 && userChoice <= 4)
        {
            CarConfigurationBuilder builder = new CarConfigurationBuilder();

            switch (userChoice)
            {
                case 1:
                    builder.SetEngine("Бензин", 1.6)
                           .SetSafetyFeatures(false, false, 4)
                           .SetAdditionalFeatures(false, false)
                           .SetInterior("Тканина");
                    break;
                case 2:
                    builder.SetEngine("Бензин", 2.0)
                           .SetSafetyFeatures(true, true, 6)
                           .SetAdditionalFeatures(true, false)
                           .SetInterior("Шкіра");
                    break;
                case 3:
                    builder.SetEngine("Дизель", 2.0)
                           .SetSafetyFeatures(true, true, 6)
                           .SetAdditionalFeatures(true, true)
                           .SetInterior("Шкіра");
                    break;
                case 4:
                    builder.SetEngine("Дизель", 3.0)
                           .SetSafetyFeatures(true, true, 8)
                           .SetAdditionalFeatures(true, true)
                           .SetInterior("Шкіра з підігрівом");
                    break;
            }

            CarConfiguration carConfig = builder.Build();
            Console.WriteLine("Характеристики обраної комплектації автомобіля:");
            carConfig.ShowConfiguration();

            double carPrice = CalculateCarPrice(carConfig);
            Console.WriteLine($"Загальна вартість: {carPrice} грн");
        }
        else
        {
            Console.WriteLine("Невірний вибір. Будь ласка, виберіть опцію від 1 до 4.");
        }
    }

    static double CalculateCarPrice(CarConfiguration carConfig)
    {
        double basePrice = 20000;
        double pricePerEngineVolume = 1000;
        double pricePerAirbag = 500;
        double pricePerAC = 1000;

        double totalPrice = basePrice + (carConfig.EngineVolume * pricePerEngineVolume) +
                           (carConfig.SafetyAirbags * pricePerAirbag);
        if (carConfig.HasAC)
        {
            totalPrice += pricePerAC;
        }

        return totalPrice;
    }
}
