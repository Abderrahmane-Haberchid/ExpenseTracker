using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.Configuration;
using ExpenseTracker.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    public decimal TotalBalance { get; set; } = 230450.16m;
    public decimal MonthlyIncome { get; set; } = 16000.00m;
    public decimal MonthlyExpenses { get; set; } = 14350.35m;

    [ObservableProperty]
    private string _recentTransactionText;
    
    private AppDbContext _appDbContext;

    public HomeViewModel(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        Load();
    }

    public ObservableCollection<TransactionModel> RecentTransactions { get; } = new();
    
    public HomeViewModel() : this(App.ServiceProvider.GetRequiredService<AppDbContext>() ?? throw new InvalidOperationException("Not able to initialize AppDbContext Service"))
    {
        
    }
    
    public void Load()
    {

        try
        {
            var allTransactions = _appDbContext.Transactions.ToList();

            RecentTransactions.Clear();
            foreach (var transaction in allTransactions)
            {
                RecentTransactions.Add(transaction);
            }

            RecentTransactionText = $"Recent Transactions ({RecentTransactions.Count})";
        }
        catch (Exception e)
        {
            Console.WriteLine("Error loading transactions: " + e.Message);
        }
    }
    
    
    
    
}