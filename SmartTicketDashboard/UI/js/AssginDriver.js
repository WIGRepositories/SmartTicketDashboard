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

    //$scope.GetStops = function () {
    //    $http.get('/api/Stops/GetStops').then(function (res, data) {
    //        $scope.Stops = res.data;
    //    });
    //}

    $scope.saveNEW = function (AssginDriver,flag) {
        if (AssginDriver == null) {
            alert('Please Enter SLNO')
        }
        if (AssginDriver.SlNo == null) {
            alert('Please Enter SlNo');
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
            Id: -1,
            SlNo: AssginDriver.SlNo,
            BookingNo: AssginDriver.BookingNo,
            CustomerName: AssginDriver.CustomerName,
            CusID: AssginDriver.CusID,
            PhoneNo: AssginDriver.PhoneNo,
            AltPhoneNo: AssginDriver.AltPhoneNo,
            Address: AssginDriver.Address,
            PickupAddres: AssginDriver.PickupAddres,
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

            flag: "I"
        }

        var req = {
            method: 'POST',
            url: '/api/allocatedriver/AllocateDriver',
            data: AssginDriver
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








