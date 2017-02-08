using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Models;

namespace Project.Model.Common
{
    public interface IVehicleMakeDomainModel
    {
        Guid id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        ICollection<IVehicleModelDomainModel> VehicleModels { get; set; }
    }
}
