using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Service.Common;
using Project.Repository.Common;
using Project.Common;
using PagedList;

namespace Project.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository vehicleModelRepository;
        public VehicleModelService(IVehicleModelRepository context)
        {
            vehicleModelRepository = context;
        }
        public async Task<int> AddAsync(IVehicleModelDomainModel entity)
        {
            return await vehicleModelRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAllAsync(IEnumerable<IVehicleModelDomainModel> entity)
        {
            return await vehicleModelRepository.DeleteAllAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await vehicleModelRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<IVehicleModelDomainModel>> GetAllAsync()
        {
            return await vehicleModelRepository.GetAllAsync();
        }

        public async Task<IVehicleModelDomainModel> GetAsync(Guid id)
        {
            return await vehicleModelRepository.GetAsync(id);
        }

        public async Task<IPagedList<IVehicleModelDomainModel>> SortModelAsync(Sorting sorting, Filtering filtering, Paging paging)
        {
            return await vehicleModelRepository.SortModelAsync(sorting, filtering, paging);
        }

        public async Task<int> UpdateAsync(IVehicleModelDomainModel entity)
        {
            return await vehicleModelRepository.UpdateAsync(entity);
        }
    }
}
