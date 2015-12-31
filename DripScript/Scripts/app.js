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

    $scope.createEntry = function () {
        console.log("I Work!");
        $form = $("#myform").first();

        $entry = {
            "Content": $scope.body,
            "Date": $scope.date,
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
                console.log("data", data);
                alert("Added journal entry Yay!");
            })
            .error(function (error) { console.log(error.error) });
    }
  
}]);