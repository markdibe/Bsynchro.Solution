using Bsynchro.Contracts.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.Repos
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();
        IRepository<T> Repository<T>() where T : class;

        IAccountRepos AccountRepos { get; }
        ITransactionRepos TransactionRepos { get; }
        IErrorRepos ErrorRepos { get; }
    }
}
