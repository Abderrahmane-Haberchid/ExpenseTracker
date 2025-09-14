using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ExpenseTracker.ViewModels;
using ExpenseTracker.Views;

namespace ExpenseTracker;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var mainView = new MainView
        {
            DataContext = new MainViewModel()
        };

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new Window
                {
                    Content = mainView
                };
                break;

            case ISingleViewApplicationLifetime singleViewLifetime:
                // Used in mobile apps (Android, iOS)
                singleViewLifetime.MainView = mainView;
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }
}