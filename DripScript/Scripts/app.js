var app = angular.module("drip", []);

app.controller("TestController", ["$scope", "$http", function ($scope, $http) {

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

    $scope.delete = function () {
        $http.delete("/api/DripScriptAPI/5")
            .success(function (data) { alert("Journal Entry Deleted"); })
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
            }).error(function (error) { console.log(error.error) });
    }
  
}]);