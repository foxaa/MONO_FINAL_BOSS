using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository.Common;
using Project.DAL;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Project.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        public IVehicleContext vehicleContext;


    }
}
