using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.Dtos;

public record TransactionDto(
 string Name, 
 string Description,
 string Category,
 string CategoryIcon,
 DateTime CreationDate,
 decimal Amount,
 TransactionType Type,
 bool IsFavourite 
    );