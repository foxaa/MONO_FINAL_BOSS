using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Models;
using Project.Model.Common;

namespace Project.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        //Task<IEnumerable<VehicleMake>> GetAllAsync<VehicleMake>(); //where VehicleMake : class;
        //Task<int> AddAsync<VehicleMake>(VehicleMake entity)  where VehicleMake : class;
        //Task<int> DeleteAsync<VehicleMake>(Guid id);// where T : class;
        //Task<int> DeleteAllAsync<VehicleMake>(IEnumerable<VehicleMake> entity);// where T : class;
        //Task<int> UpdateAsync<VehicleMake>(VehicleMake entity); //where T : class;
        //Task<bool> AnyAsync<VehicleMake>(); //where T : class;
        Task<IEnumerable<IVehicleMakeDomainModel>> GetAllAsync();
        Task<int> AddAsync(IVehicleMakeDomainModel entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAllAsync(IEnumerable<IVehicleMakeDomainModel> entity);
        Task<int> UpdateAsync(IVehicleMakeDomainModel entity);
        Task<IVehicleMakeDomainModel> GetAsync(Guid id);
        

    }
}
