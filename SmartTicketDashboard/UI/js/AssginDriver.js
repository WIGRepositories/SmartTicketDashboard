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


    $scope.Getallocatedriver = function () {
        $http.get('/api/allocatedriver/Getallocatedriver?VID=1').then(function (res, data) {
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
             
        if ($scope.vm1.Id == null) {
            alert('Please Enter vechid');
            return;
        }
        if ($scope.c.Id == null) {
            alert('Please Enter CompanyId');
            return;
        }       
       
        if (newVehicle.DId == null || newVehicle.DId.DId == null) {
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
            VechID: $scope.vm1.Id,
            CompanyId: $scope.c.Id,
            VehicleType: newVehicle.VehicleType,
            PhoneNo: newVehicle.PhoneNo,            
            RegistrationNo: newVehicle.RegistrationNo,
            DriverName: newVehicle.DriverName,
            DriverId: newVehicle.DId.DId,
            EffectiveDate: newVehicle.EffectiveDate,
            EffectiveTill: newVehicle.EffectiveTill,
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

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.AssginDriver = null;


    $scope.save = function (AssginDriver, flag) {

        if (AssginDriver == null) {
           // alert('Please Enter SLNO')
        }        
        if (AssginDriver.Id == null) {
            alert('Please Enter VID');
            return;
        }        
        if (AssginDriver.VehicleType == null) {
            alert('Please Enter VehicleType');
            return;

        }
        if (AssginDriver.PhoneNo == null) {
            alert('Please Enter PhoneNo');
            return;

        }
        if (AssginDriver.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        if (AssginDriver.DriverName == null) {
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
            Id: -1,
            VechID:$scope.vm.id,
            VehicleType: AssginDriver.VehicleType,
            PhoneNo: AssginDriver.PhoneNo,
            RegistrationNo: $scope.vm.RegistrationNo,
            DriverName: AssginDriver.DriverName,
            EffectiveDate: AssginDriver.EffectiveDate,
            EffectiveTill: AssginDriver.EffectiveTill,
            DriverId:AssginDriver.Did.Did,
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
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.AssginDriver = null;

    $scope.setdrivers = function (Driver) {
        $scope.AssginDriver = Driver;
    };

    $scope.clearAssginDriver = function () {
        $scope.Driver = null;
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








