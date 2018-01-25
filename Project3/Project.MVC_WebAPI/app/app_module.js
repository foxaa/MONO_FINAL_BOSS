var routerApp = angular.module('routerApp', ['ui.router', 'angularUtils.directives.dirPagination']);
routerApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/vehicle-make');

    $stateProvider
        .state('VehMake', {
            url: '/vehicle-make',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleMake/index.html'
                }
            }
        })
        .state('PostVehMake', {
            url: '/vehicle-make/add',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleMake/AddVehicleMake.html'
                }
            }
        })
        .state('VehModel', {
            url: '/vehicle-model',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleModel/VehicleModelView.html'
                }
            }
        })
        .state('PostVehModel', {
            url: '/vehicle-model/add',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleModel/AddVehicleModel.html'
                }
            }
        })
        .state('DeleteVehMake', {
            url: '/vehicle-make/delete?makeId',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleMake/DeleteVehicleMake.html'
                }
            }
        })
        .state('DeleteVehModel', {
            url: '/vehicle-model/delete?modelId',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleModel/DeleteVehicleModel.html'
                }
            }
        })
        .state('UpdateVehMake', {
            url: '/vehicle-make/update?makeId',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleMake/UpdateVehicleMake.html'
                }
            }
        })
        .state('UpdateVehModel', {
            url: '/vehicle-model/update?modelId',
            views: {
                "root": {
                    templateUrl: '/app/components/VehicleModel/UpdateVehicleModel.html'
                }
            }
        })
        .state('DetailsVehMake', {
            url: '/vehicle-make/details?makeId',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleMake/DetailsVehicleMake.html'
                }
            }
        })
        .state('DetailsVehModel', {
            url: '/vehicle-model/details?modelId',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleModel/DetailsVehicleModel.html'
                }
            }
        })
});