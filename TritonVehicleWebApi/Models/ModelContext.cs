using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TritonVehicleWebApi.Models;

namespace TritonVehicleWebApi
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<WayBillForm> WayBillForm { get; set; }
        public DbSet<Parcel> Parcel { get; set; }
    }
}
