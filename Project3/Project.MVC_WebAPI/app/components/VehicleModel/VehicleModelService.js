routerApp.service('vehicleModelService', ['$http', function ($http) {

    this.getMakers = function (vehicleData) {
        return $http.get("/api/vehicle-make");
    };

    this.add = function (vehicleData) {
        return $http.post("api/vehicle-model", vehicleData);
    };

    this.delete = function (id) {
        return $http.delete("api/vehicle-model?id=" + id);
    };

    this.updateGetId = function (id) {
        return $http.get("api/vehicle-model?id=" + id);
    };

    this.update = function (vehicleData) {
        return $http.put("api/vehicle-model", vehicleData);
    };

    this.details = function (id) {
        return $http.get("api/vehicle-model?id=" + id);
    };

    this.sortVehModel = function (page, sortOrder, searchString) {
        return $http.get("api/vehicle-model/sort?page=" + page + "&sortOrder=" + sortOrder + "&searchString=" + searchString);
    };

}]);