using Reports.Core.Models;
using Reports.Core.Repositories;

namespace Reports.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(ReportsDbContext context)
               : base(context)
        { }

        private ReportsDbContext ReportsDbContext
        {
            get { return Context as ReportsDbContext; }
        }
    }
}
