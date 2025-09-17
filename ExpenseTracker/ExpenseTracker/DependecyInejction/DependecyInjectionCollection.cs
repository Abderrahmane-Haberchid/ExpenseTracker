using System;
using System.IO;
using Avalonia;
using ExpenseTracker.Configuration;
using ExpenseTracker.ViewModels;
using ExpenseTracker.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.DependecyInejction;

// This class hoold a collection of services need to be injected
public static class DependecyInjectionCollection
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        // Application
        collection.AddSingleton(_ => Application.Current!);
        
        // Main Window
        collection.AddSingleton<MainWindow>();
        
        // Registring ViewModels
        collection.AddTransient<AddTransactionViewModel>();
        collection.AddTransient<AnalyticsViewModel>();
        collection.AddTransient<HistoryViewModel>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<MainViewModel>();
        
        // Registring Views
        collection.AddTransient<MainWindow>();
        collection.AddTransient<AddTransactionView>();
        collection.AddTransient<AnalyticsView>();
        collection.AddTransient<HistoryView>();
        collection.AddTransient<HomeView>();
        
        // Registering AppDbContext 
        collection.AddDbContext<AppDbContext>(options =>
        {
            var localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = Path.Combine(localFolderPath, "ExpenseTracker", "ExpenseTracker.db");
            
            options.UseSqlite($"Data Source={dbPath}");
            
            Console.WriteLine("Db will be created here : " + dbPath);
        });
    }
}