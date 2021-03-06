﻿using System.Web;
using System.Web.Optimization;

namespace Project.MVC_WebAPI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-ui-router.js"));
            bundles.Add(new ScriptBundle("~/bundles/vehicleApp").Include(
                      "~/app/app_module.js",
                       "~/app/components/VehicleMake/VehicleMakeController.js",
                       "~/app/components/VehicleModel/VehicleModelController.js",
                       "~/app/components/VehicleMake/VehicleMakeService.js",
                       "~/app/components/VehicleModel/VehicleModelService.js",
                       "~/app/components/pagination/dirPagination.js"



    ));
        }
    }
}
