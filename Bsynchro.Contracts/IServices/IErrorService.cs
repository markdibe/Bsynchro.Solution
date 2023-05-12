using Bsynchro.Contracts.BO.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.IServices
{
    public interface IErrorService
    {
        Task<ErrorBO> Create(ErrorBO errorBO);
    }
}
