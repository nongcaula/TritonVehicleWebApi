using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TritonVehicleWebApi.Models
{
    public class WayBills
    {
        public List<WayBillForm> WayBillForms { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
