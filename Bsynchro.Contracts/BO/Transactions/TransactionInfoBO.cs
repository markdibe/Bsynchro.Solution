using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.BO.Transactions
{
    public class TransactionInfoBO
    {
        public decimal Amount { get; set; }

        public DateTime TransactionTime { get; set; }
    }
}
