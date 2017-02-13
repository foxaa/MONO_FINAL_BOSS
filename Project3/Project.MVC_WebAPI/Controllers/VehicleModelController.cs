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


    }
}
