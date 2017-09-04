﻿// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


    var parseLocation = function (location) {
        var pairs = location.substring(1).split("&");
        var obj = {};
        var pair;
        var i;

        for (i in pairs) {
            if (pairs[i] === "") continue;

            pair = pairs[i].split("=");
            obj[decodeURIComponent(pair[0])] = decodeURIComponent(pair[1]);
        }

        return obj;
    };


    $scope.GetBookingdetails = function () {

        $scope.bookings = null;

        $scope.selectedbookings = parseLocation(window.location.search)['VID'];

        $http.get('/api/BookAVehicle/Bookingdetails?VechId=' + $scope.selectedbookings).then(function (res, data) {
            $scope.bookings = res.data;

            if ($scope.bookings.length > 0) {
                if ($scope.selectedbookings != null) {
                    for (i = 0; i < $scope.bookings.length; i++) {
                        if ($scope.bookings[i].id == $scope.selectedbookings) {
                            $scope.v = $scope.bookings[i];
                            break;
                        }
                    }
                }
                else {
                    $scope.s = $scope.bookings[0];
                    $scope.selectedbookings = $scope.bookings[0].id;
                }

                $scope.getselectval($scope.selectedbookings);
            }
        });
    }
    $scope.getselectval = function (v) {

        $http.get('/api/BookAVehicle/GetBookingdetails?VID=' + $scope.selectedbookings).then(function (res, data) {
            $scope.bookings = res.data;
        });

    }
    

    $scope.showDialog = function (message) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            resolve: {
                mssg: function () {
                    return message;
                }
            }
        });
    }


});
app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});







