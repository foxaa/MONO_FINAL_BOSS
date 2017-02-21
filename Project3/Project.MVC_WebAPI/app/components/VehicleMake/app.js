
routerApp.controller('listdata', function ($scope, $http) {
    $scope.users = []; //declare an empty array
    $http.get('/api/VehicleMake/GetVehMake').then(function (response) {
        $scope.users = response.data;  //ajax request to fetch data into $scope.data
    });


});
