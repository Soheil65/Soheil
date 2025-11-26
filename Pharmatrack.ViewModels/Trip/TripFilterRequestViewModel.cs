using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmatrack.ViewModels.Trip
{
    public class TripFilterRequestViewModel
    {
        public int PageNumber { get; set; } = 1;
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today;
        public List<TripStatus> Statuses { get; set; } = new List<TripStatus>();
        public int PageSize { get; set; } = 10;
    }
}
