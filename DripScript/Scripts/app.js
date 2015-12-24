var app = angular.model("drip", []);

app.controller("Controller", ["$scope", "$http", function ($scope, $http) {
    $scope.test = "test variable";

    $scope.deleteUsers = function () {
        $http.delete("/api/DripScriptAPI")
            .success(function (data) {
                alert("Deleting Users Yay!");
            })
            .error(function (error) { alert(error.error) });
    }

    $scope.hello = function () {
        $scope.test = "Hello World!"
    }
}]);