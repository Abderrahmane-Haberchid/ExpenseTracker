using System;
using System.IO;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Configuration;

public class AppDbContext : DbContext
{
    public DbSet<TransactionModel> Transactions { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     var LocalFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    //     var DbPath = Path.Combine(LocalFolderPath, "ExpenseTracker", "ExpenseTracker.db");
    //     
    //     optionsBuilder.UseSqlite($"Data Source={DbPath}");
    // }
}