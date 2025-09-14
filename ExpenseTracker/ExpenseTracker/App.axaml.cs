using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ExpenseTracker.Configuration;
using ExpenseTracker.ViewModels;
using ExpenseTracker.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>( options =>
        {
            var LocalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var DbPath = Path.Combine(LocalFolderPath, "ExpenseTracker", "ExpenseTracker.db");
            options.UseSqlite($"Data Source={DbPath}");
        } );
        
        // Registring ViewModels
        services.AddTransient<AddTransactionViewModel>();
        services.AddTransient<AnalyticsViewModel>();
        services.AddTransient<HistoryViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<MainViewModel>();
        
        // Registring Views
        services.AddTransient<MainWindow>();
        services.AddTransient<AddTransactionView>();
        services.AddTransient<AnalyticsView>();
        services.AddTransient<HistoryView>();
        services.AddTransient<HomeView>();
    }
}