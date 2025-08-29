using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ExpenseTracker.ViewModels;

public partial class AddTransactionViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isExpense = true;

    [ObservableProperty]
    private bool _isIncome;

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
    private void SubmitExpense(){}
    [RelayCommand]
    private void SubmitIncome(){}
}