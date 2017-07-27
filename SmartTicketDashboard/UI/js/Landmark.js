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

    //$scope.Getvehicles = function () {
    //    $http.get('api/nearestvehicles/Getvehicles?PhoneNo=').then(function (res, data) {
    //        $scope.vehiclelist = res.data;
    //    });
    //}

    $scope.saveNew = function (newVehicles) {
        if (newVehicles == null) {
            //alert('Please Enter Name');
            return;
        }
        if (newVehicles.Zno == null) {
            alert('Please Enter Zno');
            return;
        }
        if (newVehicles.Landmark == null) {
            alert('Please Enter Landmark');
            return;
        } 
       

        var newVehicles = {
            flag:"I",
            Zno: newVehicles.Zno,
            Landmark: newVehicles.Landmark,       
            

            Active: (newVehicles.Active == true) ? 1 : 0,

           
        }

        var req = {
            method: 'POST',
            url: '/api/landmark/markingland',
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

    $scope.newVehicles = null;


    $scope.save = function (vechiles, flag) {
        if (vechiles == null) {
            alert('Please Enter Name');
            return;
        }
        if (vechiles.Zno == null) {
            alert('Please Enter Zno');
            return;
        }
        if (vechiles.Landmark == null) {
            alert('Please Enter Landmark');
            return;
        }

        var vechiles = {
            Zno: vechiles.Zno,
            Landmark: vechiles.Landmark,
           

            Active: (vechiles.Active == true) ? 1 : 0,


            flag: "U"
        }

        var req = {
            method: 'POST',
            url: '/api/landmark/markingland',
            data: vechiles
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Not Updated";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.vechiles = null;

    $scope.setVehicles = function (usr) {
        $scope.vechiles = usr;
    };

    $scope.clearVehicles = function () {
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








