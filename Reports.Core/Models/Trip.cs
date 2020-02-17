using System;

namespace Reports.Core.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public City ArrivalCity { get; set; }
        public City DepartureCity { get; set; }
        public int ArrivalCityId { get; set; }
        public int DepartureCityId { get; set; }
    }
}
