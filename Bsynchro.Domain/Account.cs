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
    /// Account Entity 
    /// Has Information about the client 
    /// An account can have list of Transactions
    /// </summary>
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid AccountId { get; set; }

        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }

        [Required]
        public string? AccountNumber { get; set; }
        
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
