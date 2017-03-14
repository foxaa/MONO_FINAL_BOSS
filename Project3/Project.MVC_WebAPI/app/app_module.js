var routerApp = angular.module('routerApp', ['ui.router','angularUtils.directives.dirPagination']);
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
        .state('VehModel', {
            url:'/VehicleModel',
            views:{
                "root":{
                    templateUrl:'app/components/VehicleModel/VehicleModelView.html'
                }
            }
        })
        .state('PostVehModel', {
            url: '/AddVehicleModel',
            views: {
                "root": {
                    templateUrl:'app/components/VehicleModel/AddVehicleModel.html'
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
        .state('DeleteVehModel', {
            url: '/DeleteVehModel?modelId',
            views:{
                "root":{
                    templateUrl:'app/components/VehicleModel/DeleteVehicleModel.html'
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
        .state('UpdateVehModel', {
            url: '/UpdateVehModel?modelId',
            views: {
                "root": {
                    templateUrl:'/app/components/VehicleModel/UpdateVehicleModel.html'
                }
            }
        })
        .state('DetailsVehMake', {
            url: '/DetailsVehMake?makeId',
            views: {
                "root": {
                    templateUrl:'app/components/VehicleMake/DetailsVehicleMake.html'
                }
            }
        })
        .state('DetailsVehModel', {
            url: '/DetailsVehModel?modelId',
            views: {
                "root": {
                    templateUrl:'app/components/VehicleModel/DetailsVehicleModel.html'
                }
            }
        })
});