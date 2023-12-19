using System;
using System.Collections.Generic;
using System.IO;
//VARIANT 5
//VARIANT 5
//VARIANT 5
//VARIANT 5
//VARIANT 5
class Resident : ICloneable
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Faculty { get; set; }
    public string Group { get; set; }
    public string FormOfStudy { get; set; }

    public Resident(string fullName, DateTime dateOfBirth, string faculty, string group, string formOfStudy)
    {
        FullName = fullName;
        DateOfBirth = dateOfBirth;
        Faculty = faculty;
        Group = group;
        FormOfStudy = formOfStudy;
    }

    public object Clone()
    {
        return new Resident(FullName, DateOfBirth, Faculty, Group, FormOfStudy);
    }
}

class Room : ICloneable
{
    public string Type { get; set; }
    public List<Resident> Residents { get; set; }

    public Room(string type)
    {
        Type = type;
        Residents = new List<Resident>();
    }

    public void AddResident(Resident resident)
    {
        Residents.Add(resident);
    }

    public void GenerateReport(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName, true))
        {
            writer.WriteLine($"Тип кімнати: {Type}");
            writer.WriteLine($"Кількість мешканців: {Residents.Count}");

            foreach (var resident in Residents)
            {
                writer.WriteLine($"Мешканець: {resident.FullName}");
                writer.WriteLine($"Дата народження: {resident.DateOfBirth.ToShortDateString()}");
                writer.WriteLine($"Спеціальність: {resident.Faculty}");
                writer.WriteLine($"Група: {resident.Group}");
                writer.WriteLine($"Форма навчання: {resident.FormOfStudy}");
            }

            writer.WriteLine();
        }
    }

    public object Clone()
    {
        Room clonedRoom = new Room(Type);
        foreach (var resident in Residents)
        {
            clonedRoom.AddResident((Resident)resident.Clone());
        }
        return clonedRoom;
    }
}

class Dormitory
{
    public List<Room> rooms;

    public Dormitory()
    {
        rooms = new List<Room>();
    }

    public void AddRoom(Room room)
    {
        rooms.Add(room);
    }

    public void GenerateReports(string fileName)
    {
        foreach (var room in rooms)
        {
            room.GenerateReport(fileName);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dormitory originalDormitory = new Dormitory();

        Room room1 = new Room("Подвійна");
        room1.AddResident(new Resident("Олена", new DateTime(2000, 1, 1), "Комп'ютерні науки", "КН-21", "Денна"));
        room1.AddResident(new Resident("Юля", new DateTime(1999, 2, 2), "Комп'ютерні науки", "КН-21", "Заочна"));

        Room room2 = new Room("Потрійна");
        room2.AddResident(new Resident("Саша", new DateTime(2002, 9, 17), "Інформаційні системи та технології", "ІСТС-21", "Денна"));
        room2.AddResident(new Resident("Максим", new DateTime(2003, 4, 4), "Хімічні технології", "ХТ-11", "Денна"));
        room2.AddResident(new Resident("Ілля", new DateTime(2003, 5, 5), "Хімічні технології", "ХТ-11", "Денна"));

        originalDormitory.AddRoom(room1);
        originalDormitory.AddRoom(room2);

        // Clone the original dormitory
        Dormitory clonedDormitory = new Dormitory();
        foreach (var room in originalDormitory.rooms)
        {
            clonedDormitory.AddRoom((Room)room.Clone());
        }

        // Modify the cloned dormitory if needed
        // For example, add a new resident to the first room
        Room clonedRoom1 = (Room)clonedDormitory.rooms[0].Clone();
        clonedRoom1.AddResident(new Resident("Новий Мешканець", new DateTime(2004, 6, 6), "Нова Спеціальність", "Нова Група", "Заочна"));
        clonedDormitory.AddRoom(clonedRoom1);

        // Generate reports for the original and cloned dormitories
        originalDormitory.GenerateReports("OriginalDormitoryReport.txt");
        clonedDormitory.GenerateReports("ClonedDormitoryReport.txt");
    }
}
