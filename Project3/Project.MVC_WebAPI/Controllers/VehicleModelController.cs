using AutoMapper;
using Project.DAL.Models;
using Project.Model;
using Project.MVC_WebAPI.ViewModels;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ninject;
using Ninject.Syntax;
using Project.Service;
using Project.Repository;
using Project.Model.Common;
using Project.Common;

namespace Project.MVC_WebAPI.Controllers
{
    [RoutePrefix("api/vehicle-model")]
    public class VehicleModelController : ApiController
    {

        private IVehicleModelService vehicleModelService;
        public VehicleModelController(IVehicleModelService cont)
        {
            this.vehicleModelService = cont;
        }
        //GET: api/VehicleModel
        [HttpGet]
        [Route("get-model")]
        public async Task<HttpResponseMessage> GetVehicleModels()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<VehicleModelViewModel>>(await vehicleModelService.GetAllAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get vehicle models.");
            }
        }

        [HttpPost]
        [Route("post-model")]
        public async Task<HttpResponseMessage> PostVehicleModels(VehicleModelDomainModel entity)
        {
            try
            {
                entity.VehicleModelId = Guid.NewGuid();
                var response = await vehicleModelService.AddAsync(Mapper.Map<IVehicleModelDomainModel>(entity));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't add vehicle model.");
            }
        }
        [HttpDelete]
        [Route("delete-model")]
        public async Task<HttpResponseMessage> DeleteVehicleModel(Guid id)
        {
            try
            {
                var response = await vehicleModelService.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't delete vehicle model.");
            }
        }
        [HttpPut]
        [Route("update-model")]
        public async Task<HttpResponseMessage> UpdateVehicleModel(VehicleModelViewModel entity)
        {
            try
            {
                var response = await vehicleModelService.UpdateAsync(Mapper.Map<IVehicleModelDomainModel>(entity));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't update vehicle model.");
            }
        }
        [HttpGet]
        [Route("get-single-model")]
        public async Task<HttpResponseMessage> GetSingleVehicleModel(Guid id)
        {
            try
            {
                var response = Mapper.Map<VehicleModelViewModel>(await vehicleModelService.GetAsync(id));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get this single vehicle model.");
            }
        }
        [HttpGet]
        [Route("sort-model")]
        public async Task<HttpResponseMessage> SortVehicleModel(int? page, string sortOrder, string searchString)
        {
            try
            {
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                Sorting sorting = new Sorting(sortOrder);
                Filtering filtering = new Filtering(searchString);
                Paging paging = new Paging(pageNumber, pageSize);
                var response = Mapper.Map<IEnumerable<VehicleModelViewModel>>(await vehicleModelService.SortModelAsync(sorting, filtering, paging));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't sort vehicle models.");
            }

        }
    }
}
