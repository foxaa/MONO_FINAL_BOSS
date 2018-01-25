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
using Project.Common;

namespace Project.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private IGenericRepository genericRepository;
        public VehicleMakeRepository(IGenericRepository context)
        {
            genericRepository = context;
        }

        public async Task<int> AddAsync(IVehicleMakeDomainModel entity)
        {
            return await genericRepository.AddAsync(Mapper.Map<VehicleMake>(entity));
        }


        public async Task<int> DeleteAllAsync(IEnumerable<IVehicleMakeDomainModel> entity)
        {
            return await genericRepository.DeleteAllAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleMake>(id);
        }
        public async Task<IEnumerable<IVehicleMakeDomainModel>> GetAllAsync()
        {

            var response = Mapper.Map<IEnumerable<IVehicleMakeDomainModel>>(await genericRepository.GetAllAsync<VehicleMake>());
            return response;
        }

        public async Task<IVehicleMakeDomainModel> GetAsync(Guid id)
        {
            return Mapper.Map<IVehicleMakeDomainModel>(await genericRepository.GetAsync<VehicleMake>(id));
        }

        public async Task<IPagedList<IVehicleMakeDomainModel>> SortMakeAsync(Sorting sorting, Filtering filtering, Paging paging)
        {
            IEnumerable<IVehicleMakeDomainModel> makeEntities;
            if (string.IsNullOrWhiteSpace(filtering.SearchParam) || filtering.SearchParam == "undefined")
            {
                makeEntities = Mapper.Map<IEnumerable<IVehicleMakeDomainModel>>(await genericRepository.GetAllAsync<VehicleMake>());
            }
            else
                makeEntities = Mapper.Map<IEnumerable<IVehicleMakeDomainModel>>(await genericRepository.GetAllAsync<VehicleMake>()).Where(vm => vm.Name.Contains(filtering.SearchParam));

            switch (sorting.SortOrder)
            {
                case "Name_desc":
                    makeEntities = makeEntities.OrderByDescending(v => v.Name);
                    break;
                case "Abrv_desc":
                    makeEntities = makeEntities.OrderByDescending(v => v.Abrv);
                    break;
                case "Abrv":
                    makeEntities = makeEntities.OrderBy(v => v.Abrv);
                    break;
                default:
                    makeEntities = makeEntities.OrderBy(v => v.Name);
                    break;

            }
            return makeEntities.ToPagedList(paging.PageNumber, paging.PageSize);

        }

        public async Task<int> UpdateAsync(IVehicleMakeDomainModel entity)
        {
            return await genericRepository.UpdateAsync(Mapper.Map<VehicleMake>(entity));
        }

    }
}
