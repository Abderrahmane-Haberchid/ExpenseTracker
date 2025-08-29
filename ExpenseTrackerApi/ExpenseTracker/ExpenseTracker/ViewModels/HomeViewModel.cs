using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.Dtos;

namespace ExpenseTracker.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    public decimal TotalBalance { get; set; } = 230450.16m;
    public decimal MonthlyIncome { get; set; } = 16000.00m;
    public decimal MonthlyExpenses { get; set; } = 14350.35m;

    [ObservableProperty]
    private string _recentTransactionText;

    public ObservableCollection<TransactionViewModel> RecentTransactions { get; } = new();
    
    public HomeViewModel()
    {
        // Populate with dummy data for demonstration
        RecentTransactions.Add(new TransactionViewModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            CategoryIcon = "avares://ExpenseTracker/Assets/Icons/food.png",
            Date = DateTime.Now,
            IsExpense = true,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionViewModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            CategoryIcon = "avares://ExpenseTracker/Assets/Icons/food.png",
            Date = DateTime.Now,
            IsExpense = true,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionViewModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            CategoryIcon = "avares://ExpenseTracker/Assets/Icons/food.png",
            Date = DateTime.Now,
            IsExpense = true,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionViewModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            CategoryIcon = "avares://ExpenseTracker/Assets/Icons/food.png",
            Date = DateTime.Now,
            IsExpense = true,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionViewModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            CategoryIcon = "avares://ExpenseTracker/Assets/Icons/food.png",
            Date = DateTime.Now,
            IsExpense = true,
            Notes = "This is monthly grocery shoping"
        });
        RecentTransactions.Add(new TransactionViewModel
        {
            Name = "Groceries",
            Amount = 150.75m,
            Category = "Food",
            CategoryIcon = "avares://ExpenseTracker/Assets/Icons/food.png",
            Date = DateTime.Now,
            IsExpense = true,
            Notes = "This is monthly grocery shoping"
        });
        
        RecentTransactionText = $"Recent Transactions({RecentTransactions.Count})";
    }
    
    
}