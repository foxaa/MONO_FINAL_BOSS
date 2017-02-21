var routerApp = angular.module('routerApp', ['ui.router']);
routerApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/VehicleMake');

    $stateProvider
        .state('GetVehMake', {
            url: '/VehicleMake',
            views: {
                "root": {
                    templateUrl: 'app/components/VehicleMake/index.html'
                }
            }
        })
});