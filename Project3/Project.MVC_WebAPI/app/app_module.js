var routerApp = angular.module('routerApp', ['ui.router']);
routerApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/VehicleMake');

    $stateProvider
        .state('VehMake', {
            url: '/VehicleMake',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleMake/index.html'
                }
            }
        })
        .state('PostVehMake', {
            url: '/AddVehicleMake',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleMake/AddVehicleMake.html'
                }
            }
        })
        .state('DeleteVehMake', {
            url: '/DeleteVehMake?makeId',
            views: {
                "root": {
                    templateUrl:'app/components/VehicleMake/DeleteVehicleMake.html'
                }
            }
        })
        .state('UpdateVehMake', {
            url: '/UpdateVehMake?makeId',
            views: {
                "root": {
                    templateUrl:'app/components/VehicleMake/UpdateVehicleMake.html'
                }
            }
        })
});