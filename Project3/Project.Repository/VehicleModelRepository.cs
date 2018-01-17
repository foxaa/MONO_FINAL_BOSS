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
            return await genRep.AddAsync(Mapper.Map<VehicleModel>(entity));
        }

        public async Task<int> DeleteAllAsync(IEnumerable<IVehicleModelDomainModel> entity)
        {
            return await genRep.DeleteAllAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genRep.DeleteAsync<VehicleModel>(id);
        }

        public async Task<IEnumerable<IVehicleModelDomainModel>> GetAllAsync()
        {
            var response = Mapper.Map<IEnumerable<IVehicleModelDomainModel>>(await genRep.GetAllAsync<VehicleModel>());
            return response;
        }

        public async Task<IVehicleModelDomainModel> GetAsync(Guid id)
        {
            return Mapper.Map<IVehicleModelDomainModel>(await genRep.GetAsync<VehicleModel>(id));
        }

        public async Task<IEnumerable<IVehicleModelDomainModel>> SortModelAsync(int pageNumber, int pageSize, string sortOrder, string searchString)
        {
            IEnumerable<IVehicleModelDomainModel> modelEntities;
            if (string.IsNullOrWhiteSpace(searchString) || searchString == "undefined")
            {
                modelEntities = Mapper.Map<IEnumerable<IVehicleModelDomainModel>>(await genRep.GetAllAsync<VehicleModel>());
            }
            else
                modelEntities = Mapper.Map<IEnumerable<IVehicleModelDomainModel>>(await genRep.GetAllAsync<VehicleModel>()).Where(vm => vm.Name.Contains(searchString));

            switch (sortOrder)
            {
                case "MakeName_desc":
                    modelEntities= modelEntities.OrderByDescending(v => v.VehicleMake.Name);
                    break;
                case "MakeName_asc":
                    modelEntities= modelEntities.OrderBy(v => v.VehicleMake.Name);
                    break;
                case "MakeAbrv_desc":
                    modelEntities= modelEntities.OrderByDescending(v => v.VehicleMake.Abrv);
                    break;
                case "MakeAbrv_asc":
                    modelEntities= modelEntities.OrderBy(v => v.VehicleMake.Abrv);
                    break;
                case "Name_desc":
                    modelEntities= modelEntities.OrderByDescending(v => v.Name);
                    break;
                case "Abrv_desc":
                    modelEntities= modelEntities.OrderByDescending(v => v.Abrv);
                    break;

                case "Abrv":
                    modelEntities= modelEntities.OrderBy(v => v.Abrv);
                    break;

                default:
                    modelEntities= modelEntities.OrderBy(v => v.Name);
                    break;


            }
            return modelEntities.ToPagedList(pageNumber, pageSize);
        }

        public async Task<int> UpdateAsync(IVehicleModelDomainModel entity)
        {
            return await genRep.UpdateAsync(Mapper.Map<VehicleModel>(entity));
        }
    }
}
