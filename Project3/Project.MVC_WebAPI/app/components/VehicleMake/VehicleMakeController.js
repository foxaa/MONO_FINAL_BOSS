/// <reference path="C:\Users\umiljs\Documents\Visual Studio 2015\Projects\MONO_FINAL_BOSS\Project3\Project.MVC_WebAPI\Scripts/angularmin.js" />
var MyApp= angular.module('MyApp', []);
MyApp.controller('VehicleMakeController', function ($scope, VehicleMakeService) {
    
    getVehicleMake();

    function getVehicleMake() {
        VehicleMakeService.getVehicleMake()
            .success(function (makes) {
                $scope.makes = makes;
            
            })
            .error(function (error) {
                $scope.status = 'Unable to load VehicleMake data: ' + error.message;

            });
    }
});
