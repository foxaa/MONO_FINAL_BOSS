//routerApp.controller('listdata', function ($scope, $http) {
//    //$scope.users = []; //declare an empty array
//    $http.get('/api/VehicleMake/GetVehMake').then(function (response) {
//        $scope.users = response.data;  //ajax request to fetch data into $scope.data
//    });
//});
routerApp.controller('VehicleMakeController', ['$scope', '$http', '$location', '$window', '$stateParams', VehicleMakeController]);
function VehicleMakeController($scope, $http,$location, $window, $stateParams) {

    $http.get('/api/VehicleMake/GetVehMake').then(function (response) {
        $scope.users = response.data;  //ajax request to fetch data into $scope.data
    });

    $scope.Close = function () {
        $location.path('/VehicleMake');
    }
    $scope.Add = function () {
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
}