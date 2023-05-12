using Bsynchro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.Repos
{
    public interface IAccountRepos : IRepository<Account>
    {
        bool IsAccountExisted(string accountNumber);
        Account? GetAccountByNumber(string accountNumber);
        List<Account> GetAccounts(int take = 10, int skip = 0);
    }
}
