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
        $http.get('api/nearestvehicles/Getvehicles?PhoneNo=').then(function (res, data) {
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
            Latitude: newVehicles.Latitude,
            Longitude: newVehicles.Longitude,
            Type: newVehicles.Type,
            
            

            Active: (newVehicles.Active == true) ? 1 : 0,

           
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
        if (vechiles.Name == null) {
            alert('Please Enter Nmae');
            return;
        }
        if (vechiles.Code == null) {
            alert('Please Enter Code');
            return;
        }

        var vechiles = {
            PhoneNo: vechiles.PhoneNo,
            Latitude: vechiles.Latitude,
            Longitude: vechiles.Longitude,
            Type: vechiles.Type,

            Active: (vechiles.Active == true) ? 1 : 0,


            flag: "U"
        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicles',
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








