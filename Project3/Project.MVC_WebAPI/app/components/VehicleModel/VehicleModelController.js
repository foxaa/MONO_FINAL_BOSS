routerApp.controller('VehicleModelController', ['$scope', '$http', '$location', '$window', '$stateParams', VehicleModelController]);
function VehicleModelController($scope, $http, $location, $window, $stateParams) {
    $http.get('/api/VehicleModel/GetVehMod').then(function (response) {
        $scope.models = response.data;  
    });
    $scope.Close = function () {
        $location.path('/VehicleModel');
    }

    $scope.getMakers = function () {
        $http.get('/api/VehicleMake/GetVehMake').then(function (response) {
            $scope.makers = response.data;  
        }, function (response) {
            $window.alert("Error: " + response.data.Message);
        });
    }
    
    $scope.Add = function () {
        if ($scope.Name == undefined || $scope.Abrv == undefined || $scope.VehicleMakeId == undefined) {
            $window.alert("Please add all properties.");
        }
        else {
            var vehicleData = {
                VehicleMakeId: $scope.VehicleMakeId,
                Name: $scope.Name,
                Abrv: $scope.Abrv,
            };
            $http.post("api/VehicleModel/PostVehModel", vehicleData)
                .then(function (response) {
                    $window.alert("Model added successfuly.");
                    $location.path('/VehicleModel');
                }, function (response) {
                    $window.alert("Error: " + response.data.Message);
                })
        }
    }
    $scope.Delete = function () {
        var id = $stateParams.modelId;
        $http.delete("api/VehicleModel/DeleteVehModel?id=" + id)
            .then(function (response) {
                $window.alert("Model deleted successfuly.");
                $location.path('/VehicleModel');
            }, function (response) {
                $window.alert("Error:" + response.error);
                $location.path('/VehicleModel');
            }
            );
    }

    $scope.UpdateGetId = function () {
        var id = $stateParams.modelId;
        $http.get("api/VehicleModel/GetSingleVehModel?id=" + id)
            .then(function(response)
            {
                $scope.VehicleMakeId=response.data.VehicleMakeId;
                $scope.Name = response.data.Name;
                $scope.Abrv = response.data.Abrv;
            })
    }
    $scope.Update = function () {
        var vehicleData = {
            VehicleModelId: $stateParams.modelId,
            VehicleMakeId:  $scope.VehicleMakeId,
            Name: $scope.Name,
            Abrv: $scope.Abrv,
        };
        $http.put("api/VehicleModel/UpdateVehModel", vehicleData)
         .then(function (response) {
             $window.alert("Model updated succesfuly.");
             $location.path('/VehicleModel');
         }, function (response) {
             $window.alert("Error:" + response.error);
             $location.path('/VehicleModel');
         }
         );
    }
    $scope.Details = function () {
        var id = $stateParams.modelId;
        $http.get("api/VehicleModel/GetSingleVehModel?id=" + id)
            .then(function (response) {
                $scope.VehicleMakeId = response.data.VehicleMakeId;
                $scope.Name = response.data.Name;
                $scope.Abrv = response.data.Abrv;
            })
    }
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }
}