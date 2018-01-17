using AutoMapper;
using Project.Model;
using Project.Model.Common;
using Project.MVC_WebAPI.ViewModels;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.MVC_WebAPI.Controllers
{
    [RoutePrefix("api/vehicle-make")]
    public class VehicleMakeController : ApiController
    {
        private IVehicleMakeService vmSer;
        public VehicleMakeController(IVehicleMakeService cont)
        {
            this.vmSer = cont;
        }
        //GET: api/VehicleModel
        [HttpGet]
        [Route("get-make")]
        public async Task<HttpResponseMessage> GetVehicleMake()
        {
            var response = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(await vmSer.GetAllAsync());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        [Route("post-make")]
        public async Task<HttpResponseMessage> PostVehicleMake(VehicleMakeViewModel entity)
        {
            entity.id = Guid.NewGuid();

            var create = await vmSer.AddAsync(Mapper.Map<IVehicleMakeDomainModel>(entity));
            return Request.CreateResponse(HttpStatusCode.OK, create);
        }
        [HttpDelete]
        [Route("delete-make")]
        public async Task<HttpResponseMessage> DeleteVehicleMake(Guid id)
        {
            var response = await vmSer.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPut]
        [Route("update-make")]
        public async Task<HttpResponseMessage> UpdateVehicleMake(VehicleMakeViewModel entity)
        {
            
            var response = await vmSer.UpdateAsync(Mapper.Map<IVehicleMakeDomainModel>(entity));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("get-single-make")]
        public async Task<HttpResponseMessage> GetSingleVehicleMake(Guid id)
        {
            var response = Mapper.Map<VehicleMakeViewModel>(await vmSer.GetAsync(id));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("sort-make")]
        public async Task<HttpResponseMessage> SortVehicleMake(int? page,string sortOrder,string searchString)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var response = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(await vmSer.SortMakeAsync(pageNumber, pageSize,sortOrder,searchString));
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }
    }
}
