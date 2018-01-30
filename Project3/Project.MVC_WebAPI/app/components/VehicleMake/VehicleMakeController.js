
routerApp.controller('VehicleMakeController', ['$scope', '$http', '$location', '$window', '$stateParams','vehicleMakeService', VehicleMakeController]);
function VehicleMakeController($scope, $http, $location, $window, $stateParams,vehicleMakeService) {


    $scope.close = function () {
        $location.path('/vehicle-make');
    }
    $scope.add = function () {
        if ($scope.name == undefined || $scope.abrv == undefined) {
            $scope.alertType = 'alert-warning';
            $scope.alertMsg = 'Please enter all properties.';
        } else {
            var vehicleData = {
                Name: $scope.name,
                Abrv: $scope.abrv,
            };
            vehicleMakeService.add(vehicleData)
                .then(function (response) {
                    $scope.alertType = 'alert-success';
                    $scope.alertMsg = 'Vehicle make added.';
                   //$location.path('/vehicle-make');
                }, function (response) {
                    $scope.alertType = 'alert-danger';
                    $scope.alertMsg = 'Error when adding vehicle make.';
                });
        }
    }
    $scope.delete = function () {

        var id = $stateParams.makeId;
        vehicleMakeService.delete(id)
            .then(function (response) {
                $scope.alertType = 'alert-success';
                $scope.alertMsg = 'Vehicle maker deleted.';
            }, function (response) {
                $scope.alertType = 'alert-warning';
                $scope.alertMsg = 'Error when trying to delete vehicle maker.';
            }
            );
    }

    $scope.updateGetId = function () {
        var id = $stateParams.makeId;
        vehicleMakeService.updateGetId(id)
            .then(function (response) {
                $scope.name = response.data.Name;
                $scope.abrv = response.data.Abrv;
            })
    }

    $scope.update = function () {
        var vehicleData = {
            Id: $stateParams.makeId,
            Name: $scope.name,
            Abrv: $scope.abrv,
        };
        vehicleMakeService.update(vehicleData)
        .then(function (response) {
            $scope.alertType = 'alert-success';
            $scope.alertMsg = 'Vehicle maker updated.';
            
        })
    }

    $scope.details = function () {
        var id = $stateParams.makeId;
        vehicleMakeService.details(id)
            .then(function (response) {
                $scope.name = response.data.Name;
                $scope.abrv = response.data.Abrv;
            })
    }


    $scope.sortVehMake = function (page, sortOrder, searchString) {
        $scope.sortOrd = sortOrder;
        console.log(sortOrder);
        vehicleMakeService.sortVehMake(page,sortOrder,searchString)
            .then(function (response) {
                $scope.makers = response.data;
                $location.path('/vehicle-make');
            })
    }
}