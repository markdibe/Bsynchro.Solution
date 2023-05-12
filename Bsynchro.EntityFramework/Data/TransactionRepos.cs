using Bsynchro.Contracts.Repos;
using Bsynchro.Domain;
using Bsynchro.EntityFramework.Core;

namespace Bsynchro.EntityFramework.Data
{
    public class TransactionRepos : Repository<Transaction>, ITransactionRepos
    {
        public TransactionRepos(RJPDbContext context) : base(context)
        {
        }

    }
}
