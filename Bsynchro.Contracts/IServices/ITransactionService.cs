using Bsynchro.Contracts.BO.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.IServices
{
    public interface ITransactionService
    {
        Task MakeTransactions(TransactionBO transactionbo);
    }
}
