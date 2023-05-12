using AutoMapper;
using Bsynchro.Contracts.BO.Accounts;
using Bsynchro.Contracts.BO.Inputs;
using Bsynchro.Contracts.IServices;
using Bsynchro.Contracts.Repos;
using Bsynchro.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Bsynchro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost(nameof(Create))]
        public async Task<AccountBO> Create(CreateAccountBO accountBO)
        {
            return await _accountService.AddAccount(accountBO);
        }

        [HttpGet(nameof(IsAccountExisted))]
        public bool IsAccountExisted(string accountNumber)
        {
            return _accountService.IsAccountExisted(accountNumber);
        }


        [HttpPost(nameof(GetAccountInformations))]
        public List<AccountInfoBO> GetAccountInformations(AccountQueryInput queryInput)
        {
            var result = _accountService.GetAccounts(queryInput.Take, queryInput.Skip);
            return result;
        }

        [HttpGet(nameof(CountAccounts))]
        public int CountAccounts()
        {
            return _accountService.CountAccounts();

        }




    }
}
