using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ExpenseTracker.ViewModels;

public partial class AnalyticsViewModel : ViewModelBase
{

    [ObservableProperty] public double _totalIncome;
    [ObservableProperty] public double _totalExpenses;
    [ObservableProperty] public double _netBalance;
    [ObservableProperty] public string _selectedCategory;
    [ObservableProperty] public string _categories;
    [ObservableProperty] public bool _showDetailedView;
    [ObservableProperty] public string _name;
    [ObservableProperty] public double _amount;
    [ObservableProperty] public string _selectedTrendPeriod;
    [ObservableProperty] public ObservableCollection<object> _topExpenseCategories = new();


    [RelayCommand]
    public void FilterThisMonth()
    {
        
    }
    [RelayCommand]
    public void FilterLast3Months()
    {
        
    }
    [RelayCommand]
    public void FilterThisYear()
    {
        
    }
    [RelayCommand]
    public void ApplyFilters()
    {
        
    }
    [RelayCommand]
    public void ClearFilters()
    {
        
    }
}