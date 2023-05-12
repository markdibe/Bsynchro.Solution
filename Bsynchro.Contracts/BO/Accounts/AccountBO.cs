using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.BO.Accounts
{
    public class AccountBO
    {
        public Guid AccountId { get; set; } 
        public string AccountNumber { get; set; }
        public bool IsExisted { get; set; }
    }
}
