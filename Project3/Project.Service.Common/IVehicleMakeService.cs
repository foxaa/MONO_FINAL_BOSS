using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<IVehicleMakeDomainModel>> GetAllAsync();
        Task<int> AddAsync(IVehicleMakeDomainModel entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAllAsync(IEnumerable<IVehicleMakeDomainModel> entity);
        Task<int> UpdateAsync(IVehicleMakeDomainModel entity);
        Task<IVehicleMakeDomainModel> GetAsync(Guid id);
        Task<IEnumerable<IVehicleMakeDomainModel>> SortMakeAsync(int pageNumber, int pageSize,string sortOrder, string searchString);
    }
}
