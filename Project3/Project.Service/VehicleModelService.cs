using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Service.Common;
using Project.Repository.Common;

namespace Project.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository vmoRep;
        public VehicleModelService(IVehicleModelRepository context)
        {
            vmoRep = context;
        }
        public async Task<int> AddAsync(IVehicleModelDomainModel entity)
        {
            return await vmoRep.AddAsync(entity);
        }

        public async Task<int> DeleteAllAsync(IEnumerable<IVehicleModelDomainModel> entity)
        {
            return await vmoRep.DeleteAllAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await vmoRep.DeleteAsync(id);
        }

        public async Task<IEnumerable<IVehicleModelDomainModel>> GetAllAsync()
        {
            return await vmoRep.GetAllAsync();
        }

        public async Task<IVehicleModelDomainModel> GetAsync(Guid id)
        {
            return await vmoRep.GetAsync(id);
        }

        public async Task<IEnumerable<IVehicleModelDomainModel>> SortModelAsync(int pageNumber, int pageSize, string sortOrder, string searchString)
        {
            return await vmoRep.SortModelAsync(pageNumber, pageSize, sortOrder, searchString);
        }

        public async Task<int> UpdateAsync(IVehicleModelDomainModel entity)
        {
            return await vmoRep.UpdateAsync(entity);
        }
    }
}
