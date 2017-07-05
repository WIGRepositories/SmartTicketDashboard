var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

 
    $scope.GetFleetlineData = function () {
        $scope.FleetlineData = [{ "col1": "test", "col2": "test2" }, { "col1": "test", "col2": "test2" }, { "col1": "test", "col2": "test2" }, { "col1": "test", "col2": "test2" }]
        //get the data from database
       $http.get('').then(re, function () {
         $scope.FleetlineData = res.data;
        })
       
    }

});
