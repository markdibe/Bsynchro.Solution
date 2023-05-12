using AutoMapper;
using Bsynchro.Contracts.BO.Transactions;
using Bsynchro.Contracts.IServices;
using Bsynchro.Contracts.Repos;
using Bsynchro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public TransactionService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public async Task MakeTransactions(TransactionBO transactionbo)
        {
            Transaction transaction = Convert(transactionbo);
            await _unit.TransactionRepos.Add(transaction);
            await _unit.Save();
        }


        private Transaction Convert(TransactionBO transaction)
        {
            return _mapper.Map<Transaction>(transaction);
        }

        private TransactionBO Convert(Transaction transaction)
        {
            return _mapper.Map<TransactionBO>(transaction);
        }

    }
}
