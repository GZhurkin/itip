using System;
using System.Collections.Generic;

// Задание 1: Класс лимонного дерева
public class LemonTree
{
    // Поля
    private int age; // Возраст дерева
    private double height; // Высота дерева
    private string healthStatus; // Статус здоровья дерева
    public const string TreeType = "Lemon"; // Константа для типа дерева

    // Свойства
    public int FruitsCount { get; private set; } // Количество плодов, доступное только для чтения извне
    public int Age
    {
        get => age; // Возврат возраста
        set
        {
            if (value >= 0) // Проверка на корректность значения
                age = value; // Установка возраста
        }
    }
    public double Height
    {
        get => height; // Возврат высоты
        set
        {
            if (value >= 0) // Проверка на корректность значения
                height = value; // Установка высоты
        }
    }
    public string HealthStatus
    {
        get => healthStatus; // Возврат статуса здоровья
        set => healthStatus = value; // Установка статуса здоровья
    }

    // Конструкторы
    public LemonTree() : this(0, 0.0, "Healthy", 0) { } // Конструктор по умолчанию

    public LemonTree(int age, double height, string healthStatus, int fruitsCount)
    {
        Age = age; // Установка возраста
        Height = height; // Установка высоты
        HealthStatus = healthStatus; // Установка статуса здоровья
        FruitsCount = fruitsCount; // Установка количества плодов
    }

    // Методы
    public void Harvest() // Метод для сбора урожая
    {
        Console.WriteLine("Harvesting lemons...");
        FruitsCount = 0; // Собирать урожай обнуляет количество плодов
    }

    public void Care() // Метод для ухода за деревом
    {
        Console.WriteLine("Taking care of the lemon tree...");
    }

    public void TouchWithMusic() // Метод для взаимодействия с деревом под музыку
    {
        Console.WriteLine("Touching the tree while listening to inspiring music.");
    }

    public static string GetIdealComposition() // Статический метод для получения идеальной композиции
    {
        return "A perfect composition for a walk among trees is 'Nature Sounds'.";
    }

    // Переопределение ToString для вывода информации о дереве
    public override string ToString()
    {
        return $"Lemon Tree: Age = {Age}, Height = {Height}, Health = {HealthStatus}, Fruits = {FruitsCount}";
    }

    // Перегрузка операторов сравнения
    public static bool operator ==(LemonTree tree1, LemonTree tree2)
    {
        if (ReferenceEquals(tree1, tree2)) return true; // Если обе ссылки указывают на один объект
        if (ReferenceEquals(tree1, null) || ReferenceEquals(tree2, null)) return false; // Проверка на null
        return tree1.FruitsCount == tree2.FruitsCount; // Сравнение по количеству плодов
    }

    public static bool operator !=(LemonTree tree1, LemonTree tree2)
    {
        return !(tree1 == tree2); // Неравенство
    }

    public override bool Equals(object obj)
    {
        if (obj is LemonTree tree)
        {
            return this == tree; // Использование перегрузки ==
        }
        return false; // Не совпадает тип
    }

    public override int GetHashCode()
    {
        return FruitsCount.GetHashCode(); // Возврат хэш-кода для количества плодов
    }
}

// Базовый класс для иерархии деревьев
public abstract class Tree
{
    public abstract string Name { get; } // Абстрактное свойство имени дерева
    public abstract void DisplayClassName(); // Абстрактный метод для отображения имени класса
}

// Класс вишневого дерева
public class CherryTree : Tree
{
    public override string Name => "Cherry Tree"; // Имя дерева

    public override void DisplayClassName()
    {
        Console.WriteLine($"This is a {Name}."); // Вывод имени дерева
    }
}

// Класс яблоневого дерева
public class AppleTree : Tree
{
    public override string Name => "Apple Tree"; // Имя дерева

    public override void DisplayClassName()
    {
        Console.WriteLine($"This is a {Name}."); // Вывод имени дерева
    }
}

// Запечатанный класс клёна
public sealed class MapleTree : Tree
{
    public override string Name => "Maple Tree"; // Имя дерева

