// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal)
{
    $scope.Getfleettextdata = function () {
        $scope.fllettextdata = [{ "col1":"test","col2":"test2" },{ "col1":"test","col2":"tast2" },{ "col1":"test","col2":"tast2" },{ "col1":"test","col2":"tast2" }]
       //get the data from database
        $http.get('').then(re, function () { 
            $scope.fleettextdata=res.data;
        })
    }
});

