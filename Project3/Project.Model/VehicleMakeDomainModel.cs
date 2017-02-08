using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Models;
using Project.Model.Common;

namespace Project.Model
{
    public class VehicleMakeDomainModel:IVehicleMakeDomainModel
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<IVehicleModelDomainModel> VehicleModels { get; set; }
    }
}
