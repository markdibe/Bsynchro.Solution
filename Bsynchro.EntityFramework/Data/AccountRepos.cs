using Bsynchro.Contracts.Repos;
using Bsynchro.Domain;
using Bsynchro.EntityFramework.Core;
using Microsoft.EntityFrameworkCore;

namespace Bsynchro.EntityFramework.Data
{
    public class AccountRepos : Repository<Account>, IAccountRepos
    {
        public AccountRepos(RJPDbContext context) : base(context)
        {
        }

        public bool IsAccountExisted(string accountNumber)
        {
            return base._context.Accounts.Any(ac => ac.AccountNumber.Equals(accountNumber.Trim()));
        }

        public Account? GetAccountByNumber(string accountNumber)
        {
            if (IsAccountExisted(accountNumber))
            {
                return base._context.Accounts.FirstOrDefault(ac => ac.AccountNumber.Equals(accountNumber.Trim()));
            }
            return default;
        }

        public List<Account> GetAccounts(int take=10, int skip=0)
        {
            return base._context.Accounts.Include(nameof(Account.Transactions)).Skip(skip).Take(take).ToList();
        }
    }
}
