using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TritonVehicleWebApi.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public string Branch { get; set; }
        public string FuelType { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public string Transmission { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal Capacity { get; set; }

    }
}
