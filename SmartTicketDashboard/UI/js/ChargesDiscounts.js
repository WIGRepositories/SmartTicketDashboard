var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload']);

var ctrl =app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetChargesDiscounts = function () {

        //$scope.selectedChargeslist = parseLocation(window.location.search)['DId'];

        $http.get('/api/GetAllChargesDiscounts').then(function (res, data) {
            $scope.Chargeslist = res.data[0];

        });
    }

});