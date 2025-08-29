using System;

namespace ExpenseTracker.Dtos;

public class TransactionViewModel
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string CategoryIcon { get; set; }
    public DateTime Date { get; set; }
    public bool IsExpense { get; set; }
    public string Notes { get; set; }
}