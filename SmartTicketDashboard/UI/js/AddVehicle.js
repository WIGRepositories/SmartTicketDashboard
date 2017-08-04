﻿var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetCompanys = function () {
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;

        });
    }
      
    $scope.GetVehcileMaster = function () {
        $http.get('/api/VehicleMaster/GetVehcileMaster?VID=1').then(function (res, data) {
            $scope.VehiclesList = res.data;
        });
    }

    $scope.saveNew = function (newVehicle,flag) {
       
        if (newVehicle.c.Id == null) {
            alert('Please Enter CompanyId');
            return;
        }
        if (newVehicle.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        //var newVD = initdata.newfleet;
        if ($scope.initdata.newfleet.vt.Id == null || $scope.initdata.newfleet.vt.Id == null)
        {
            alert('Please Enter Type');
            return;
        }
        if ($scope.vm.Id == null || $scope.vm.Id == null) {
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
       
        if ($scope.vr.Id == null || $scope.vr.Id == null) {
            alert('Please Enter VechMobileNo');
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

        var newVehicle = {

            flag: 'I',            
            VID: newVehicle.VID,
            CompanyId: newVehicle.c.Id,
            RegistrationNo: newVehicle.RegistrationNo,
            Type: $scope.initdata.newfleet.vt.Id,
            VehicleModelId: $scope.vm.Id,
            OwnerName: newVehicle.OwnerName,
            ChasisNo: newVehicle.ChasisNo,
            Engineno: newVehicle.Engineno,
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
            VehicleGroupId: newVehicle.vg.Id,
            ServiceTypeId: $scope.vr.Id,
            VechMobileNo: newVehicle.VechMobileNo,
            EntryDate: newVehicle.EntryDate,
            NewEntry: newVehicle.NewEntry,
           

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

    $scope.newVehicle = null;
   

    $scope.save = function (vech, flag) {
        if (vech.c.Id == null) {
            alert('Please Enter CompanyId');
            return;
        }
        if (vech.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        //var newVD = initdata.newfleet;
        if ($scope.initdata.newfleet.vt.Id == null || $scope.initdata.newfleet.vt.Id == null) {
            alert('Please Enter Type');
            return;
        }
        if ($scope.vm.Id == null || $scope.vm.Id == null) {
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
        if (vech.EntryDate == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (vech.NewEntry == null) {
            alert('Please Enter NewEntry');
            return;
        }

        var vech = {

            flag: 'U',
            Id:vech.Id,
            VID: vech.VID,
            CompanyId: vech.c.Id,
            RegistrationNo: vech.RegistrationNo,
            Type: $scope.initdata.newfleet.vt.Id,
            Category: $scope.vm.Id,
            OwnerName: vech.OwnerName,
            ChasisNo: vech.ChasisNo,
            Engineno: vech.Engineno,
            RoadTaxDate: vech.RoadTaxDate,
            InsuranceNo: vech.InsuranceNo,
            InsDate: vech.InsDate,
            PolutionNo: vech.PolutionNo,
            PolExpDate: vech.PolExpDate,
            RCBookNo: vech.RCBookNo,
            RCExpDate: vech.RCExpDate,
            CompanyVechile: vech.CompanyVechile1,
            OwnerPhoneNo: vech.OwnerPhoneNo,
            HomeLandmark: vech.HomeLandmark,
            ModelYear: vech.ModelYear,
            DayOnly: vech.DayOnly1,
            VehicleGroupId: vech.vg1.Id,
            VechMobileNo: vech.VechMobileNo,
            EntryDate: vech.EntryDate,
            NewEntry: vech.NewEntry,


            Active: (vech.Active == true) ? 1 : 0,


        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicles',
            data: vech
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
       
    };

    $scope.vech1 = null;

    $scope.setVehiclesList = function (v) {
        $scope.vech = v;
    };

    $scope.clearnewVehicle = function () {
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

    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            needvehicleType: '1',
            needServiceType: '1',            
            needCompanyName: '1',
            needVehicleMake: '1',
            needVehicleGroup: '1',
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.initdata = res.data;
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








