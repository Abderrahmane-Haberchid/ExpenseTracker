using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Configuration;
using ExpenseTracker.Enum;
using ExpenseTracker.Models;

namespace ExpenseTracker.ViewModels;

public partial class AddTransactionViewModel : ViewModelBase
{
    
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _category;
    [ObservableProperty] private string _notes;
    [ObservableProperty] private decimal _amount;
    
    [ObservableProperty]
    private bool _isExpense = true;

    [ObservableProperty]
    private bool _isIncome;
    
    private readonly AppDbContext? _appDbContext;

    public AddTransactionViewModel(AppDbContext appDbContext)
    {
        this._appDbContext = appDbContext;
    }

    [RelayCommand]
    private void SetIsExpense()
    {
        IsExpense = true;
        IsIncome = !IsExpense;
    }

    [RelayCommand]
    private void SetIsIncome()
    {
        IsIncome = true;
        IsExpense = !IsExpense;
    }

    [RelayCommand]
    private async Task SubmitExpense()
    {
        var expense = new TransactionModel
        {
            Amount = Amount,
            Name = Name,
            Category = Category,
            Type = TransactionType.EXPENSE,
            Notes = Notes,
        };
        if (expense != null)
        {
            await _appDbContext.Transactions.AddAsync(expense);
            await _appDbContext.SaveChangesAsync();
        }
    }

    [RelayCommand]
    private async Task SubmitIncome()
    {
        var expense = new TransactionModel
        {
            Amount = Amount,
            Name = Name,
            Type = TransactionType.INCOME,
            Notes = Notes,
        };

        if (expense != null)
        {
            _appDbContext?.Transactions.Add(expense);
            await _appDbContext?.SaveChangesAsync();
        }
        
    }
}