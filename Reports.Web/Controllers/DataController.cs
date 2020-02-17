using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Reports.Core.Models;
using Reports.Core.Services;
using Reports.Web.Models;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Reports.Web.Controllers
{
    [Authorize]
    public class DataController : Controller
    {
        private readonly ITripService _tripService;
        private readonly ICityService _cityService;

        public DataController(ITripService tripService, ICityService cityService)
        {
            _tripService = tripService;
            _cityService = cityService;
        }

        [Authorize(Roles = "admin, first")]
        public IActionResult FirstReport()
        {
            return View();
        }


        [Authorize(Roles = "admin, second")]
        public IActionResult SecondReport()
        {
            return View();
        }

        public IActionResult GetFirstReportData()
        {
            try
            {

                //var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                //// Skip number of Rows count  
                //var start = Request.Form["start"].FirstOrDefault();

                //// Paging Length 10,20  
                //var length = Request.Form["length"].FirstOrDefault();

                //// Sort Column Name  
                //string v = Request.Form["order[0][column]"].FirstOrDefault();
                //var sortColumn = Request.Form["columns[" + v + "][name]"].FirstOrDefault(); 

                //// Sort Column Direction (asc, desc)  
                //var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                //// Search Value from (Search box)  
                //var searchValue = Request.Form["search[value]"].FirstOrDefault();

                ////Paging Size (10, 20, 50,100)  
                //int pageSize = length != null ? Convert.ToInt32(length) : 0;

                //int skip = start != null ? Convert.ToInt32(start) : 0;

                //int recordsTotal = 0;

                var trips = CastToFirstReportModel(_tripService.GetAllTrips().Result.ToList()).AsQueryable();

                ////Sorting  
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    trips = trips.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                ////Search  
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    trips = trips.Where(m => m.ArrivalCity == searchValue);
                //}

                ////total number of rows counts   
                //recordsTotal = trips.Count();
                //Paging   
                //var data = trips.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return new JsonResult(/* draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal,*/  trips);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult GetSecondReportData()
        {
            var trips = CastToSecondReportModel(_tripService.GetAllTrips().Result.ToList()).AsQueryable();

            return new JsonResult(trips);
        }

        private IEnumerable<SecondReportModel> CastToSecondReportModel(IEnumerable<Trip> trips)
        {
            List<SecondReportModel> newModel = new List<SecondReportModel>();

            foreach (var trip in trips)
            {
                SecondReportModel model = new SecondReportModel
                {
                    ArrivalCity = _cityService.GetCityById(trip.ArrivalCityId).Result.Name,
                    DepartureCity = _cityService.GetCityById(trip.DepartureCityId).Result.Name,
                    SummaryTrips = 10
                };

                newModel.Add(model);
            }

            return newModel;
        }

        private IEnumerable<FirstReportModel> CastToFirstReportModel(IEnumerable<Trip> trips)
        {
            List<FirstReportModel> newModel = new List<FirstReportModel>();

            foreach (var trip in trips)
            {
                FirstReportModel model = new FirstReportModel
                {
                    ArrivalCity = _cityService.GetCityById(trip.ArrivalCityId).Result.Name,
                    DepartureCity = _cityService.GetCityById(trip.DepartureCityId).Result.Name,
                    SummaryTrips = 10,
                    PlannedTrips = 15,
                    Day1 = 20,
                    Day2 = 0,
                    Day3 = 0,
                    Day4 = 0,
                    Day5 = 0,
                    Day6 = 0,
                    Day7 = 0,
                    Day8 = 0,
                    Day9 = 0,
                    Day10 = 0,
                    Day11 = 0,
                    Day12 = 0,
                    Day13 = 0,
                    Day14 = 0,
                    Day15 = 0,
                    Day16 = 0,
                    Day17 = 0,
                    Day18 = 0,
                    Day19 = 0,
                    Day20 = 0,
                    Day21 = 0,
                    Day22 = 0,
                    Day23 = 0,
                    Day24 = 0,
                    Day25 = 0,
                    Day26 = 0,
                    Day27 = 0,
                    Day28 = 0,
                    Day29 = 0,
                    Day30 = 0,
                    Day31 = 0
                };

                newModel.Add(model);
            }

            return newModel;
        }
    }
}