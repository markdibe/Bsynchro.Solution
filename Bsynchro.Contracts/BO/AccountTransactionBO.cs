using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.BO
{
    public class AccountTransactionBO
    {
        public Guid AccountId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
