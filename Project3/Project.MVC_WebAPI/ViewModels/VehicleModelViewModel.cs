using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.DAL.Models;

namespace Project.MVC_WebAPI.ViewModels
{
    public class VehicleModelViewModel
    {

        public Guid VehicleModelId { get; set; }
        public Guid VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual VehicleMakeViewModel VehicleMake { get; set; }
    }
}