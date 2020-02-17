using Reports.Core.Models;
using Reports.Core.Repositories;

namespace Reports.Data.Repositories
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(ReportsDbContext context)
               : base(context)
        { }

        private ReportsDbContext ReportsDbContext
        {
            get { return Context as ReportsDbContext; }
        }
    }
}
