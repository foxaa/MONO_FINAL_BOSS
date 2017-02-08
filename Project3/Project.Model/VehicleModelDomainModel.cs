using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Models;
using Project.Model.Common;

namespace Project.Model
{
    public class VehicleModelDomainModel:IVehicleModelDomainModel
    {
        public Guid VehicleModelId { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual IVehicleMakeDomainModel VehicleMake { get; set; }
    }
}
