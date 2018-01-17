using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Project.Repository.Common;

namespace Project.Repository
{
    public class DIModul : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleModelRepository>().To<VehicleModelRepository>();
            Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IGenericRepository>().To<GenericRepository>();
        }
    }
}
