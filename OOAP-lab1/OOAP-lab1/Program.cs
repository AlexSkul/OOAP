using System;

public interface IVolumeCalculable
{
    double CalculateVolume();
}

public abstract class Shape : IVolumeCalculable
{
    private string name;

    public Shape(string name)
    {
        this.name = name;
        Console.WriteLine("Об'єкт створено");
    }

    public string GetName()
    {
        return name;
    }

    public abstract void DisplayInfo();

    public abstract double CalculateVolume();
}

public class Cube : Shape
{
    private double sideLength;

    public Cube(string name, double sideLength) : base(name)
    {
        this.sideLength = sideLength;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Фігура: {GetName()}");
        Console.WriteLine($"Довжина сторони: {sideLength}");
    }

    public override double CalculateVolume()
    {
        return Math.Pow(sideLength, 3);
    }
}

public class Parallelepiped : Shape
{
    private double baseArea;
    private double height;

    public Parallelepiped(string name, double baseArea, double height) : base(name)
    {
        this.baseArea = baseArea;
        this.height = height;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Фігура: {GetName()}");
        Console.WriteLine($"Площа основи: {baseArea}");
        Console.WriteLine($"Висота: {height}");
    }

    public override double CalculateVolume()
    {

        return baseArea * height;
    }
}

public class Pyramid : Shape
{
    private double baseArea;
    private double height;

    public Pyramid(string name, double baseArea, double height) : base(name)
    {
        this.baseArea = baseArea;
        this.height = height;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Фігура: {GetName()}");
        Console.WriteLine($"Площа основи: {baseArea}");
        Console.WriteLine($"Висота: {height}");
    }

    public override double CalculateVolume()
    {
        return (1.0 / 3.0) * baseArea * height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Оберіть опцію:");
            Console.WriteLine("1. Створити куб");
            Console.WriteLine("2. Створити паралелограм");
            Console.WriteLine("3. Створити піраміду");
            Console.WriteLine("4. Вийти");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateCube();
                    break;
                case 2:
                    CreateParallepiped();
                    break;
                case 3:
                    CreatePyramid();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неправильний вибір. Будь ласка, спробуйте ще раз.");
                    break;
            }
        }
    }

    static void CreateCube()
    {
        Console.WriteLine("Введіть ім'я куба:");
        string name = Console.ReadLine();
        Console.WriteLine("Введіть довжину сторони:");
        double sideLength = double.Parse(Console.ReadLine());

        Cube cube = new Cube(name, sideLength);
        cube.DisplayInfo();
        Console.WriteLine($"Об'єм: {cube.CalculateVolume()}");
    }

    static void CreateParallepiped()
    {
        Console.WriteLine("Введіть ім'я паралелепіда:");
        string name = Console.ReadLine();
        Console.WriteLine("Введіть площу основи:");
        double baseLength = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть висоту:");
        double height = double.Parse(Console.ReadLine());

        Parallelepiped arallelepiped = new Parallelepiped(name, baseLength, height);
        arallelepiped.DisplayInfo();
        Console.WriteLine($"Об'єм: {arallelepiped.CalculateVolume()}");
    }

    static void CreatePyramid()
    {
        Console.WriteLine("Введіть ім'я піраміди:");
        string name = Console.ReadLine();
        Console.WriteLine("Введіть площу основи:");
        double baseArea = double.Parse(Console.ReadLine());
        Console.WriteLine("Введіть висоту:");
        double height = double.Parse(Console.ReadLine());

        Pyramid pyramid = new Pyramid(name, baseArea, height);
        pyramid.DisplayInfo();
        Console.WriteLine($"Об'єм: {pyramid.CalculateVolume()}");
    }
}