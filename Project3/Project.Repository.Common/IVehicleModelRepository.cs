using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Common;
using PagedList;

namespace Project.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<IVehicleModelDomainModel>> GetAllAsync();
        Task<int> AddAsync(IVehicleModelDomainModel entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAllAsync(IEnumerable<IVehicleModelDomainModel> entity);
        Task<int> UpdateAsync(IVehicleModelDomainModel entity);
        Task<IVehicleModelDomainModel> GetAsync(Guid id);
        Task<IPagedList<IVehicleModelDomainModel>> SortModelAsync(Sorting sorting, Filtering filtering, Paging paging);
    }
}
