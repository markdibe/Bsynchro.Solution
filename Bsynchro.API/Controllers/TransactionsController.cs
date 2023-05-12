using Bsynchro.Contracts.BO.Transactions;
using Bsynchro.Contracts.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Bsynchro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("Transact")]
        public async Task Transact(TransactionBO transactionBO)
        {
            await _transactionService.MakeTransactions(transactionBO);
        }
    }
}
