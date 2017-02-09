using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository.Common;
using Project.DAL;
using Project.DAL.Models;
using Project.Model.Common;
using AutoMapper;

namespace Project.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private IGenericRepository genRep;
        public VehicleMakeRepository(IGenericRepository context)
        {
            genRep = context;
        }

        public async Task<int> AddAsync(IVehicleMakeDomainModel entity)
        {
            return await genRep.AddAsync(Mapper.Map<VehicleMake>(entity));
        }


        public async Task<int> DeleteAllAsync(IEnumerable<IVehicleMakeDomainModel> entity)
        {
            return await genRep.DeleteAllAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genRep.DeleteAsync<IVehicleMakeDomainModel>(id);
        }

        public async Task<IEnumerable<IVehicleMakeDomainModel>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<IVehicleMakeDomainModel>>(await genRep.GetAllAsync<VehicleMake>());
        }

        public async Task<IVehicleMakeDomainModel> GetAsync(Guid id)
        {
            return Mapper.Map<IVehicleMakeDomainModel>(await genRep.GetAsync<VehicleMake>(id));
        }

        public async Task<int> UpdateAsync(IVehicleMakeDomainModel entity)
        {
            return await genRep.UpdateAsync(Mapper.Map<VehicleMake>(entity));
        }

    }
}
