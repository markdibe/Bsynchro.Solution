using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.BO.Inputs
{
    public class AccountQueryInput
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
