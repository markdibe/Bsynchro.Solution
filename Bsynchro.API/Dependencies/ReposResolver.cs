using Bsynchro.Contracts.IRepos;
using Bsynchro.Contracts.Repos;
using Bsynchro.EntityFramework.Core;
using Bsynchro.EntityFramework.Data;

namespace Bsynchro.API.Dependencies
{
    public class ReposResolver
    {

        public static void Resolve(IServiceCollection services)
        {
            services.AddScoped<IErrorRepos, ErrorRepos>();
            services.AddScoped<ITransactionRepos, TransactionRepos>();
            services.AddScoped<IAccountRepos, AccountRepos>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
