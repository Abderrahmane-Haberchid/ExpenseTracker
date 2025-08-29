using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ExpenseTracker.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] 
    private ViewModelBase _currentPage = new HomeViewModel();
    

    [RelayCommand]
    private void Home()
    {
        CurrentPage = new HomeViewModel();
    }

    [RelayCommand]
    private void AddTransaction()
    {
        CurrentPage = new AddTransactionViewModel();
    }
}