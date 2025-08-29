using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Markup.Xaml;
using ExpenseTracker.config;
using ExpenseTracker.ViewModels;
using ExpenseTracker.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.IO;

namespace ExpenseTracker;

public partial class App : Application
{
    // A public static property to hold the host for global access
    public static IHost AppHost { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        // Step 1: Build the host for dependency injection
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder.SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("/Users/abderahman/RiderProjects/ExpenseTracker/ExpenseTracker/appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((hostContext, services) =>
            {
                // Register your DbContext
                services.AddDbContext<ExpenseTrackerContext>(options =>
                {
                    var connectionString = hostContext.Configuration.GetConnectionString("PostgresConnection");
                    options.UseNpgsql(connectionString);
                });

                // Register your ViewModels for DI
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<HomeViewModel>();
                // Register other services and ViewModels here
            })
            .Build();

        // Step 2: Initialize the database by applying migrations
        await InitializeDatabaseAsync();

        // Step 3: Set up the UI by resolving dependencies from the host
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DisableAvaloniaDataAnnotationValidation();
            // Resolve MainWindow from the service provider
            desktop.MainWindow = new MainWindow
            {
                DataContext = AppHost.Services.GetRequiredService<MainViewModel>()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = AppHost.Services.GetRequiredService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    // You can keep this method as is, but it will now work correctly
    // because AppHost.Services is properly initialized.
    private async Task InitializeDatabaseAsync()
    {
        using var scope = AppHost.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ExpenseTrackerContext>();
    
        try
        {
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database error: {ex.Message}");
        }
    }
    
    // Existing method remains unchanged
    private void DisableAvaloniaDataAnnotationValidation()
    {
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}