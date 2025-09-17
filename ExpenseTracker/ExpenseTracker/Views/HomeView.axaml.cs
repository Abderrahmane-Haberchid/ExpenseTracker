using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExpenseTracker.Configuration;
using ExpenseTracker.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        
        InitializeComponent();
        DataContext = new HomeViewModel();
    }
}