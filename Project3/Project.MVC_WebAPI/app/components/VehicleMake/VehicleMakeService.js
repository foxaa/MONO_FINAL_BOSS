routerApp.service('vehicleMakeService', ['$http', function ($http) {

    this.add = function (vehicleData) {
        return $http.post("api/vehicle-make", vehicleData);
    };

    this.delete = function (id) {
        return $http.delete("api/vehicle-make?id=" + id);
    };

    this.updateGetId = function (id) {
        return $http.get("api/vehicle-make?id=" + id);
    };

    this.update = function (vehicleData) {
        return $http.put("api/vehicle-make", vehicleData);
    };

    this.details = function (id) {
        return $http.get("api/vehicle-make?id=" + id);
    };

    this.sortVehMake = function (page, sortOrder, searchString) {
        return $http.get("api/vehicle-make/sort?page=" + page + "&sortOrder=" + sortOrder + "&searchString=" + searchString);
    };

}]);