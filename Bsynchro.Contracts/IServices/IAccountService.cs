using Bsynchro.Contracts.BO.Accounts;
using Bsynchro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.IServices
{
    public interface IAccountService
    {
        Task<AccountBO> AddAccount(CreateAccountBO account);
        bool IsAccountExisted(string accountNumber);
        List<AccountInfoBO> GetAccounts(int take, int skip);

        int CountAccounts();

    }
}
