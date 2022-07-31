using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TritonVehicleWebApi.Models
{
    public class ParcelInformation
    {
        public Parcel Parcel { get; set; }
        public ParcelCounter ParcelCounter { get; set; }
    }
}
