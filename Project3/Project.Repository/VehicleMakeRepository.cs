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
using System.Data.Entity;
using PagedList;

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
            return await genRep.DeleteAsync<VehicleMake>(id);
        }
        public async Task<IEnumerable<IVehicleMakeDomainModel>> GetAllAsync()
        {         

            var response = Mapper.Map<IEnumerable<IVehicleMakeDomainModel>>(await genRep.GetAllAsync<VehicleMake>());
            return response;
        }

        public async Task<IVehicleMakeDomainModel> GetAsync(Guid id)
        {
            return Mapper.Map<IVehicleMakeDomainModel>(await genRep.GetAsync<VehicleMake>(id));
        }

        public async Task<IEnumerable<IVehicleMakeDomainModel>> SortMakeAsync(int pageNumber, int pageSize,string sortOrder,string searchString)
        {
            IEnumerable<IVehicleMakeDomainModel> makeEntities;
            if (string.IsNullOrWhiteSpace(searchString) || searchString=="undefined")
            {
                makeEntities= Mapper.Map<IEnumerable<IVehicleMakeDomainModel>>(await genRep.GetAllAsync<VehicleMake>());
            }
            else
                makeEntities= Mapper.Map<IEnumerable<IVehicleMakeDomainModel>>(await genRep.GetAllAsync<VehicleMake>()).Where(vm => vm.Name.Contains(searchString));

            switch (sortOrder)
            {
                case "Name_desc":
                    makeEntities=makeEntities.OrderByDescending(v => v.Name);
                    break;
                case "Abrv_desc":
                    makeEntities= makeEntities.OrderByDescending(v => v.Abrv);
                    break;
                case "Abrv":
                    makeEntities= makeEntities.OrderBy(v => v.Abrv);
                    break;
                default:
                    makeEntities= makeEntities.OrderBy(v => v.Name);
                    break;

            }
            return makeEntities.ToPagedList(pageNumber, pageSize);
            
        }

        public async Task<int> UpdateAsync(IVehicleMakeDomainModel entity)
        {
            return await genRep.UpdateAsync(Mapper.Map<VehicleMake>(entity));
        }

    }
}
