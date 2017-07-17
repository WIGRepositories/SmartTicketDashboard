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

    $scope.GetVehcileMaster = function () {
        $http.get('/api/VehicleMaster/GetVehcileMaster?VID=1').then(function (res, data) {
            $scope.Vehicles = res.data;
        });
    }

    $scope.saveNew = function (newVehicle) {
        if (newVehicle == null) {
            alert('Please Enter Name');
            return;
        }
        if (newVehicle.VID == null) {
            alert('Please Enter ID');
            return;
        }
        if (newVehicle.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        if (newVehicle.Type == null) {
            alert('Please Enter Type');
            return;
        }
        if (newVehicle.OwnerName == null) {
            alert('Please Enter OwnerName');
            return;
        }
        if (newVehicle.ChasisNo == null) {
            alert('Please Enter ChasisNo');
            return;
        }
        if (newVehicle.Engineno == null) {
            alert('Please Enter Engineno');
            return;
        }
        if (newVehicle.WirelessFleetNo == null) {
            alert('Please Enter WirelessFleetNo');
            return;
        }
        if (newVehicle.AllotmentType == null) {
            alert('Please Enter AllotmentType');
            return;
        }
        if (newVehicle.RoadNo == null) {
            alert('Please Enter RoadNo');
            return;
        }
        if (newVehicle.RoadTaxDate == null) {
            alert('Please Enter RoadTaxDate');
            return;
        }
        if (newVehicle.InsuranceNo == null) {
            alert('Please Enter InsuranceNo');
            return;
        }
        if (newVehicle.InsDate == null) {
            alert('Please Enter InsDate');
            return;
        }
        if (newVehicle.PolutionNo == null) {
            alert('Please Enter PolutionNo');
            return;
        }
        if (newVehicle.PolExpDate == null) {
            alert('Please Enter PolExpDate');
            return;
        }
        if (newVehicle.RCBookNo == null) {
            alert('Please Enter RCBookNo');
            return;
        }
        if (newVehicle.RCExpDate == null) {
            alert('Please Enter RCExpDate');
            return;
        }
        if (newVehicle.CompanyVechile == null) {
            alert('Please Enter CompanyVechile');
            return;
        }
        if (newVehicle.OwnerPhoneNo == null) {
            alert('Please Enter OwnerPhoneNo');
            return;
        }
        if (newVehicle.HomeLandmark == null) {
            alert('Please Enter HomeLandmark');
            return;
        }
        if (newVehicle.ModelYear == null) {
            alert('Please Enter ModelYear');
            return;
        }
        if (newVehicle.DayOnly == null) {
            alert('Please Enter DayOnly');
            return;
        }
        if (newVehicle.DayNight == null) {
            alert('Please Enter DayNight');
            return;
        }
        if (newVehicle.InsProvider == null) {
            alert('Please Enter InsProvider');
            return;
        }
        if (newVehicle.VechMobileNo == null) {
            alert('Please Enter VechMobileNo');
            return;
        }
        if (newVehicle.EntryDate == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (newVehicle.NewEntry == null) {
            alert('Please Enter NewEntry');
            return;
        }
        if (newVehicle.AirPortCab == null) {
            alert('Please Enter AirPortCab');
            return;
        }
        if (newVehicle.deletedVech == null) {
            alert('Please Enter deletedVech');
            return;
        }
        if (newVehicle.Carrier == null) {
            alert('Please Enter Carrier');
            return;
        }
        if (newVehicle.PayGroup == null) {
            alert('Please Enter PayGroup');
            return;
        }



        var newVehicle = {

            flag:'I',
            VID: newVehicle.VID,
            RegistrationNo: newVehicle.RegistrationNo,
            Type: newVehicle.Type,
            OwnerName: newVehicle.OwnerName,
            ChasisNo: newVehicle.ChasisNo,
            Engineno: newVehicle.Engineno,
            WirelessFleetNo: newVehicle.WirelessFleetNo,
            AllotmentType: newVehicle.AllotmentType,
            RoadNo: newVehicle.RoadNo,
            RoadTaxDate: newVehicle.RoadTaxDate,
            InsuranceNo: newVehicle.InsuranceNo,
            InsDate: newVehicle.InsDate,
            PolutionNo: newVehicle.PolutionNo,
            PolExpDate: newVehicle.PolExpDate,
            RCBookNo: newVehicle.RCBookNo,
            RCExpDate: newVehicle.RCExpDate,
            CompanyVechile: newVehicle.CompanyVechile,
            OwnerPhoneNo: newVehicle.OwnerPhoneNo,
            HomeLandmark: newVehicle.HomeLandmark,
            ModelYear: newVehicle.ModelYear,
            DayOnly: newVehicle.DayOnly,
            DayNight: newVehicle.DayNight,
            InsProvider: newVehicle.InsProvider,
            VechMobileNo: newVehicle.VechMobileNo,
            EntryDate: newVehicle.EntryDate,
            NewEntry: newVehicle.NewEntry,
            AirPortCab: newVehicle.AirPortCab,
            deletedVech: newVehicle.deletedVech,
            Carrier: newVehicle.Carrier,
            PayGroup: newVehicle.PayGroup,

            Active: (newVehicle.Active == true) ? 1 : 0,


        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicles',
            data: newVehicle
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

    $scope.vech = null;


    $scope.save = function (vech, flag) {
        if (vech == null) {
            alert('Please Enter Name');
            return;
        }
        if (vech.VID == null) {
            alert('Please Enter ID');
            return;
        }
        if (vech.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        if (vech.Type == null) {
            alert('Please Enter Type');
            return;
        }
        if (vech.OwnerName == null) {
            alert('Please Enter OwnerName');
            return;
        }
        if (vech.ChasisNo == null) {
            alert('Please Enter ChasisNo');
            return;
        }
        if (vech.Engineno == null) {
            alert('Please Enter Engineno');
            return;
        }
        if (vech.WirelessFleetNo == null) {
            alert('Please Enter WirelessFleetNo');
            return;
        }
        if (vech.AllotmentType == null) {
            alert('Please Enter AllotmentType');
            return;
        }
        if (vech.RoadNo == null) {
            alert('Please Enter RoadNo');
            return;
        }
        if (vech.RoadTaxDate == null) {
            alert('Please Enter RoadTaxDate');
            return;
        }
        if (vech.InsuranceNo == null) {
            alert('Please Enter InsuranceNo');
            return;
        }
        if (vech.InsDate == null) {
            alert('Please Enter InsDate');
            return;
        }
        if (vech.PolutionNo == null) {
            alert('Please Enter PolutionNo');
            return;
        }
        if (vech.PolExpDate == null) {
            alert('Please Enter PolExpDate');
            return;
        }
        if (vech.RCBookNo == null) {
            alert('Please Enter RCBookNo');
            return;
        }
        if (vech.RCExpDate == null) {
            alert('Please Enter RCExpDate');
            return;
        }
        if (vech.CompanyVechile == null) {
            alert('Please Enter CompanyVechile');
            return;
        }
        if (vech.OwnerPhoneNo == null) {
            alert('Please Enter OwnerPhoneNo');
            return;
        }
        if (vech.HomeLandmark == null) {
            alert('Please Enter HomeLandmark');
            return;
        }
        if (vech.ModelYear == null) {
            alert('Please Enter ModelYear');
            return;
        }
        if (vech.DayOnly == null) {
            alert('Please Enter DayOnly');
            return;
        }
        if (vech.DayNight == null) {
            alert('Please Enter DayNight');
            return;
        }
        if (vech.InsProvider == null) {
            alert('Please Enter InsProvider');
            return;
        }
        if (vech.VechMobileNo == null) {
            alert('Please Enter VechMobileNo');
            return;
        }
        if (vech.EntryDate == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (vech.NewEntry == null) {
            alert('Please Enter NewEntry');
            return;
        }
        if (vech.AirPortCab == null) {
            alert('Please Enter AirPortCab');
            return;
        }
        if (vech.deletedVech == null) {
            alert('Please Enter deletedVech');
            return;
        }
        if (vech.Carrier == null) {
            alert('Please Enter Carrier');
            return;
        }
        if (vech.PayGroup == null) {
            alert('Please Enter PayGroup');
            return;
        }

        var vech = {

            flag: 'U',
            VID: vech.VID,
            RegistrationNo: vech.RegistrationNo,
            Type: vech.Type,
            OwnerName: vech.OwnerName,
            ChasisNo: vech.ChasisNo,
            Engineno: vech.Engineno,
            WirelessFleetNo: vech.WirelessFleetNo,
            AllotmentType: vech.AllotmentType,
            RoadNo: vech.RoadNo,
            RoadTaxDate: vech.RoadTaxDate,
            InsuranceNo: vech.InsuranceNo,
            InsDate: vech.InsDate,
            PolutionNo: vech.PolExpDate,
            RCBookNo: vech.RCBookNo,
            RCExpDate: vech.RCExpDate,
            CompanyVechile: vech.CompanyVechile,
            OwnerPhoneNo: vech.OwnerPhoneNo,
            HomeLandmark: vech.HomeLandmark,
            ModelYear: vech.ModelYear,
            DayOnly: vech.DayOnly,
            DayNight: vech.DayNight,
            InsProvider: vech.InsProvider,
            VechMobileNo: vech.VechMobileNo,
            EntryDate: vech.EntryDate,
            NewEntry: vech.NewEntry,
            AirPortCab: vech.AirPortCab,
            deletedVech: vech.deletedVech,
            Carrier: vech.Carrier,
            PayGroup: vech.PayGroup,

            Active: (vech.Active == true) ? 1 : 0,
        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicles',
            data: vech
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

    $scope.vech = null;

    $scope.setVehicles = function (vech) {
        $scope.vech = vech;
    };

    $scope.clearvech = function () {
        $scope.vech = null;
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







