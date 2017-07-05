var app = anguler.module('list', []);

var cntrl = app.controller('cntrl', function ($scope, $http) {

$http.get('http://localhost:1476/api/list/getphonesdata').then(function (response, req) {

    $scope.phones = response.data;

    });

});