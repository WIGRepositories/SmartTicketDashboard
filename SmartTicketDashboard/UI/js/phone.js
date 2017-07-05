var app = angular.module('data', []);

var ctrl = app.controller('ctrl', function ($scope, $http) {

 $http.get('http://localhost:1476/api/data/Getphonedata').then(function (response, req) {
        $scope.phones = response.data;

    });

});