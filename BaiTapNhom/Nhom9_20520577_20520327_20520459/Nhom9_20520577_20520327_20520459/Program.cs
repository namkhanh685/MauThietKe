using System;
using System.Collections.Generic;

// Component interface
public abstract class Employee
{
    public string Name { get; }
    public string Position { get; }

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public abstract void DisplayInfo();
    public abstract double CalculateSalary();
    public abstract void Work();
}

// Leaf class
public class BasicEmployee : Employee
{
    private double baseSalary;

    public BasicEmployee(string name, string position, double baseSalary) : base(name, position)
    {
        this.baseSalary = baseSalary;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Position}: {Name}, Salary: ${baseSalary}");
    }

    public override double CalculateSalary()
    {
        return baseSalary;
    }

    public override void Work()
    {
        Console.WriteLine($"{Position} {Name} is working on tasks.");
    }
}

// Composite class
public class Manager : Employee
{
    private List<Employee> subordinates = new List<Employee>();

    public Manager(string name, string position) : base(name, position) { }

    public void AddSubordinate(Employee subordinate)
    {
        subordinates.Add(subordinate);
    }

    public void RemoveSubordinate(Employee subordinate)
    {
        subordinates.Remove(subordinate);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"{Position}: {Name}");
        foreach (Employee subordinate in subordinates)
        {
            subordinate.DisplayInfo();
        }
    }

    public override double CalculateSalary()
    {
        double totalSalary = 0;
        foreach (Employee subordinate in subordinates)
        {
            totalSalary += subordinate.CalculateSalary();
        }
        return totalSalary;
    }

    public override void Work()
    {
        Console.WriteLine($"{Position} {Name} is managing the team and working on tasks.");
        foreach (Employee subordinate in subordinates)
        {
            subordinate.Work();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating basic employees
        BasicEmployee engineer1 = new BasicEmployee("John Doe", "Engineer", 50000);
        BasicEmployee engineer2 = new BasicEmployee("Jane Smith", "Engineer", 60000);
        BasicEmployee marketer1 = new BasicEmployee("Mike Johnson", "Marketer", 55000);
        BasicEmployee marketer2 = new BasicEmployee("Emily Brown", "Marketer", 60000);

        // Creating managers
        Manager productionDirector = new Manager("Alice", "Production Director");
        Manager marketingDirector = new Manager("Bob", "Marketing Director");
        Manager ceo = new Manager("Eve", "CEO");

        // Assigning basic employees to managers
        productionDirector.AddSubordinate(engineer1);
        productionDirector.AddSubordinate(engineer2);
        marketingDirector.AddSubordinate(marketer1);
        marketingDirector.AddSubordinate(marketer2);

        ceo.AddSubordinate(productionDirector);
        ceo.AddSubordinate(marketingDirector);

        // Displaying company structure
        ceo.DisplayInfo();

        // Working simulation
        ceo.Work();
    }
}