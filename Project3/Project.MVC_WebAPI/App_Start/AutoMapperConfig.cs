using AutoMapper;
using Project.DAL.Models;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVC_WebAPI.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<VehicleMake, VehicleMakeDomainModel>().ReverseMap();
                config.CreateMap<VehicleModel, VehicleModelDomainModel>().ReverseMap();
            });
        }
    }
}