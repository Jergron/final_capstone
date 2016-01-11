var app = angular.module("drip", []);

app.controller("TestController", ["$scope", "$http", "$window", function ($scope, $http, $window) {

    $scope.delete = function (id) {
        $http.delete("/api/DripScriptAPI/" + id)
            .success(function (data) {
                console.log("Journal Entry Deleted");
                $window.location.reload();
            })
            .error(function () {
                console.log(error);
            });
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
            .error(function () {
                console.log(error);
            });
    }

    $scope.createEntry = function () {
        $entry = {
            "Body": $scope.body,
            "Title": $scope.title
        }
        
        $config_obj = {
            'headers': {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        }

        $http.post("/api/DripScriptAPI", $entry, $config_obj)
            .success(function (data) {
                $window.location.reload();
            }).error(function (error) {
                console.log(error.error)
            });
    }

    $scope.verseSearch = function () {
        $params = {
            "value": $scope.bibleSearch
        }
        $http.get("/api/DripScriptAPI/5", $scope.bibleSearch)
            .success(function (data) {
                console.log("data", data);
            }); 
    }

    $scope.myJournal = function (id) {
        $http.get("/DripScript/MyJournal/" + id)
            .success(function (data) {
                console.log("data", data);
            });
    }
  
}]);