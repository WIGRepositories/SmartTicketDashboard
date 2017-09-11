// JavaScript source code
// JavaScript source code
var app = angular.module('myApp1', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl1', function ($scope, $http, $localStorage, $uibModal) {
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


    $scope.GetAssigndetails = function () {

        $scope.drivers = null;

        $scope.selecteddrivers = parseLocation(window.location.search)['VID'];

        $http.get('/api/allocatedriver/GetAssigndetails?VechId=' + $scope.selecteddrivers).then(function (res, data) {
            $scope.a = res.data[0];

            //if ($scope.drivers.length > 0) {
            //    if ($scope.selecteddrivers != null) {
            //        for (i = 0; i < $scope.drivers.length; i++) {
            //            if ($scope.drivers[i].id == $scope.selecteddrivers) {
            //                $scope.v = $scope.drivers[i];
            //                break;
            //            }
            //        }
            //    }
            //    else {
            //        $scope.s = $scope.drivers[0];
            //        $scope.selecteddrivers = $scope.drivers[0].id;
            //    }

            //    $scope.getselectval($scope.selecteddrivers);
            //}
        });
    }
    $scope.getselectval = function (v) {

        $http.get('/api/allocatedriver/GetAssigndetails?VechId=' + $scope.selecteddrivers).then(function (res, data) {
            $scope.drivers = res.data;
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








