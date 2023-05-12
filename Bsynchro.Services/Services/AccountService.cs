using AutoMapper;
using Bsynchro.Contracts.BO.Accounts;
using Bsynchro.Contracts.IServices;
using Bsynchro.Contracts.Repos;
using Bsynchro.Domain;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AccountBO> AddAccount(CreateAccountBO accountbo)
        {
            bool isExisted = _unitOfWork.AccountRepos.IsAccountExisted(accountbo.AccountNumber);
            var personGenerator = new PersonNameGenerator();
            Account account = new Account {AccountNumber = accountbo.AccountNumber, FirstName= personGenerator.GenerateRandomFirstName(), LastName = personGenerator.GenerateRandomLastName() };
            if (!isExisted)
            {
                await _unitOfWork.AccountRepos.Add(account);
                await _unitOfWork.Save();
            }
            else
            {
                account =  _unitOfWork.AccountRepos.GetAccountByNumber(accountbo.AccountNumber);
            }
            var result = Convert(account);result.IsExisted = isExisted;
            return result;
        }

        public bool IsAccountExisted(string accountNumber)
        {
            return _unitOfWork.AccountRepos.IsAccountExisted(accountNumber);
        }

        public List<AccountInfoBO> GetAccounts(int take,int skip)
        {
            var accountInfoList = (from accounts in _unitOfWork.AccountRepos.Query()
                               select new AccountInfoBO
                               {
                                   AccountNumber = accounts.AccountNumber,
                                   FirstName= accounts.FirstName,
                                   LastName= accounts.LastName,
                                   TransactionInfos = accounts.Transactions
                                   .Where(x=>x.AccountId.Equals(accounts.AccountId))
                                   .Select(x=>new Contracts.BO.Transactions.TransactionInfoBO { Amount = x.Amount, TransactionTime = x.TransactionTime})
                                   .ToList()
                               }
                               ).Skip(skip).Take(take).ToList();
            return accountInfoList;

        }

        public int CountAccounts()
        {
            var count = _unitOfWork.AccountRepos.Query().Count();
            return count;
        }

        private Account Convert(AccountBO account)
        {
            return _mapper.Map<Account>(account);
        }

        private AccountBO Convert(Account account)
        {
            return _mapper.Map<AccountBO>(account);
        }
    }
}
