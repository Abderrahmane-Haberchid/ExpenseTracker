using ExpenseTrackerApi.Dtos;
using ExpenseTrackerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Controller; 

    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        // Constructor injection
        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult AddTransaction([FromBody] TransactionDto transaction)
        {
            var result = _transactionService.Save(transaction);
            if (result != null)
                return Ok(result);

            return BadRequest("Transaction failed to save.");
        }
        
        [HttpGet]
        public ActionResult<List<TransactionDto>> GetAllTransactions()
        {
            var result = _transactionService.GetAll();
            return Ok(result);
        }
    }