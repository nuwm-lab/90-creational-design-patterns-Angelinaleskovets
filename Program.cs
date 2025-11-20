using System;

// ==========================================================
// Абстрактні продукти
// ==========================================================

public interface IOperatingRoom
{
    void Work();
}

public interface IMedicalDepartment
{
    void Serve();
}

// ==========================================================
// Конкретні продукти (польова лікарня)
// ==========================================================

public class FieldOperatingRoom : IOperatingRoom
{
    public void Work()
    {
        Console.WriteLine("Польова операційна: базове хірургічне обладнання.");
    }
}

public class FieldMedicalPoint : IMedicalDepartment
{
    public void Serve()
    {
        Console.WriteLine("Мобільний медпункт: перша допомога.");
    }
}

// ==========================================================
// Конкретні продукти (капітальна лікарня)
// ==========================================================

public class CapitalOperatingRoom : IOperatingRoom
{
    public void Work()
    {
        Console.WriteLine("Капітальна операційна: повний комплекс обладнання.");
    }
}

public class CapitalReception : IMedicalDepartment
{
    public void Serve()
    {
        Console.WriteLine("Приймальне відділення: реєстрація та огляд.");
    }
}

// ==========================================================
// Абстрактна фабрика
// ==========================================================

public interface IHospitalFactory
{
    IOperatingRoom CreateOperatingRoom();
    IMedicalDepartment CreateMedicalDepartment();
}

// ==========================================================
// Конкретні фабрики
// ==========================================================

public class FieldHospitalFactory : IHospitalFactory
{
    public IOperatingRoom CreateOperatingRoom()
    {
        return new FieldOperatingRoom();
    }

    public IMedicalDepartment CreateMedicalDepartment()
    {
        return new FieldMedicalPoint();
    }
}

public class CapitalHospitalFactory : IHospitalFactory
{
    public IOperatingRoom CreateOperatingRoom()
    {
        return new CapitalOperatingRoom();
    }

    public IMedicalDepartment CreateMedicalDepartment()
    {
        return new CapitalReception();
    }
}

// ==========================================================
// Клієнтський код
// ==========================================================

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Вибір типу лікарні
        Console.WriteLine("Оберіть тип лікарні (1 – польова, 2 – капітальна):");
        string choice = Console.ReadLine();

        IHospitalFactory factory;

        if (choice == "1")
            factory = new FieldHospitalFactory();
        else
            factory = new CapitalHospitalFactory();

        // Створення компонентів
        var operatingRoom = factory.CreateOperatingRoom();
        var department = factory.CreateMedicalDepartment();

        // Використання
        operatingRoom.Work();
        department.Serve();
    }
}
