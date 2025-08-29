using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.models;

public class Expense
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    private string Id { get; set; }
    private string Name { get; set; }
    private string Description { get; set; }
    private string Category { get; set; }
    private string CategoryIcon { get; set; }
    private DateTime Date { get; set; }
    private decimal Amount { get; set; }
    private bool IsFavourite { get; set; }
    
}