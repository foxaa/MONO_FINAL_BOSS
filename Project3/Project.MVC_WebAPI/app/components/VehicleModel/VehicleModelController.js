routerApp.controller('VehicleModelController', ['$scope', '$http', '$location', '$window', '$stateParams', VehicleModelController]);
function VehicleModelController($scope, $http, $location, $window, $stateParams) {

    $scope.close = function () {
        $location.path('/vehicle-model');
    }

    $scope.getMakers = function () {
        $http.get('/api/vehicle-make/get-make').then(function (response) {
            $scope.makers = response.data;  
        }, function (response) {
            $window.alert("Error: " + response.data.Message);
        });
    }
    
    $scope.add = function () {
        if ($scope.name == undefined || $scope.abrv == undefined || $scope.vehicleMakeId == undefined) {
            $window.alert("Please add all properties.");
        }
        else {
            var vehicleData = {
                VehicleMakeId: $scope.vehicleMakeId,
                Name: $scope.name,
                Abrv: $scope.abrv,
            };
            $http.post("api/vehicle-model/post-model", vehicleData)
                .then(function (response) {
                    $window.alert("Model added successfuly.");
                    $location.path('/vehicle-model');
                }, function (response) {
                    $window.alert("Error: " + response.data.Message);
                })
        }
    }
    $scope.delete = function () {
        var id = $stateParams.modelId;
        $http.delete("api/vehicle-model/delete-model?id=" + id)
            .then(function (response) {
                $window.alert("Model deleted successfuly.");
                $location.path('/vehicle-model');
            }, function (response) {
                $window.alert("Error:" + response.error);
                $location.path('/VehicleModel');
            }
            );
    }

    $scope.updateGetId = function () {
        var id = $stateParams.modelId;
        $http.get("api/vehicle-model/get-single-model?id=" + id)
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
        $http.put("api/vehicle-model/update-model", vehicleData)
         .then(function (response) {
             $window.alert("Model updated succesfuly.");
             $location.path('/vehicle-model');
         }, function (response) {
             $window.alert("Error:" + response.error);
             $location.path('/vehicle-model');
         }
         );
    }
    $scope.details = function () {
        var id = $stateParams.modelId;
        $http.get("api/vehicle-model/get-single-model?id=" + id)
            .then(function (response) {
                $scope.vehicleMakeId = response.data.VehicleMakeId;
                $scope.name = response.data.Name;
                $scope.abrv = response.data.Abrv;
            })
    }

    $scope.sortVehModel = function (page, sortOrder, searchString) {
        $scope.sortOrd = sortOrder;
        console.log(sortOrder);
        $http.get("api/vehicle-model/sort-model?page="+page+"&sortOrder="+sortOrder+"&searchString="+searchString)
            .then(function (response) {
                $scope.models = response.data;
                $location.path('/vehicle-model');               
            })
    }

}