using Reports.Core;
using Reports.Core.Repositories;
using Reports.Data.Repositories;
using System.Threading.Tasks;

namespace Reports.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReportsDbContext _context;
        private TripRepository _tripRepository;
        private CityRepository _cityRepository;

        public UnitOfWork(ReportsDbContext context)
        {

            this._context = context;
        }

        public ICityRepository Cities => _cityRepository = _cityRepository ?? new CityRepository(_context);

        public ITripRepository Trips => _tripRepository = _tripRepository ?? new TripRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
