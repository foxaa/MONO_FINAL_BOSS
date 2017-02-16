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
    [RoutePrefix("api/VehicleMake")]
    public class VehicleMakeController : ApiController
    {
        private IVehicleMakeService vmSer;
        //private VehicleModelController() { }
        public VehicleMakeController(IVehicleMakeService cont)
        {
            this.vmSer = cont;
        }
        //GET: api/VehicleModel
        [HttpGet]
        [Route("GetVehMake")]
        public async Task<HttpResponseMessage> GetVehicleMake()
        {
            var nesto = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(await vmSer.GetAllAsync());
            return Request.CreateResponse(HttpStatusCode.OK, nesto);
        }
        [HttpPost]
        [Route("PostVehMake")]
        public async Task<HttpResponseMessage> PostVehicleMake(VehicleMakeViewModel entity)
        {
            //var vehicleMake = new VehicleMakeViewModel();
            //if (entity.Name == null || entity.Abrv==null)
            //{
            //   return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid input, input=null");
            //}

            //vehicleMake.id = Guid.NewGuid();
            entity.id = Guid.NewGuid();

            var create = await vmSer.AddAsync(Mapper.Map<IVehicleMakeDomainModel>(entity));
            return Request.CreateResponse(HttpStatusCode.OK, create);
        }
        [HttpDelete]
        [Route("DeleteVehMake")]
        public async Task<HttpResponseMessage> DeleteVehicleMake(Guid id)
        {
            var response = await vmSer.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPut]
        [Route("UpdateVehMake")]
        public async Task<HttpResponseMessage> UpdateVehicleMake(VehicleMakeViewModel entity)
        {
            //var response = await vmSer.UpdateAsync(entity);
            
            var response = await vmSer.UpdateAsync(Mapper.Map<IVehicleMakeDomainModel>(entity));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("GetSingleVehMake")]
        public async Task<HttpResponseMessage> GetSingleVehicleMake(Guid id)
        {
            var response = Mapper.Map<VehicleMakeViewModel>(await vmSer.GetAsync(id));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
