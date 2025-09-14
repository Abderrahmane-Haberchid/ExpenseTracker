using DefaultNamespace;
using ExpenseTrackerApi.Dtos;
using ExpenseTrackerApi.Mappers;

namespace ExpenseTrackerApi.Services.Impl;

public class TransactionServiceImpl : TransactionService
{
    
    private readonly AppDbContext _dbContext;
    private readonly TransactionMapper _mapper;

    public TransactionServiceImpl(AppDbContext dbContext, TransactionMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public TransactionDto Save(TransactionDto transactionDto)
    {
        try
        {
            var transaction = _mapper.DtoToEntity(transactionDto);
            var savedTransaction = _dbContext.Transactions.Add(transaction);
            
            return _mapper.EntityToDto(transaction);;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<TransactionDto> GetAll()
    {
        try
        {
            return _mapper.ListTransactionToDtos(_dbContext.Transactions.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}