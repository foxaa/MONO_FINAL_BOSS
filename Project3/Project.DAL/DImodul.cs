using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace Project.DAL
{
    public class DImodul : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleContext>().To<VehicleContext>();
        }
    }
}
