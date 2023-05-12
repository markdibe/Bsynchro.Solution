using Bsynchro.Application.Services;
using Bsynchro.Contracts.IServices;

namespace Bsynchro.API.Dependencies
{
    public class ServiceResolver
    {
        public static void Resolve(IServiceCollection services)
        {
            services.AddScoped<IErrorService, ErrorService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();
        }
    }
}
