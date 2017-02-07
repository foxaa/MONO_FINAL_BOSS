using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL;
using System.Data.Entity;

namespace Project.DAL.Models
{
    public class VehicleMake
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
