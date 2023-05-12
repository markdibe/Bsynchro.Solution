using Bsynchro.Contracts.IRepos;
using Bsynchro.Domain;
using Bsynchro.EntityFramework.Core;

namespace Bsynchro.EntityFramework.Data
{
    public class ErrorRepos : Repository<Error>, IErrorRepos
    {
        public ErrorRepos(RJPDbContext context) : base(context)
        {
        }
    }
}
