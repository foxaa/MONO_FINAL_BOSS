routerApp.controller('VehicleModelController', ['$scope', '$http', '$location', '$window', '$stateParams', VehicleModelController]);
function VehicleModelController($scope, $http, $location, $window, $stateParams) {
    $http.get('/api/VehicleModel/GetVehMod').then(function (response) {
        $scope.models = response.data;  //ajax request to fetch data into $scope.data
    });
    $scope.Close = function () {
        $location.path('/VehicleModel');
    }

    $scope.getMakers = function () {
        $http.get('/api/VehicleMake/GetVehMake').then(function (response) {
            $scope.makers = response.data;  //ajax request to fetch data into $scope.data
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
                    $window.alert("Model added successful.");
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
}