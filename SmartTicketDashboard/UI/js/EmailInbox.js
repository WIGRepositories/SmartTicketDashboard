$(function () {

    $('.mail-box input[type="checkbox"]').on('ifChecked ifUnchecked', function (event) {
        if (event.type == 'ifUnchecked') {
            $(this).parent().parent().removeClass('active');
            $('.checkall').parent().removeClass
        } else {
            $(this).parent().parent().addClass('active');
        }
    });
    $('.checkall').on('ifChecked ifUnchecked', function (event) {
        if (event.type == 'ifChecked') {
            $('.tab-pane.active.in .mail-box input[type="checkbox"]').iCheck('check');
        } else {
            $('.tab-pane.active.in .mail-box input[type="checkbox"]').iCheck('uncheck');
        }
    });
});

var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
        
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetEmailBox = function () {
        $http.get('/api/EmailBox/GetEmailBox').then(function (res, data) {
            $scope.email = res.data;
        });
        // $scope.imageSrc = $scope.listdrivers.Photo;
    }
});