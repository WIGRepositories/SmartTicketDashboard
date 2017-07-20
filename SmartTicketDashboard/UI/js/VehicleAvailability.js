// JavaScript source code
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

    $scope.Getvehicles = function () {
        $http.get('/api/nearestvehicles/Getvehicles?PhoneNo=9951197608').then(function (res, data) {
            $scope.vehiclelist = res.data;
        });
    }

    $scope.savevech = function (newVehicles) {
        if (newVehicles == null) {
            alert('Please Enter Name');
            return;
        }
        if (newVehicles.PhoneNo == null) {
            alert('Please Enter PhoneNo');
            return;
        }
        if (newVehicles.Latitude == null) {
            alert('Please Enter Latitude');
            return;
        }
        if (newVehicles.Longitude == null) {
            alert('Please Enter Longitude');
            return;
        }
        if (newVehicles.Type == null) {
            alert('Please Enter Type');
            return;
        }

        var newVehicles = {
            PhoneNo: newVehicles.PhoneNo,
            latitude: newVehicles.Latitude,
            longitude: newVehicles.Longitude,
            Type: newVehicles.Type,
            Active: (newVehicles.Active == true) ? 1 : 0
        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicles',
            data: newVehicles
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.vechiles = null;


    $scope.save = function (vechiles, flag) {
        if (vechiles == null) {
            alert('Please Enter Name');
            return;
        }
        if (vechiles.PhoneNo == null) {
            alert('Please Enter PhoneNo');
            return;
        }
        if (vechiles.Latitude == null) {
            alert('Please Enter Latitude');
            return;
        }
        if (vechiles.Longitude == null) {
            alert('Please Enter Longitude');
            return;
        }
        if (vechiles.Type == null) {
            alert('Please Enter Type');
            return;
        }

        var vechiles = {
            PhoneNo: vechiles.PhoneNo,
            latitude: vechiles.Latitude,
            longitude: vechiles.Longitude,
            Type: vechiles.Type,

            Active: (vechiles.Active == true) ? 1 : 0,


            flag: "U"
        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicles',
            data: vechiles
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.vechiles = null;

    $scope.setvehiclelist = function (usr) {
        $scope.vechiles = usr;
    };

    $scope.clearvech = function () {
        $scope.vechiles = null;
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








