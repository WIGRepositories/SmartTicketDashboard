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

    $scope.getVehicleDetails = function () {
        $http.get('/api/VehicleDetails/getVehicleDetails').then(function (res, data) {
            $scope.VehicleAvailable = res.data;
        });
    }

    $scope.save = function (VehicleAvailable) {
        if (VehicleAvailable == null) {
            alert('Please Enter Name');
            return;
        }
        if (VehicleAvailable.busId == null) {
            alert('Please Enter Nmae');
            return;
        }
        if (VehicleAvailable.busTypeId == null) {
            alert('Please Enter Code');
            return;
        }
        if (VehicleAvailable.conductorId == null) {
            alert('Please Enter Code');
            return;
        }
        if (VehicleAvailable.conductorName == null) {
            alert('Please Enter Code');
            return;
        }
        if (VehicleAvailable.driverId == null) {
            alert('Please Enter Code');
            return;
        }
        if (VehicleAvailable.driverName == null) {
            alert('Please Enter Code');
            return;
        }
        if (VehicleAvailable.fleetOwnerId == null) {
            alert('Please Enter Code');
            return;
        }
        if (VehicleAvailable.CompanyName == null) {
            alert('Please Enter Code');
            return;
        }
        if (VehicleAvailable.Id == null) {
            alert('Please Enter Code');
            return;
            if (VehicleAvailable.POSID == null) {
                alert('Please Enter Code');
                return;
            }
            if (VehicleAvailable.RegNo == null) {
                alert('Please Enter Code');
                return;
            }
            if (VehicleAvailable.route == null) {
                alert('Please Enter Code');
                return;
            }
            if (VehicleAvailable.Status == null) {
                alert('Please Enter Code');
                return;
            }
            if (VehicleAvailable.statusid == null) {
                alert('Please Enter Code');
                return;
            }
        }

        var VehicleAvailable = {
            Id: -1,
            busId: VehicleAvailable.busId,
            busTypeId: VehicleAvailable.busTypeId,
            conductorId: VehicleAvailable.conductorId,
            conductorName: VehicleAvailable.conductorName,
            driverId: VehicleAvailable.driverId,
            driverName: VehicleAvailable.driverName,
            fleetOwnerId: VehicleAvailable.fleetOwnerId,
            CompanyName: VehicleAvailable.CompanyName,
            Id: VehicleAvailable.Id,
            POSID: VehicleAvailable.POSID,
            RegNo: VehicleAvailable.RegNo,
            route: VehicleAvailable.route,
            Status: VehicleAvailable.Status,
            statusid: VehicleAvailable.statusid,


            Active: (VehicleAvailable.Active == true) ? 1 : 0,

            insupdflag: "I"
        }

        var req = {
            method: 'POST',
            url: '/api/VehicleDetails/saveVehicleDetails',
            data: VehicleAvailable
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect
            
            
            
            
            
            
            ";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.Stops1 = null;


    $scope.save = function (Stops, flag) {
        if (Stops == null) {
            alert('Please Enter Name');
            return;
        }
        if (Stops.Name == null) {
            alert('Please Enter Nmae');
            return;
        }
        if (Stops.Code == null) {
            alert('Please Enter Code');
            return;
        }

        var Stops = {
            Id: Stops.Id,
            Name: Stops.Name,
            Description: Stops.Description,
            Code: Stops.Code,

            Active: (Stops.Active == true) ? 1 : 0,


            insupdflag: "U"
        }

        var req = {
            method: 'POST',
            url: '/api/Stops/saveStops',
            data: Stops
        }
        $http(req).then(function (response) {

            //$scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.Stops = null;

    $scope.setStops = function (usr) {
        $scope.Stops1 = usr;
    };

    $scope.clearStops = function () {
        $scope.Stops1 = null;
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








