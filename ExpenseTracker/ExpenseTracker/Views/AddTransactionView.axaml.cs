
using Avalonia.Controls;
using ExpenseTracker.Configuration;
using ExpenseTracker.ViewModels;

namespace ExpenseTracker.Views;

public partial class AddTransactionView : UserControl
{
    public AddTransactionView()
    {
        InitializeComponent();
        DataContext = new AddTransactionViewModel();
    }
}