
routerApp.controller('VehicleMakeController', ['$scope', '$http', '$location', '$window', '$stateParams', VehicleMakeController]);
function VehicleMakeController($scope, $http,$location, $window, $stateParams) {


    $scope.close = function () {
        $location.path('/vehicle-make');
    }
    $scope.add = function () {
        if ($scope.name == undefined || $scope.abrv == undefined) {
            $window.alert("Please enter all properties.");
        } else {
            var vehicleData = {
                Name: $scope.name,
                Abrv: $scope.abrv,
            };
            $http.post("api/vehicle-make/post-make", vehicleData)
                .then(function (response) {
                    $window.alert("Maker added successful.");
                    $location.path('/vehicle-make');
                }, function (response) {
                    $window.alert("Error: " + response.error);
                });
        }
    }
    $scope.delete = function () {
        
        var id = $stateParams.makeId;
        $http.delete("api/vehicle-make/delete-make?id=" + id)
            .then(function (response) {
                $window.alert("Maker deleted successfuly.");
                $location.path('/vehicle-make');
            }, function (response) {
                $window.alert("Error:" + response.error);
            }
            );
    }

    $scope.updateGetId = function () {
        var id= $stateParams.makeId;
        $http.get("api/vehicle-make/get-single-make?id=" +id)
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
        $http.put("api/vehicle-make/update-make",vehicleData)
        .then(function(response){
            $window.alert("Maker update successfull");
            $location.path('/vehicle-make');
        })
    }

    $scope.details= function () {
        var id = $stateParams.makeId;
        $http.get("api/vehicle-make/get-single-make?id=" + id)
            .then(function (response) {
                $scope.name = response.data.Name;
                $scope.abrv = response.data.Abrv;
            })
    }


    $scope.sortVehMake = function (page,sortOrder,searchString) {
        $scope.sortOrd = sortOrder;
        console.log(sortOrder);
        $http.get("api/vehicle-make/sort-make?page="+page+"&sortOrder="+sortOrder+"&searchString="+searchString)
            .then(function (response) {
                $scope.makers = response.data;
                $location.path('/vehicle-make');            
            })
    }
}