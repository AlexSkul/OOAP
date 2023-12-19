using System;
//VARIANT 6
//VARIANT 6
//VARIANT 6
//VARIANT 6
// Інтерфейс для сучасного вагона
public interface INewVagonSystem
{
    void MatchSocket();
}

// Клас, який реалізує інтерфейс для сучасного вагона
public class NewVagonSystem : INewVagonSystem
{
    public void MatchSocket()
    {
        Console.WriteLine("Ноутбук заряджається в сучасному вагоні.");
    }
}

// Інтерфейс для старого вагона
public interface IOldVagonSystem
{
    void ThinSocket();
}

// Клас, який реалізує інтерфейс для старого вагона
public class OldVagonSystem : IOldVagonSystem
{
    public void ThinSocket()
    {
        Console.WriteLine("Ноутбук не може заряджатися в старому вагоні через старі радянські розетки.");
    }
}

// Адаптер для використання старого вагона в сучасному середовищі
public class OldVagonAdapter : INewVagonSystem
{
    private readonly IOldVagonSystem oldVagonSystem;

    public OldVagonAdapter(IOldVagonSystem oldVagonSystem)
    {
        this.oldVagonSystem = oldVagonSystem;
    }

    public void MatchSocket()
    {
        oldVagonSystem.ThinSocket();
    }
}

// Клас, який використовує систему вагонів
public class Train
{
    public void UseVagonSystem(INewVagonSystem vagonSystem)
    {
        vagonSystem.MatchSocket();
    }
}

class Program
{
    static void Main()
    {
        // Сучасний вагон
        INewVagonSystem newVagon = new NewVagonSystem();

        // Старий вагон
        IOldVagonSystem oldVagon = new OldVagonSystem();

        // Адаптер для використання старого вагона в сучасному середовищі
        INewVagonSystem oldVagonAdapter = new OldVagonAdapter(oldVagon);

        // Поїзд із сучасним вагоном
        Train trainWithNewVagon = new Train();
        trainWithNewVagon.UseVagonSystem(newVagon);

        // Поїзд із старим вагоном, використовуючи адаптер
        Train trainWithOldVagonAdapter = new Train();
        trainWithOldVagonAdapter.UseVagonSystem(oldVagonAdapter);
    }
}
