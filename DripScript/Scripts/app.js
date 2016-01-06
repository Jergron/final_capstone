var app = angular.module("drip", []);

app.controller("TestController", ["$scope", "$http", "$window", function ($scope, $http, $window) {

    $scope.word = "What?";

    $scope.test = function () {
        $http.get("/api/DripScriptAPI").success(function (data) {
            $scope.word = data;
            console.log("data", data);
            alert("Success!");
        }).error(function () {
            console.log("Nope, try again");
        })
    }

    $scope.delete = function (id) {
        $http.delete("/api/DripScriptAPI/" + id)
            .success(function (data) { console.log("Journal Entry Deleted"); $window.location.reload(); })
            .error(function () { console.log(error); });
    }

    $scope.update = function () {
        $profile = {
            "FirstName": $scope.first,
            "LastName": $scope.last,
            "Description": $scope.about
        }

        $http.put("/api/DripScriptAPI/5", $profile)
            .success(function (data) {
                $window.location.reload();
                console.log("Profile Updated!");
            })
            .error(function () { console.log(error); });
    }

    $scope.createEntry = function () {
        console.log("I Work!");
        $form = $("#myform").first();

        $entry = {
            "Body": $scope.body,
            "Title": $scope.title
        }

        console.log("Entry", $entry);

        $config_obj = {
            'headers': {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        }

        console.log("$config_obj", $config_obj);

        $http.post("/api/DripScriptAPI", $entry, $config_obj)
            .success(function (data) {
                console.log("data -->", data);
                $window.location.reload();
            }).error(function (error) { console.log(error.error) });
    }
  
}]);