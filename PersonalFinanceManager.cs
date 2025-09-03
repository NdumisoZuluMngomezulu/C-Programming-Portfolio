using System;
using System.Collections.Generic;

public class Expense
{
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
}

public class PersonalFinanceManager
{
    private List<Expense> expenses = new List<Expense>();

    public void AddExpense(DateTime date, string category, decimal amount, string description)
    {
        expenses.Add(new Expense { Date = date, Category = category, Amount = amount, Description = description });
        Console.WriteLine("Expense added successfully!");
    }

    public void ViewExpenses()
    {
        if (expenses.Count == 0)
        {
            Console.WriteLine("No expenses recorded yet.");
            return;
        }

        Console.WriteLine("\n--- Your Expenses ---");
        foreach (var expense in expenses)
        {
            Console.WriteLine($"Date: {expense.Date.ToShortDateString()}, Category: {expense.Category}, Amount: {expense.Amount:C}, Description: {expense.Description}");
        }
        Console.WriteLine("---------------------\n");
    }

    public static void Main(string[] args)
    {
        PersonalFinanceManager manager = new PersonalFinanceManager();

        manager.AddExpense(DateTime.Now, "Groceries", 55.75m, "Weekly shopping");
        manager.AddExpense(DateTime.Now.AddDays(-2), "Transportation", 12.00m, "Bus fare");
        manager.ViewExpenses();
    }
}
