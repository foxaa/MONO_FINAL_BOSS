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
        private bool disposed;
        private IVehicleContext _vehicleContext;
        public UnitOfWork(IVehicleContext vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }
        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    _vehicleContext.Dispose();
                }
            }
            disposed = true;
        } 

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {

            return await _vehicleContext.SaveChangesAsync();
        }
    }
}
