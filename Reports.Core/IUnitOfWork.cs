using Reports.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Reports.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICityRepository Cities { get; }
        ITripRepository Trips { get; }
        Task<int> CommitAsync();
    }
}
