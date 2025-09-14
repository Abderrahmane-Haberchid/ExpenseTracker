using DefaultNamespace;
using ExpenseTrackerApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Mappers;

public class TransactionMapper
{
    public TransactionModel DtoToEntity(TransactionDto dto)
    {
        return new TransactionModel()
        {
            Name = dto.Name,
            Description = dto.Description,
            Category = dto.Category,
            CategoryIcon = dto.CategoryIcon,
            Date = DateTime.Now,
            Amount = dto.Amount,
            Type = TransactionType.EXPENSE,
            IsFavourite = dto.IsFavourite
        };
    }

    public TransactionDto EntityToDto(TransactionModel entity)
    {
        return new TransactionDto(
                        entity.Name,
                        entity.Description,
                        entity.Category,
                        entity.CategoryIcon,
                        entity.Date,
                        entity.Amount,
                        entity.Type,
                        entity.IsFavourite
        );
    }

    public List<TransactionDto> ListTransactionToDtos(List<TransactionModel> transactionModels)
    {
        List<TransactionDto> transactionDtos = new List<TransactionDto>();

        foreach (var transactionModel in transactionModels)
        {
            transactionDtos.Add(new TransactionDto(
                transactionModel.Name,
                transactionModel.Description,
                transactionModel.Category,
                transactionModel.CategoryIcon,
                transactionModel.Date,
                transactionModel.Amount,
                transactionModel.Type,
                transactionModel.IsFavourite
                ));
        }
        
        return transactionDtos;
    }
}