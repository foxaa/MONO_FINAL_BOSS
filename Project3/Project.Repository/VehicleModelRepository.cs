using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Repository.Common;
using AutoMapper;
using Project.DAL.Models;


namespace Project.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private IGenericRepository genRep;
        public VehicleModelRepository(IGenericRepository context)
        {
            genRep = context;
        }
        public async Task<int> AddAsync(IVehicleModelDomainModel entity)
        {
            return await genRep.AddAsync(Mapper.Map<VehicleMake>(entity));
            //return Mapper.Map<VehicleMake>(await genRep.AddAsync(entity));
            //return await genRep.AddAsync<VehicleMake>(Mapper.Map<VehicleMake>(entity));
        }

        public async Task<int> DeleteAllAsync(IEnumerable<IVehicleModelDomainModel> entity)
        {
            return await genRep.DeleteAllAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genRep.DeleteAsync<IVehicleModelDomainModel>(id);
        }

        public async Task<IEnumerable<IVehicleModelDomainModel>> GetAllAsync()
        {
            //return await genRep.GetAllAsync<IVehicleModelDomainModel>();
            return Mapper.Map<IEnumerable<IVehicleModelDomainModel>>(await genRep.GetAllAsync<VehicleMake>());
        }

        public async Task<IVehicleModelDomainModel> GetAsync(Guid id)
        {
            //return await genRep.GetAsync<IVehicleModelDomainModel>(id);
            return Mapper.Map<IVehicleModelDomainModel>(await genRep.GetAsync<VehicleMake>(id));
        }

        public async Task<int> UpdateAsync(IVehicleModelDomainModel entity)
        {
            //return await genRep.AddAsync(Mapper.Map<VehicleMake>(entity));
            return await genRep.UpdateAsync(Mapper.Map<VehicleMake>(entity));
        }
    }
}
