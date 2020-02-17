using Reports.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reports.Core.Services
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> GetAllTrips();
        Task<Trip> GetTripById(int id);
        Task<Trip> CreateTrip(Trip newTrip);
        Task UpdateTrip(Trip tripToBeUpdated, Trip trip);
        Task DeleteTrip(Trip trip);
    }
}
