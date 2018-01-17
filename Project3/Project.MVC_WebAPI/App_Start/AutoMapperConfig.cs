using AutoMapper;
using Project.DAL.Models;
using Project.Model;
using Project.Model.Common;
using Project.MVC_WebAPI.ViewModels;
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
                config.CreateMap<VehicleMake, IVehicleMakeDomainModel>().ReverseMap();

                config.CreateMap<IVehicleMakeDomainModel, VehicleMakeViewModel>().ReverseMap();


                config.CreateMap<VehicleModel, VehicleModelDomainModel>().ReverseMap();
                config.CreateMap<VehicleModel, IVehicleModelDomainModel>().ReverseMap();

                config.CreateMap<IVehicleModelDomainModel, VehicleModelViewModel>().ReverseMap();
            });
        }
    }
}