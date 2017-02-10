using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Project.DAL;
using Project.DAL.Models;
using Project.Service.Common;
using System.Threading.Tasks;
using AutoMapper;
using Project.Model.Common;
using Project.Model;

namespace Project.MVC_WebAPI.Controllers
{
    [RoutePrefix("api/VehicleModel")]
    public class VehicleModelController : ApiController
    {
        private IVehicleMakeService vmSer;
        public VehicleModelController(IVehicleMakeService cont)
        {
            vmSer = cont;
        }

        // GET: api/VehicleModel
        public async Task<HttpResponseMessage> GetVehicleModels()
        {
            var nesto=Mapper.Map<IEnumerable<VehicleModelDomainModel>>(await vmSer.GetAllAsync());
            return Request.CreateResponse(HttpStatusCode.OK, nesto);
        }

        //// GET: api/VehicleModel/5
        //[ResponseType(typeof(VehicleModel))]
        //public IHttpActionResult GetVehicleModel(Guid id)
        //{
        //    VehicleModel vehicleModel = db.VehicleModels.Find(id);
        //    if (vehicleModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(vehicleModel);
        //}

        //// PUT: api/VehicleModel/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutVehicleModel(Guid id, VehicleModel vehicleModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != vehicleModel.VehicleModelId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(vehicleModel).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VehicleModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/VehicleModel
        //[ResponseType(typeof(VehicleModel))]
        //public IHttpActionResult PostVehicleModel(VehicleModel vehicleModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.VehicleModels.Add(vehicleModel);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (VehicleModelExists(vehicleModel.VehicleModelId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = vehicleModel.VehicleModelId }, vehicleModel);
        //}

        //// DELETE: api/VehicleModel/5
        //[ResponseType(typeof(VehicleModel))]
        //public IHttpActionResult DeleteVehicleModel(Guid id)
        //{
        //    VehicleModel vehicleModel = db.VehicleModels.Find(id);
        //    if (vehicleModel == null)
        //    {
        //        return NotFound();
        //    }

        //    db.VehicleModels.Remove(vehicleModel);
        //    db.SaveChanges();

        //    return Ok(vehicleModel);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool VehicleModelExists(Guid id)
        //{
        //    return db.VehicleModels.Count(e => e.VehicleModelId == id) > 0;
        //}
    }
}