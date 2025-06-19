using System;
using System.Collections.Generic;

interface IQuittable { void Quit(); }

class Employee : IQuittable
{
    private static readonly List<string> Reasons = new()
    {
        "Career Change","Relocation","Personal Reasons",
        "Better Opportunity","Health Reasons","Retirement"
    };

    public int Id { get; }
    public string FirstName { get; }
    public string LastName  { get; }
    public DateTime HireDate { get; } = DateTime.Now;

    public Employee(int id, string first, string last)
    {
        if (id <= 0 || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(last))
            throw new ArgumentException("Invalid employee data.");
        Id = id; FirstName = first; LastName = last;
    }

    public void Quit()
    {
        Console.WriteLine($"\nResignation for {FirstName} {LastName}");
        for (int i = 0; i < Reasons.Count; i++)
            Console.WriteLine($"{i + 1}. {Reasons[i]}");

        Console.Write("Reason number (0 cancel): ");
        if (int.TryParse(Console.ReadLine(), out var n) && n is > 0 and <= 6)
            Confirm(Reasons[n - 1]);
        else
            Console.WriteLine("Cancelled.");
    }

    void Confirm(string reason) =>
        Console.WriteLine($"\nID {Id} – {FirstName} {LastName}\nReason: {reason}\nDate: {DateTime.Now:yyyy-MM-dd}\nProcessed.");
}

// ----- demo -----
Console.WriteLine("Polymorphism Quit Demo\n");
IQuittable emp = new Employee(4, "Emma", "Davis");
emp.Quit();
Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
