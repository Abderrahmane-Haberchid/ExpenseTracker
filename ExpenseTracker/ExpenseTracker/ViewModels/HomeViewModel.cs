using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.Enum;
using ExpenseTracker.Models;

namespace ExpenseTracker.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    public decimal TotalBalance { get; set; } = 230450.16m;
    public decimal MonthlyIncome { get; set; } = 16000.00m;
    public decimal MonthlyExpenses { get; set; } = 14350.35m;

    [ObservableProperty]
    private string _recentTransactionText;

    public ObservableCollection<TransactionModel> RecentTransactions { get; } = new();
    
    public HomeViewModel()
    {
        // Populate with dummy data for demonstration
        RecentTransactions.Add(new TransactionModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            Date = DateTime.Now,
            Type = TransactionType.EXPENSE,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionModel
        {
            Name = "Argent Loyer",
            Amount = 150.75m,
            Category = "Food",
            Date = DateTime.Now,
            Type = TransactionType.INCOME,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionModel
        {
            Name = "Salaire Job",
            Amount = 150.75m,
            Category = "Food",
            Date = DateTime.Now,
            Type = TransactionType.INCOME,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            Date = DateTime.Now,
            Type = TransactionType.EXPENSE,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            Date = DateTime.Now,
            Type = TransactionType.EXPENSE,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            Date = DateTime.Now,
            Type = TransactionType.EXPENSE,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            Date = DateTime.Now,
            Type = TransactionType.EXPENSE,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            Date = DateTime.Now,
            Type = TransactionType.EXPENSE,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            Date = DateTime.Now,
            Type = TransactionType.EXPENSE,
            Notes = "This is monthly grocery shoping"
        });
        
        RecentTransactionText = $"Recent Transactions({RecentTransactions.Count})";
    }
    
    
}