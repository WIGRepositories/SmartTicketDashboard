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


    $scope.GetCompanys = function () {
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;

        });
    }

    $scope.Gettypes = function () {
        $http.get('/api/allocatedriver/Gettypes').then(function (res, data) {
            $scope.vehicles = res.data;
        });
    }


    $scope.Getallocatedriver = function () {
        $http.get('/api/allocatedriver/Getallocatedriver').then(function (res, data) {
            $scope.drivers = res.data;
        });
    }

    $scope.saveNew = function (newVehicle, flag) {
        if (newVehicle == null) {
            alert('Please Enter SLNO')
        }
        if (newVehicle.Id == null) {
            alert('Please Enter Id');
            return;
        }       
        if (newVehicle.Id == null) {
            alert('Please Enter CompanyId');
            return;
        }
        if (newVehicle.BookingNo == null) {
            alert('Please Enter BookingNo');
            return;
        }
        if (newVehicle.CustomerName == null) {
            alert('Please Enter CustomerName');
            return;
        }
        if (newVehicle.CusID == null) {
            alert('Please Enter CusID');
            return;
        }
        if (newVehicle.PhoneNo == null) {
            alert('Please Enter PhoneNo');
            return;
        }
        if (newVehicle.AltPhoneNo == null) {
            alert('Please Enter AltPhoneNo');
            return;
        }
        if (newVehicle.Address == null) {
            alert('Please Enter Address');
            return;
        }
        if (newVehicle.PickupAddress == null) {
            alert('Please Enter PickupAddress');
            return;
        }
        if (newVehicle.LandMark == null) {
            alert('Please Enter LandMark');
            return;
        }
        if (newVehicle.PickupPlace == null) {
            alert('Please Enter PickupPlace');
            return;
        }
        if (newVehicle.DropPlace == null) {
            alert('Please Enter DropPlace');
            return;

        }
        if (newVehicle.Package == null) {
            alert('Please Enter Package');
            return;

        }
        if (newVehicle.VehicleType == null) {
            alert('Please Enter VehicleType');
            return;

        }
        if (newVehicle.VechID == null) {
            alert('Please Enter vechid');
            return;
        }
        if (newVehicle.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        if (newVehicle.DriverName == null) {
            alert('Please Enter DriverName');
            return;
        }
        if (newVehicle.PresentDriverLandMark == null) {
            alert('Please Enter PresentDriverLandMark');
            return;
        }
        if (newVehicle.ExecutiveName == null) {
            alert('Please Enter ExecutiveName');
            return;
        }

        var newVehicle = {
            Id: -1,            
            CompanyId: newVehicle.Id,
            BookingNo: newVehicle.BookingNo,
            CustomerName: newVehicle.CustomerName,
            CusID: newVehicle.CusID,
            PhoneNo: newVehicle.PhoneNo,
            AltPhoneNo: newVehicle.AltPhoneNo,
            Address: newVehicle.Address,
            PickupAddres: newVehicle.PickupAddres,
            LandMark: newVehicle.LandMark,
            PickupPlace: newVehicle.PickupPlace,
            DropPlace: newVehicle.DropPlace,
            Package: newVehicle.Package,
            VehicleType: newVehicle.VehicleType,
            VechID: newVehicle.VechID,
            RegistrationNo: newVehicle.RegistrationNo,
            DriverName: newVehicle.DriverName,
            PresentDriverLandMark: newVehicle.PresentDriverLandMark,
            ExecutiveName: newVehicle.ExecutiveName,

            flag: "I"
        }

        var req = {
            method: 'POST',
            url: '/api/allocatedriver/AllocateDriver',
            data: newVehicle
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
            alert('Please Enter CompanyId');
            return;
        }
        
        if (AssginDriver.BookingNo == null) {
            alert('Please Enter BookingNo');
            return;
        }
        if (AssginDriver.CustomerName == null) {
            alert('Please Enter CustomerName');
            return;
        }
        if (AssginDriver.CusID == null) {
            alert('Please Enter CusID');
            return;
        }
        if (AssginDriver.PhoneNo == null) {
            alert('Please Enter PhoneNo');
            return;
        }
        if (AssginDriver.AltPhoneNo == null) {
            alert('Please Enter AltPhoneNo');
            return;
        }
        if (AssginDriver.Address == null) {
            alert('Please Enter Address');
            return;
        }
        if (AssginDriver.PickupAddress == null) {
            alert('Please Enter PickupAddress');
            return;
        }
        if (AssginDriver.LandMark == null) {
            alert('Please Enter LandMark');
            return;
        }
        if (AssginDriver.PickupPlace == null) {
            alert('Please Enter PickupPlace');
            return;
        }
        if (AssginDriver.DropPlace == null) {
            alert('Please Enter DropPlace');
            return;

        }
        if (AssginDriver.Package == null) {
            alert('Please Enter Package');
            return;

        }
        if (AssginDriver.VehicleType == null) {
            alert('Please Enter VehicleType');
            return;

        }
        if (AssginDriver.VechID == null) {
            alert('Please Enter VechID');
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
        if (AssginDriver.PresentDriverLandMark == null) {
            alert('Please Enter PresentDriverLandMark');
            return;
        }
        if (AssginDriver.ExecutiveName == null) {
            alert('Please Enter ExecutiveName');
            return;
        }

        var AssginDriver = {
            Id: AssginDriver.i,
            CompanyId:AssginDriver.Id,
            BookingNo: AssginDriver.BookingNo,
            CustomerName: AssginDriver.CustomerName,
            CusID: AssginDriver.CusID,
            PhoneNo: AssginDriver.PhoneNo,
            AltPhoneNo: AssginDriver.AltPhoneNo,
            Address: AssginDriver.Address,
            PickupAddress: AssginDriver.PickupAddress,
            LandMark: AssginDriver.LandMark,
            PickupPlace: AssginDriver.PickupPlace,
            DropPlace: AssginDriver.DropPlace,
            Package: AssginDriver.Package,
            VehicleType: AssginDriver.VehicleType,
            VechID: AssginDriver.VechID,
            RegistrationNo: AssginDriver.RegistrationNo,
            DriverName: AssginDriver.DriverName,
            PresentDriverLandMark: AssginDriver.PresentDriverLandMark,
            ExecutiveName: AssginDriver.ExecutiveName,

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








