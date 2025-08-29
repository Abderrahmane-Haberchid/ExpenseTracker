using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ExpenseTracker.ViewModels;

namespace ExpenseTracker.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = new HomeViewModel();
    }
}