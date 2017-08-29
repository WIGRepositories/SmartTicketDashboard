var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }


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


    $scope.GetVehcileMaster = function () {

        $scope.VehcileMaster = null;

        $scope.selectedVehicle = parseLocation(window.location.search)['Vid'];

        $http.get('/api/VehcileMaster/GetVehcileMaster?VID=' + $scope.selectedVehicle).then(function (res, data) {
            $scope.VehcileMaster = res.data;

            if ($scope.VehcileMaster.length > 0) {
                if ($scope.selectedVehicle != null) {
                    for (i = 0; i < $scope.VehcileMaster.length; i++) {
                        if ($scope.VehcileMaster[i].id == $scope.selectedVehicle) {
                            $scope.v = $scope.VehcileMaster[i];
                            break;
                        }
                    }
                }
                else {
                    $scope.s = $scope.VehcileMaster[0];
                    $scope.selectedVehicle = $scope.VehcileMaster[0].id;
                }

                $scope.getselectval($scope.selectedVehicle);
            }
        });
    }
    $scope.getselectval = function (v) {

        $http.get('/api/VehcileMaster/GetVehcileMaster?VID=' + $scope.selectedVehicle).then(function (res, data) {
            $scope.VehiclesList = res.data;
        });

    }

});