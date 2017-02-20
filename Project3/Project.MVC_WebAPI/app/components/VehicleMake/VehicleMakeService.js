//<reference path="C:\Users\umiljs\Documents\Visual Studio 2015\Projects\MONO_FINAL_BOSS\Project3\Project.MVC_WebAPI\Scripts/angular.min.js" />
var MyApp = angular.module('MyApp', []);
MyApp.factory('VehicleMakeService', ['$http', function ($http) { //myapp.factory funkcija koja vraca objekt

    var VehicleMakeService = {};
    VehicleMakeService.getVehicleMake = function () {
        return $http.get('http://localhost:59838/api/VehicleMake/GetVehMake');
    };
    return VehicleMakeService;
}]);