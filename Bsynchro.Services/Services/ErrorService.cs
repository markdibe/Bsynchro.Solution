using AutoMapper;
using Bsynchro.Contracts.BO.Errors;
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
    public class ErrorService : IErrorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;
        public ErrorService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public async Task<ErrorBO> Create(ErrorBO errorBO)
        {
            Error error = Convert(errorBO);
            await _unit.ErrorRepos.Add(error);
            await _unit.Save();
            return Convert(error);
        }

        private Error Convert(ErrorBO errorBO)
        {
            return _mapper.Map<Error>(errorBO);
        }

        private ErrorBO Convert(Error errorBO)
        {
            return _mapper.Map<ErrorBO>(errorBO);
        }
    }
}
