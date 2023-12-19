using System;
//VARIANT 1
//VARIANT 1
//VARIANT 1
// Інтерфейс реалізації
public interface IAlarmClockImpl
{
    void Ring();
    void Notify();
}

// Конкретна реалізація інтерфейса реалізації
public class AlarmClockImpl : IAlarmClockImpl
{
    public void Ring()
    {
        Console.WriteLine("Дзвінок будильника!");
    }

    public void Notify()
    {
        Console.WriteLine("Повідомлення від будильника.");
    }
}

// Інтерфейс абстракції
public interface IAlarmClock
{
    void Start();
    void Stop();
    void ToWake();
}

// Контекст абстракції
public class AlarmClock : IAlarmClock
{
    private readonly IAlarmClockImpl _impl;

    public AlarmClock(IAlarmClockImpl impl)
    {
        _impl = impl;
    }

    public void Start()
    {
        Console.WriteLine("Будильник запущено.");
    }

    public void Stop()
    {
        Console.WriteLine("Будильник зупинено.");
    }

    public void ToWake()
    {
        Start();
        _impl.Ring();
        _impl.Notify();
        Stop();
    }
}

// Інтерфейс користувача
public interface IUserInterface
{
    void ChooseAction(IAlarmClock alarmClock);
}

// Конкретна реалізація інтерфейсу користувача
public class UserInterface : IUserInterface
{
    public void ChooseAction(IAlarmClock alarmClock)
    {
        Console.WriteLine("Виберіть дію:");
        Console.WriteLine("1. Запустити будильник");
        Console.WriteLine("2. Зупинити будильник");
        Console.WriteLine("3. Збудити");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                alarmClock.Start();
                break;
            case 2:
                alarmClock.Stop();
                break;
            case 3:
                alarmClock.ToWake();
                break;
            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        // Використання шаблону BRIDGE
        IAlarmClockImpl alarmClockImpl = new AlarmClockImpl();
        IAlarmClock alarmClock = new AlarmClock(alarmClockImpl);

        // Використання інтерфейсу користувача
        IUserInterface userInterface = new UserInterface();
        userInterface.ChooseAction(alarmClock);
    }
}
