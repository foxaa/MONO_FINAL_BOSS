
routerApp.controller('VehicleMakeController', ['$scope', '$http', '$location', '$window', '$stateParams', VehicleMakeController]);
function VehicleMakeController($scope, $http,$location, $window, $stateParams) {

    $http.get('/api/VehicleMake/GetVehMake').then(function (response) {
        $scope.makers = response.data;  
    });

    $scope.Close = function () {
        $location.path('/VehicleMake');
    }
    $scope.Add = function () {
        if ($scope.Name == undefined || $scope.Abrv == undefined) {
            $window.alert("Please enter all properties.");
        } else {
            var vehicleData = {
                Name: $scope.Name,
                Abrv: $scope.Abrv,
            };
            $http.post("api/VehicleMake/PostVehMake", vehicleData)
                .then(function (response) {
                    $window.alert("Maker added successful.");
                    $location.path('/VehicleMake');
                }, function (response) {
                    $window.alert("Error: " + response.error);
                });
        }
    }
    $scope.Delete = function () {
        
        var id = $stateParams.makeId;
        $http.delete("api/VehicleMake/DeleteVehMake?id=" + id)
            .then(function (response) {
                $window.alert("Maker deleted successfuly.");
                $location.path('/VehicleMake');
            }, function (response) {
                $window.alert("Error:" + response.error);
            }
            );
    }

    $scope.UpdateGetId = function () {
        var id= $stateParams.makeId;
        $http.get("api/VehicleMake/GetSingleVehMake?id=" +id)
            .then(function (response) {
                $scope.Name = response.data.Name;
                $scope.Abrv = response.data.Abrv;
            })
    }

    $scope.Update = function () {
        var vehicleData = {
            Id: $stateParams.makeId,
            Name: $scope.Name,
            Abrv: $scope.Abrv,
        };
        $http.put("api/VehicleMake/UpdateVehMake",vehicleData)
        .then(function(response){
            $window.alert("Maker update successfull");
            $location.path('/VehicleMake');
        })
    }

    $scope.Details= function () {
        var id = $stateParams.makeId;
        $http.get("api/VehicleMake/GetSingleVehMake?id=" + id)
            .then(function (response) {
                $scope.Name = response.data.Name;
                $scope.Abrv = response.data.Abrv;
            })
    }

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname;   //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    }
}