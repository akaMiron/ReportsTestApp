using Reports.Core;
using Reports.Core.Models;
using Reports.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reports.Services
{
    public class TripService : ITripService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TripService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Trip> CreateTrip(Trip newTrip)
        {
            await _unitOfWork.Trips.AddAsync(newTrip);
            await _unitOfWork.CommitAsync();

            return newTrip;
        }

        public async Task DeleteTrip(Trip trip)
        {
            _unitOfWork.Trips.Remove(trip);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Trip>> GetAllTrips()
        {
            return await _unitOfWork.Trips.GetAllAsync();
        }

        public async Task<Trip> GetTripById(int id)
        {
            return await _unitOfWork.Trips.GetByIdAsync(id);
        }

        public async Task UpdateTrip(Trip tripToBeUpdated, Trip trip)
        {
            tripToBeUpdated.ArrivalCityId = trip.ArrivalCityId;
            tripToBeUpdated.DepartureCityId = trip.DepartureCityId;
            tripToBeUpdated.Date = trip.Date;

            await _unitOfWork.CommitAsync();
        }

    }
}
