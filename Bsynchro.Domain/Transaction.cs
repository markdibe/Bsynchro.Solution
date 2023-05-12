using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Domain
{
    /// <summary>
    /// Transaction Entity 
    /// An event take place when an account make a transaction 
    /// A transaction is always for one Account
    /// </summary>
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid TransactionId { get; set; }
        public DateTime TransactionTime { get; set; }

        [Required]
        [ForeignKey(nameof(Account))]
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }
        public decimal Amount { get; set; }
    }
}
