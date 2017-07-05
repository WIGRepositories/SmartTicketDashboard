var app = angular.module('test', []);

var ctrl = app.controller('contrl', function ($scope, $http) {
   
   // $scope.Fleet = [{ "Col1": "1", "Col2": "2" }, { "Col1": "1", "Col2": "2" }, { "Col1": "1", "Col2": "2" }];

    $http.get('http://localhost:1476/api/test/GetTestdata').then(function (response, req) {
        $scope.Fleet1 = response.data;

    });

});