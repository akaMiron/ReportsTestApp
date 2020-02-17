using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.Core;
using Reports.Core.Models;
using Reports.Core.Services;

namespace Reports.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<City> CreateCity(City newCity)
        {
            await _unitOfWork.Cities.AddAsync(newCity);
            await _unitOfWork.CommitAsync();

            return newCity;
        }

        public async Task DeleteCity(City city)
        {
            _unitOfWork.Cities.Remove(city);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _unitOfWork.Cities.GetAllAsync();
        }

        public async Task<City> GetCityById(int id)
        {
            return await _unitOfWork.Cities.GetByIdAsync(id);
        }

        public async Task UpdateCity(City cityToBeUpdated, City city)
        {
            cityToBeUpdated.Name = city.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
