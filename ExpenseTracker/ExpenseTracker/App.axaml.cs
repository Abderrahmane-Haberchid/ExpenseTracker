using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ExpenseTracker.Configuration;
using ExpenseTracker.DependecyInejction;
using ExpenseTracker.ViewModels;
using ExpenseTracker.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker;

public partial class App : Application
{
    // This is a service provider will allow us to access services to inject
    public static IServiceProvider ServiceProvider { get; private set; } = default!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        
        // Initiliazing services collection
        var collection = new ServiceCollection();
        collection.AddCommonServices();
        
        // Building services and assign them to ServiceProvider Object
        ServiceProvider = collection.BuildServiceProvider();
        
        // Ensuring db has been created for Native AOT
        using (var scope = ServiceProvider.CreateScope())
        {
            try
            {
                scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated();
                Console.WriteLine("Database Migrated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("falied to create database ; " + e.Message);
                throw;
            }
        }   
        
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