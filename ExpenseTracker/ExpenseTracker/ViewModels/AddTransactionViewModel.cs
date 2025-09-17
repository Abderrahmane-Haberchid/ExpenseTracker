using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Configuration;
using ExpenseTracker.Enum;
using ExpenseTracker.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.ViewModels;

public partial class AddTransactionViewModel : ViewModelBase
{
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private string _category = string.Empty;
    [ObservableProperty] private string _notes = string.Empty;
    [ObservableProperty] private decimal _amount;
    
    [ObservableProperty] private bool _isExpense = true;
    [ObservableProperty] private bool _isIncome;
    
    private readonly AppDbContext? _appDbContext; // Fixed: underscore, not asterisk

    public AddTransactionViewModel(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext; // Fixed: underscore, not asterisk
    }

    public AddTransactionViewModel() : this(App.ServiceProvider.GetRequiredService<AppDbContext>())
    {
    }

    [RelayCommand]
    private void SetIsExpense()
    {
        IsExpense = true;
        IsIncome = false; // Fixed: should be false, not !IsExpense
    }

    [RelayCommand]
    private void SetIsIncome()
    {
        IsIncome = true;
        IsExpense = false; // Fixed: should be false, not !IsExpense
    }

    [RelayCommand]
    private async Task SubmitExpense()
    {
        // Add proper null check
        if (_appDbContext == null)
        {
            System.Diagnostics.Debug.WriteLine("Database context is not available");
            return;
        }

        // Add validation
        if (string.IsNullOrWhiteSpace(Name) || Amount <= 0)
        {
            System.Diagnostics.Debug.WriteLine("Invalid transaction data");
            return;
        }

        var expense = new TransactionModel
        {
            Amount = Amount,
            Name = Name,
            Category = Category ?? "Other",
            Type = TransactionType.EXPENSE,
            Notes = Notes ?? string.Empty,
            Date = DateTime.Now 
        };

        try
        {
            _appDbContext.Transactions.Add(expense); // Fixed: use _appDbContext
            await _appDbContext.SaveChangesAsync();
            
            // Clear form after successful save
            ClearForm();
            
            System.Diagnostics.Debug.WriteLine("Expense added successfully");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error saving expense: {ex.Message}");
        }
    }

    [RelayCommand]
    private async Task SubmitIncome()
    {
        // Add proper null check
        if (_appDbContext == null)
        {
            System.Diagnostics.Debug.WriteLine("Database context is not available");
            return;
        }

        // Add validation
        if (string.IsNullOrWhiteSpace(Name) || Amount <= 0)
        {
            System.Diagnostics.Debug.WriteLine("Invalid transaction data");
            return;
        }

        var income = new TransactionModel
        {
            Amount = Amount,
            Name = Name,
            Category = "Income", // Provide default
            Type = TransactionType.INCOME,
            Notes = Notes ?? string.Empty,
            Date = DateTime.Now
        };

        try
        {
            _appDbContext.Transactions.Add(income); // Fixed: consistent usage
            await _appDbContext.SaveChangesAsync();
            
            ClearForm();
            
            System.Diagnostics.Debug.WriteLine("Income added successfully");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error saving income: {ex.Message}");
        }
    }

    private void ClearForm()
    {
        Name = string.Empty;
        Category = string.Empty;
        Notes = string.Empty;
        Amount = 0;
        IsExpense = true;
        IsIncome = false;
    }
}