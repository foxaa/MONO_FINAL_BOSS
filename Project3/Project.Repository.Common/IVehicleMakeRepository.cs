using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Models;
using Project.Model.Common;
using Project.Common;
using PagedList;

namespace Project.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<IVehicleMakeDomainModel>> GetAllAsync();
        Task<int> AddAsync(IVehicleMakeDomainModel entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAllAsync(IEnumerable<IVehicleMakeDomainModel> entity);
        Task<int> UpdateAsync(IVehicleMakeDomainModel entity);
        Task<IVehicleMakeDomainModel> GetAsync(Guid id);
        Task<IPagedList<IVehicleMakeDomainModel>> SortMakeAsync(Sorting sorting, Filtering filtering, Paging paging);


    }
}
