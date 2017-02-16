using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Common;
using Project.Repository.Common;
using Project.Repository;
using Project.Model.Common;


namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository vmRep;

        public VehicleMakeService(IVehicleMakeRepository vm)
        {
            vmRep = vm;
        }
        public async Task<int> AddAsync(IVehicleMakeDomainModel entity)
        {
            return await vmRep.AddAsync(entity);
            
        }

        public async Task<int> DeleteAllAsync(IEnumerable<IVehicleMakeDomainModel> entity)
        {
            return await vmRep.DeleteAllAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await vmRep.DeleteAsync(id);
        }

        public async Task<IEnumerable<IVehicleMakeDomainModel>> GetAllAsync()
        {
            return await vmRep.GetAllAsync();
        }

        public async Task<IVehicleMakeDomainModel> GetAsync(Guid id)
        {
            return await vmRep.GetAsync(id);
        }

        public async Task<int> UpdateAsync(IVehicleMakeDomainModel entity)
        {
            return await vmRep.UpdateAsync(entity);
        }
    }
}
