using Reports.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reports.Core.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCityById(int id);
        Task<City> CreateCity(City newCity);
        Task UpdateCity(City cityToBeUpdated, City city);
        Task DeleteCity(City city);
    }
}
