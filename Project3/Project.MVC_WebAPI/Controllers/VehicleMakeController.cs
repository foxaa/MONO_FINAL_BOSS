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
using Project.Common;
using PagedList;

namespace Project.MVC_WebAPI.Controllers
{
    [RoutePrefix("api/vehicle-make")]
    public class VehicleMakeController : ApiController
    {
        private IVehicleMakeService vehicleMakeService;
        public VehicleMakeController(IVehicleMakeService cont)
        {
            this.vehicleMakeService = cont;
        }
        //GET: api/VehicleModel
        [HttpGet]
        [Route("get-make")]
        public async Task<HttpResponseMessage> GetVehicleMake()
        {
            try
            {
                var response = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(await vehicleMakeService.GetAllAsync());
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get vehicle makers.");
            }
        }
        [HttpPost]
        [Route("post-make")]
        public async Task<HttpResponseMessage> PostVehicleMake(VehicleMakeViewModel entity)
        {
            try
            {
                entity.id = Guid.NewGuid();
                var create = await vehicleMakeService.AddAsync(Mapper.Map<IVehicleMakeDomainModel>(entity));
                return Request.CreateResponse(HttpStatusCode.OK, create);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't add vehicle maker.");
            }
        }
        [HttpDelete]
        [Route("delete-make")]
        public async Task<HttpResponseMessage> DeleteVehicleMake(Guid id)
        {
            try
            {
                var response = await vehicleMakeService.DeleteAsync(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't delete vehicle maker.");
            }
        }
        [HttpPut]
        [Route("update-make")]
        public async Task<HttpResponseMessage> UpdateVehicleMake(VehicleMakeViewModel entity)
        {
            try
            {
                var response = await vehicleMakeService.UpdateAsync(Mapper.Map<IVehicleMakeDomainModel>(entity));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't update vehicle maker.");
            }
        }
        [HttpGet]
        [Route("get-single-make")]
        public async Task<HttpResponseMessage> GetSingleVehicleMake(Guid id)
        {
            try
            {
                var response = Mapper.Map<VehicleMakeViewModel>(await vehicleMakeService.GetAsync(id));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't get this single vehicle maker.");
            }

        }
        [HttpGet]
        [Route("sort-make")]
        public async Task<HttpResponseMessage> SortVehicleMake(int? page, string sortOrder, string searchString)
        {
            try
            {
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                Sorting sorting = new Sorting(sortOrder);
                Filtering filtering = new Filtering(searchString);
                Paging paging = new Paging(pageNumber, pageSize);
                var response = Mapper.Map<IEnumerable<VehicleMakeViewModel>>(await vehicleMakeService.SortMakeAsync(sorting, filtering, paging));
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Couldn't sort vehicle makers.");
            }

        }
    }
}