    public override void DisplayClassName()
    {
        Console.WriteLine($"This is a {Name}."); // Вывод имени дерева
    }
}

// Класс дуба
public class OakTree : Tree
{
    public override string Name => "Oak Tree"; // Имя дерева

    public override void DisplayClassName()
    {
        Console.WriteLine($"This is a {Name}."); // Вывод имени дерева
    }
}

// Интерфейс для роста растений
public interface IGrowable
{
    void Grow(); // Метод для роста растения
    string GetDetails(); // Метод для получения деталей о растении
}

// Класс арбуза, реализующий интерфейс IGrowable
public class Watermelon : IGrowable
{
    public void Grow() // Реализация метода роста
    {
        Console.WriteLine("The watermelon is growing...");
    }

    public string GetDetails() // Реализация метода получения деталей
    {
        return "Watermelon: a large, juicy fruit."; // Возврат информации о арбузе
    }
}

// Основной класс программы
class Program
{
    // Список для хранения объектов, реализующих интерфейс IGrowable
    static List<IGrowable> growablePlants = new List<IGrowable>();

    static void Main()
    {
        // Задание 1: Меню для работы с лимонным деревом
        LemonTree tree = new LemonTree();
        
        while (true)
        {
            Console.WriteLine("\nLemon Tree Menu:");
            Console.WriteLine("1. Set parameters of the Lemon Tree");
            Console.WriteLine("2. Display properties of the Lemon Tree");
            Console.WriteLine("3. Execute static method");
            Console.WriteLine("4. Execute methods of the Lemon Tree");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter age: ");
                    tree.Age = int.Parse(Console.ReadLine());
                    Console.Write("Enter height: ");
                    tree.Height = double.Parse(Console.ReadLine());
                    Console.Write("Enter health status: ");
                    tree.HealthStatus = Console.ReadLine();
                    Console.Write("Enter number of fruits: ");
                    tree.FruitsCount = int.Parse(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine(tree); // Вывод свойств дерева
                    break;
                case 3:
                    Console.WriteLine(LemonTree.GetIdealComposition()); // Вызов статического метода
                    break;
                case 4:
                    tree.Harvest(); // Сбор урожая
                    tree.Care(); // Уход за деревом
                    tree.TouchWithMusic(); // Взаимодействие с деревом
                    break;
                case 5:
                    return; // Выход из меню
                default:
                    Console.WriteLine("Invalid choice."); // Некорректный выбор
                    break;
            }
        }

        // Задание 2: Меню для работы с иерархией деревьев
        Tree[] trees = { new CherryTree(), new AppleTree(), new MapleTree(), new OakTree() };

        foreach (var treeItem in trees)
        {
            treeItem.DisplayClassName(); // Вывод имени каждого дерева
        }

        // Задание 3: Меню для работы со списком растений
        while (true)
        {
            Console.WriteLine("\nGrowable Plants Menu:");
            Console.WriteLine("1. Add new plant");
            Console.WriteLine("2. Show plant details");
            Console.WriteLine("3. Grow plant");
            Console.WriteLine("4. Show all plants");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Select plant type (1: Watermelon, 2: Lemon Tree): ");
                    int type = int.Parse(Console.ReadLine());
                    if (type == 1) 
                        growablePlants.Add(new Watermelon()); // Добавление арбуза в список
                    // Можно добавить создание LemonTree в этот список, если нужно
                    break;
                case 2:
                    foreach (var plant in growablePlants)
                    {
                        Console.WriteLine(plant.GetDetails()); // Вывод информации о каждом растении
                    }
                    break;
                case 3:
                    foreach (var plant in growablePlants)
                    {
                        plant.Grow(); // Вызов метода роста для каждого растения
                    }
                    break;
                case 4:
                    foreach (var plant in growablePlants)
                    {
                        Console.WriteLine(plant.GetDetails()); // Вывод информации о каждом растении
                    }
                    break;
                case 5:
                    return; // Выход из меню
                default:
                    Console.WriteLine("Invalid choice."); // Некорректный выбор
                    break;
            }
        }
    }
}
