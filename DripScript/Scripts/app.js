var app = angular.module("drip", []);

app.controller("TestController", ["$scope", "$http", function ($scope, $http) {
    $scope.delete = function() {
        $scope.deleteUsers = function () {
        $http.delete("/api/DripScriptAPI")
            .success(function (data) {
                alert("Deleting Users Yay!");
            })
            .error(function (error) { alert(error.error) });
        }
    }

    $scope.create = function () {
        $scope.createEntry = function () {
            $http.post("api/DripScriptAPI")
                .success(function (data) {
                    alert("added journal entry Yay!");
                })
                .error(function (error) { alert(error.error) });
        }
    }
}]);