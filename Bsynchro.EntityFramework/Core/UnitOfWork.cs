using Bsynchro.Contracts.IRepos;
using Bsynchro.Contracts.Repos;
using Bsynchro.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.EntityFramework.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RJPDbContext _context;
        private Dictionary<Type, object> _repositories;

        #region private repos
        private ITransactionRepos _transaction;
        private IAccountRepos _accountRepos;
        private IErrorRepos _errorRepos;
        #endregion

        public UnitOfWork(RJPDbContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            var type = typeof(T);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<T>(_context);
            }

            return (IRepository<T>)_repositories[type];
        }



        public void Dispose()
        {
            _context.Dispose();
        }

        #region Account Repos
        public IAccountRepos AccountRepos { get { if (_accountRepos == null) { _accountRepos = new AccountRepos(_context); } return _accountRepos; } }
        public ITransactionRepos TransactionRepos { get { if (_transaction == null) { _transaction = new TransactionRepos(_context); } return _transaction; } }
        public IErrorRepos ErrorRepos { get { if (_errorRepos == null) { _errorRepos = new ErrorRepos(_context); } return _errorRepos; } }
        #endregion
    }

}
