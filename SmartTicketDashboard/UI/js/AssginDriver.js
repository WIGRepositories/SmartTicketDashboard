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


    $scope.Getallocatedriver = function () {
        $http.get('/api/allocatedriver/Getallocatedriver?VID=1').then(function (res, data) {
            $scope.drivers = res.data;
        });
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
    $scope.GetCompanys = function () {
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;
            

        });
    }

    $scope.GetMaster = function () {
        $http.get('/api/DriverMaster/GetMaster?DId=1').then(function (res, data) {
            $scope.listdrivers = res.data;
        });
        $http.get('/api/VehicleMaster/GetVehcileMaster?VID=1').then(function (res, data) {
            $scope.Vehicles = res.data;
        });        
    }

   


    
   

    $scope.saveNew = function (newVehicle, flag) {
             
        if ($scope.vm.RegistrationNo == null) {
            alert('Please Enter vechid');
            return;
        }
        if ($scope.vm.VID == null) {
            alert('Please Enter vechid');
            return;
        }
        if ($scope.c.Id == null) {
            alert('Please Enter CompanyId');
            return;
        }      
       
        if ($scope.d.DId == null || $scope.d.DId.DId == null) {
            alert('Please Enter DriverName');
            return;
        }        
        if (newVehicle.EffectiveDate == null) {
            alert('Please Enter EffectiveDate');
            return;
        }
        if (newVehicle.EffectiveTill == null) {
            alert('Please Enter EffectiveTill');
            return;
        }
        

        var newVehicle1 = {
            Id: -1,
            VechID: $scope.vm.VID,
            CompanyId: $scope.c.Id,
            VehicleType: $scope.vm.Type,
            PhoneNo: $scope.d.DId.PMobNo,
            AltPhoneNo:$scope.d.DId.AltPhoneNo,
            RegistrationNo: $scope.vm.RegistrationNo,
            DriverName: $scope.d.DId.NAme,
            DriverId:$scope.d.DId.DId,
            EffectiveDate: newVehicle.EffectiveDate,
            EffectiveTill: newVehicle.EffectiveTill,
            VehicleModelId: $scope.vm.VehicleModelId,
            ServiceTypeId: $scope.vm.ServiceTypeId,
            VehicleGroupId:$scope.vm.VehicleGroupId,
            flag: "I"
        }

        var req = {
            method: 'POST',
            url: '/api/allocatedriver/AllocateDriver',
            data: newVehicle1
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;
            $scope.Getallocatedriver('VID=1');
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.newVehicle = null;


    $scope.save = function (AssginDriver, flag) {

        if ($scope.cc.Id == null) {
            alert('Please Enter Company');
            return;
        }
            
        if ($scope.v.Type == null) {
            alert('Please Enter VehicleType');
            return;

        }
        if (AssginDriver.PhoneNo == null) {
            alert('Please Enter PhoneNo');
            return;

        }
        if ($scope.vm1.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        if ($scope.dd.NAme == null) {
            alert('Please Enter DriverName');
            return;
        }
        if (AssginDriver.EffectiveDate == null) {
            alert('Please Enter EffectiveDate');
            return;
        }
        if (AssginDriver.EffectiveTill == null) {
            alert('Please Enter EffectiveTill');
            return;
        }

        var AssginDriver = {
            Id: AssginDriver.Id,
            CompanyId: $scope.c.Id,
            VechID:AssginDriver.VechID,
            VehicleType: $scope.v.Type,
            PhoneNo: AssginDriver.PhoneNo,
            RegistrationNo: $scope.vm1.RegistrationNo,
            DriverName: $scope.dd.NAme,
            EffectiveDate: AssginDriver.EffectiveDate,
            EffectiveTill: AssginDriver.EffectiveTill,
            DriverId:$scope.dd.DId,
            VehicleModelId: $scope.vm.VehicleModelId,
            ServiceTypeId: $scope.vm.ServiceTypeId,
            VehicleGroupId: $scope.vm.VehicleGroupId,
            
            
            flag: "U"
        }

        var req = {
            method: 'POST',
            url: '/api/allocatedriver/AllocateDriver',
            data: AssginDriver
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Not Updated";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.AssginDriver1 = null;

    $scope.setdrivers = function (a) {
        $scope.AssginDriver = a;
    };

    $scope.clearnewVehicle = function () {
        $scope.a = null;
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








