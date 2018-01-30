routerApp.controller('VehicleModelController', ['$scope', '$http', '$location', '$window', '$stateParams','vehicleModelService', VehicleModelController]);
function VehicleModelController($scope, $http, $location, $window, $stateParams,vehicleModelService) {

    $scope.close = function () {
        $location.path('/vehicle-model');
    }

    $scope.getMakers = function () {
        vehicleModelService.getMakers()
        .then(function (response) {
            $scope.makers = response.data;  
        }, function (response) {
            $scope.alertType = 'alert-danger';
            $scope.alertMsg = 'Error when fetching vehicle makers.';
        });
    }
    
    $scope.add = function () {
        if ($scope.name == undefined || $scope.abrv == undefined || $scope.vehicleMakeId == undefined) {
            $scope.alertType = 'alert-warning';
            $scope.alertMsg = 'Please enter all properties.';
        }
        else {
            var vehicleData = {
                VehicleMakeId: $scope.vehicleMakeId,
                Name: $scope.name,
                Abrv: $scope.abrv,
            };
            vehicleModelService.add(vehicleData)
                .then(function (response) {
                    $scope.alertType = 'alert-success';
                    $scope.alertMsg = 'Vehicle model added.';
                }, function (response) {
                    $scope.alertType = 'alert-error';
                    $scope.alertMsg = 'Error when adding vehicle model.';
                })
        }
    }
    $scope.delete = function () {
        var id = $stateParams.modelId;
        vehicleModelService.delete(id)
            .then(function (response) {
                $scope.alertType = 'alert-success';
                $scope.alertMsg = 'Vehicle model deleted.';
            }, function (response) {
                $scope.alertType = 'alert-error';
                $scope.alertMsg = 'Error when deleting vehicle model.';
            }
            );
    }

    $scope.updateGetId = function () {
        var id = $stateParams.modelId;
        vehicleModelService.updateGetId(id)
            .then(function(response)
            {
                $scope.vehicleMakeId=response.data.VehicleMakeId;
                $scope.name = response.data.Name;
                $scope.abrv = response.data.Abrv;
            })
    }
    $scope.update = function () {
        var vehicleData = {
            VehicleModelId: $stateParams.modelId,
            VehicleMakeId:  $scope.vehicleMakeId,
            Name: $scope.name,
            Abrv: $scope.abrv,
        };
        vehicleModelService.update(vehicleData)
         .then(function (response) {
             $scope.alertType = 'alert-success';
             $scope.alertMsg = 'Vehicle model updated.';
         }, function (response) {
             $scope.alertType = 'alert-error';
             $scope.alertMsg = 'Error when updating vehicle model.';
         }
         );
    }
    $scope.details = function () {
        var id = $stateParams.modelId;
        vehicleModelService.details(id)
            .then(function (response) {
                $scope.vehicleMakeId = response.data.VehicleMakeId;
                $scope.name = response.data.Name;
                $scope.abrv = response.data.Abrv;
            })
    }

    $scope.sortVehModel = function (page, sortOrder, searchString) {
        $scope.sortOrd = sortOrder;
        console.log(sortOrder);
        vehicleModelService.sortVehModel(page,sortOrder,searchString)
            .then(function (response) {
                $scope.models = response.data;
                $location.path('/vehicle-model');               
            })
    }

}