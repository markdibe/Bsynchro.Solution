using Bsynchro.Contracts.BO.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.BO.Accounts
{
    public class AccountInfoBO
    {
        public string AccountNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<TransactionInfoBO> TransactionInfos { get; set; }

    }
}
