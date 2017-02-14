using AutoMapper;
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
    }
}
