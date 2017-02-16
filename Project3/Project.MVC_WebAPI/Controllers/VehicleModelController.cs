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
    [RoutePrefix("api/VehicleModel")]
    public class VehicleModelController : ApiController
    {

        private IVehicleModelService vmSer;
        //private VehicleModelController() { }
        public VehicleModelController(IVehicleModelService cont)
        {
            this.vmSer = cont;
        }
        //GET: api/VehicleModel
        [HttpGet]
        [Route("GetVehMod")]
        public async Task<HttpResponseMessage> GetVehicleModels()
        {
            var nesto = Mapper.Map<IEnumerable<VehicleModelViewModel>>(await vmSer.GetAllAsync());
            return Request.CreateResponse(HttpStatusCode.OK, nesto);
        }

        [HttpPost]
        [Route("PostVehModel")]
        public async Task<HttpResponseMessage> PostVehicleModels(VehicleModelDomainModel entity)
        {
            entity.VehicleModelId = Guid.NewGuid();
            var response = await vmSer.AddAsync(Mapper.Map<IVehicleModelDomainModel>(entity));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpDelete]
        [Route("DeleteVehModel")]
        public async Task<HttpResponseMessage> DeleteVehicleModel(Guid id)
        {
            var response = await vmSer.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPut]
        [Route("UpdateVehModel")]
        public async Task<HttpResponseMessage> UpdateVehicleModel(VehicleModelViewModel entity)
        {
            //var response = await vmSer.UpdateAsync(entity);

            var response = await vmSer.UpdateAsync(Mapper.Map<IVehicleModelDomainModel>(entity));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        [Route("GetSingleVehModel")]
        public async Task<HttpResponseMessage> GetSingleVehicleModel(Guid id)
        {
            var response = Mapper.Map<VehicleModelViewModel>(await vmSer.GetAsync(id));
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


    }
}
