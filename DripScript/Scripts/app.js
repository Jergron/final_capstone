var app = angular.module("drip", ["ngSanitize"]);

app.controller("TestController", ["$scope", "$http", "$window","$sce", function ($scope, $http, $window, $sce) {

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

        $http.post("/api/DripScriptAPI/search", $scope.query)
            .then(function (response) {
                var data = angular.fromJson(response.data)
                var verse = data.response.search.result.passages[0].text;
                $scope.verse = $sce.trustAsHtml(verse);            
            }); 
    }

    $scope.myJournal = function (id) {
        $http.get("/DripScript/MyJournal/" + id)
            .success(function (data) {              
                console.log("data", data);
            });
    }
  
}]);