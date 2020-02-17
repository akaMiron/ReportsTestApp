using Reports.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Web.Models
{
    public class SecondReportModel
    {
        public string ArrivalCity { get; set; }
        public string DepartureCity { get; set; }
        public int SummaryTrips { get; set; }
    }
}
