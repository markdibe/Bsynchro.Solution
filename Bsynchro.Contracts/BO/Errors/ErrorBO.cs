using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.BO.Errors
{
    public class ErrorBO
    {
        public Guid ErrorId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string ErrorType { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
