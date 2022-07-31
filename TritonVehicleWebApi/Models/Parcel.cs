using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TritonVehicleWebApi.Models
{
    public class Parcel
    {
        [Key]
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string Dimensions { get; set; }
        public string Mass { get; set; }
        public string Service { get; set; }
    }
}
