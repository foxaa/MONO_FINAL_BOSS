using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Project.Model.Common;

namespace Project.Model
{
    public class DImodul : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleMakeDomainModel>().To<VehicleMakeDomainModel>();
            Bind<IVehicleModelDomainModel>().To<VehicleModelDomainModel>();
        }
    }
}
