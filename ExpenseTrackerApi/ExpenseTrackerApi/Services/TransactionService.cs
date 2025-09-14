using DefaultNamespace;
using ExpenseTrackerApi.Dtos;

namespace ExpenseTrackerApi.Services;

public interface TransactionService
{
    
    public TransactionDto Save(TransactionDto transaction);
    public List<TransactionDto> GetAll();
}