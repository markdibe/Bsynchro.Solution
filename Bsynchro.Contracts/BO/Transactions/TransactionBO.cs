using Bsynchro.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.BO.Transactions
{
    public class TransactionBO
    {
        public Guid? TransactionId { get; set; }
        public DateTime? TransactionTime { get; set; } = DateTime.UtcNow;
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
