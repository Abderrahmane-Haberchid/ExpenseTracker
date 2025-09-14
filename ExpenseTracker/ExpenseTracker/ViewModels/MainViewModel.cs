using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Configuration;

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
        CurrentPage = new AddTransactionViewModel(new AppDbContext(null));
    }
    [RelayCommand]
    private void Analytic()
    {
        CurrentPage = new AnalyticsViewModel();
    }
    [RelayCommand]
    private void History()
    {
        CurrentPage = new HistoryViewModel();
    }
}