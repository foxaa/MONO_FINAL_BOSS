using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.DAL.Models;


namespace Project.MVC_WebAPI.ViewModels
{
    public class VehicleMakeViewModel
    {
        
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<VehicleModelViewModel> VehicleModels { get; set; }
    }
}
