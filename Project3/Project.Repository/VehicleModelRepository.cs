using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Repository.Common;
using AutoMapper;
using Project.DAL.Models;
using PagedList;
using Project.Common;

namespace Project.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private IGenericRepository genericRepository;
        public VehicleModelRepository(IGenericRepository context)
        {
            genericRepository = context;
        }
        public async Task<int> AddAsync(IVehicleModelDomainModel entity)
        {
            return await genericRepository.AddAsync(Mapper.Map<VehicleModel>(entity));
        }

        public async Task<int> DeleteAllAsync(IEnumerable<IVehicleModelDomainModel> entity)
        {
            return await genericRepository.DeleteAllAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<VehicleModel>(id);
        }

        public async Task<IEnumerable<IVehicleModelDomainModel>> GetAllAsync()
        {
            var response = Mapper.Map<IEnumerable<IVehicleModelDomainModel>>(await genericRepository.GetAllAsync<VehicleModel>());
            return response;
        }

        public async Task<IVehicleModelDomainModel> GetAsync(Guid id)
        {
            return Mapper.Map<IVehicleModelDomainModel>(await genericRepository.GetAsync<VehicleModel>(id));
        }

        public async Task<IPagedList<IVehicleModelDomainModel>> SortModelAsync(Sorting sorting, Filtering filtering, Paging paging)
        {
            IEnumerable<IVehicleModelDomainModel> modelEntities;
            if (string.IsNullOrWhiteSpace(filtering.SearchParam) || filtering.SearchParam == "undefined")
            {
                modelEntities = Mapper.Map<IEnumerable<IVehicleModelDomainModel>>(await genericRepository.GetAllAsync<VehicleModel>());
            }
            else
                modelEntities = Mapper.Map<IEnumerable<IVehicleModelDomainModel>>(await genericRepository.GetAllAsync<VehicleModel>()).Where(vm => vm.Name.Contains(filtering.SearchParam));

            switch (sorting.SortOrder)
            {
                case "MakeName_desc":
                    modelEntities = modelEntities.OrderByDescending(v => v.VehicleMake.Name);
                    break;
                case "MakeName_asc":
                    modelEntities = modelEntities.OrderBy(v => v.VehicleMake.Name);
                    break;
                case "MakeAbrv_desc":
                    modelEntities = modelEntities.OrderByDescending(v => v.VehicleMake.Abrv);
                    break;
                case "MakeAbrv_asc":
                    modelEntities = modelEntities.OrderBy(v => v.VehicleMake.Abrv);
                    break;
                case "Name_desc":
                    modelEntities = modelEntities.OrderByDescending(v => v.Name);
                    break;
                case "Abrv_desc":
                    modelEntities = modelEntities.OrderByDescending(v => v.Abrv);
                    break;

                case "Abrv":
                    modelEntities = modelEntities.OrderBy(v => v.Abrv);
                    break;

                default:
                    modelEntities = modelEntities.OrderBy(v => v.Name);
                    break;


            }
            return modelEntities.ToPagedList(paging.PageNumber, paging.PageSize);
        }

        public async Task<int> UpdateAsync(IVehicleModelDomainModel entity)
        {
            return await genericRepository.UpdateAsync(Mapper.Map<VehicleModel>(entity));
        }
    }
}
