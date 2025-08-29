using ExpenseTracker.models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.config;

public class ExpenseTrackerContext : DbContext
{
    public DbSet<Income> Incomes { get; set; }
    public DbSet<Expense> Expenses { get; set; }

    public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options) : base(options) { }
    
   }