using AutoMapper;
using Bsynchro.Contracts.BO.Accounts;
using Bsynchro.Contracts.BO.Errors;
using Bsynchro.Contracts.BO.Transactions;
using Bsynchro.Domain;
using System.Security.Principal;

namespace Bsynchro.Services
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Account, AccountBO>();
            CreateMap<AccountBO, Account>();
            CreateMap<Transaction, TransactionBO>();
            CreateMap<TransactionBO, Transaction>();
            CreateMap<Error,ErrorBO>();
            CreateMap<ErrorBO, Error>();
            
        }
    }
}