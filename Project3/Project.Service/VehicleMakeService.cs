using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Common;
using Project.Repository.Common;
using Project.Repository;
using Project.Model.Common;
using Project.Common;
using PagedList;

namespace Project.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vm)
        {
            vehicleMakeRepository = vm;
        }
        public async Task<int> AddAsync(IVehicleMakeDomainModel entity)
        {
            return await vehicleMakeRepository.AddAsync(entity);

        }

        public async Task<int> DeleteAllAsync(IEnumerable<IVehicleMakeDomainModel> entity)
        {
            return await vehicleMakeRepository.DeleteAllAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await vehicleMakeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<IVehicleMakeDomainModel>> GetAllAsync()
        {
            return await vehicleMakeRepository.GetAllAsync();
        }

        public async Task<IVehicleMakeDomainModel> GetAsync(Guid id)
        {
            return await vehicleMakeRepository.GetAsync(id);
        }

        public async Task<IPagedList<IVehicleMakeDomainModel>> SortMakeAsync(Sorting sorting, Filtering filtering, Paging paging)
        {
            return await vehicleMakeRepository.SortMakeAsync(sorting, filtering, paging);
        }

        public async Task<int> UpdateAsync(IVehicleMakeDomainModel entity)
        {
            return await vehicleMakeRepository.UpdateAsync(entity);
        }
    }
}
