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

namespace Project.MVC_WebAPI.Controllers
{
    [RoutePrefix("api/vehicle-model")]
    public class VehicleModelController : ApiController
    {

        private IVehicleModelService vmSer;
        public VehicleModelController(IVehicleModelService cont)
        {
            this.vmSer = cont;
        }
        //GET: api/VehicleModel
        [HttpGet]
        [Route("get-model")]
        public async Task<HttpResponseMessage> GetVehicleModels()
        {
            var response= Mapper.Map<IEnumerable<VehicleModelViewModel>>(await vmSer.GetAllAsync());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("post-model")]
        public async Task<HttpResponseMessage> PostVehicleModels(VehicleModelDomainModel entity)
        {
            try
            {
                entity.VehicleModelId = Guid.NewGuid();
                var response = await vmSer.AddAsync(Mapper.Map<IVehicleModelDomainModel>(entity));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't add vehicle model.");
            }
        }
        [HttpDelete]
        [Route("delete-model")]
        public async Task<HttpResponseMessage> DeleteVehicleModel(Guid id)
        {
            var response = await vmSer.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPut]
        [Route("update-model")]
        public async Task<HttpResponseMessage> UpdateVehicleModel(VehicleModelViewModel entity)
        {

            var response = await vmSer.UpdateAsync(Mapper.Map<IVehicleModelDomainModel>(entity));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("get-single-model")]
        public async Task<HttpResponseMessage> GetSingleVehicleModel(Guid id)
        {
            var response = Mapper.Map<VehicleModelViewModel>(await vmSer.GetAsync(id));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("sort-model")]
        public async Task<HttpResponseMessage> SortVehicleModel(int? page, string sortOrder, string searchString)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var response = Mapper.Map<IEnumerable<VehicleModelViewModel>>(await vmSer.SortModelAsync(pageNumber, pageSize, sortOrder, searchString));
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }
    }
}
