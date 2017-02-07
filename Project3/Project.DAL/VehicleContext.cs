using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Project.DAL
{
    public class VehicleContext:DbContext,IVehicleContext
    {
        public VehicleContext() : base("VehicleContext")
        {
        }

        public DbSet<VehicleMake> VehicleMakers { get; set; }//kreiramo tablicu
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // da nazivi tablica u bazi nebudu u mnozini
        }
    }
}
