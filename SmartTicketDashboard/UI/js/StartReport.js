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

    $scope.Getreporting = function () {
        $http.get('api/StartReport/Getreprts?VechID=1').then(function (res, data) {
            $scope.reportors = res.data;

        });
    }

   
    $scope.saveNew = function (report) {
        if (report == null) {
            alert('Please Enter Name');
            return;
        }
        if (report.SlNo == null) {
            alert('Please Enter SlNo');
            return;
        }
        if (report.EntryDate == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (report.VechID == null) {
            alert('Please Enter VechID');
            return;
        }
        if (report.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        if (report.DriverName == null) {
            alert('Please Enter DriverName');
            return;
        }
        if (report.PartyName == null) {


            alert('Please Enter PartyName');
            return;
        }
        if (report.PickupPlace == null) {
            alert('Please Enter PickupPlace');
            return;
        }
        if (report.DropPlace == null) {
            alert('Please Enter DropPlace');
            return;
        }
        if (report.StartMeter == null) {
            alert('Please Enter StartMeter');
            return;
        }
        if (report.PickupTime == null) {
            alert('Please Enter PickupTime');
            return;
        }
        if (report.ExecutiveName == null) {
            alert('Please Enter ExecutiveName');
            return;
        }
        if (report.BookingNo == null) {
            alert('Please Enter BookingNo');
            return;
        }
        if (report.EntryTime == null) {
            alert('Please Enter EntryTime');
            return;
        }
        if (report.CloseStatus == null) {
            alert('Please Enter CloseStatus');
            return;
        }
       



        var report = {

            flag:"I",
            SlNo:"",
            EntryDate: report.EntryDate,
            VechID: report.VechID,
            RegistrationNo: report.RegistrationNo,
            DriverName: report.DriverName,
            PartyName: report.PartyName,
            PickupPlace: report.PickupPlace,
            DropPlace: report.DropPlace,
            StartMeter: report.StartMeter,
            PickupTime: report.PickupTime,
            ExecutiveName: report.ExecutiveName,
            BookingNo: report.BookingNo,
            EntryTime: report.EntryTime,
            PolutionNo: report.PolExpDate,
            CloseStatus: report.CloseStatus,

            Active: (report.Active == true) ? 1 : 0,


        }

        var req = {
            method: 'POST',
            url: '/api/StartReport/Startingreport',
            data: report
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.reporting = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.reporting = null;


    $scope.save = function (reporting, flag) {
        if (reporting == null) {
            alert('Please Enter Name');
            return;
        }
        if (reporting.SlNo == null) {
            alert('Please Enter SlNo');
            return;
        }
        if (reporting.EntryDate == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (reporting.VechID == null) {
            alert('Please Enter VechID');
            return;
        }
        if (reporting.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        if (reporting.DriverName == null) {
            alert('Please Enter DriverName');
            return;
        }
        if (reporting.PartyName == null) {
            alert('Please Enter PartyName');
            return;
        }
        if (reporting.PickupPlace == null) {
            alert('Please Enter PickupPlace');
            return;
        }
        if (reporting.DropPlace == null) {
            alert('Please Enter DropPlace');
            return;
        }
        if (reporting.StartMeter == null) {
            alert('Please Enter StartMeter');
            return;
        }
        if (reporting.PickupTime == null) {
            alert('Please Enter PickupTime');
            return;
        }
        if (reporting.ExecutiveName == null) {
            alert('Please Enter ExecutiveName');
            return;
        }
        if (reporting.BookingNo == null) {
            alert('Please Enter BookingNo');
            return;
        }
        if (reporting.EntryTime == null) {
            alert('Please Enter EntryTime');
            return;
        }
        if (reporting.CloseStatus == null) {
            alert('Please Enter CloseStatus');
            return;
        }
       

        var reporting = {

            flag:"U",
            SlNo:"",
            EntryDate: reporting.EntryDate,
            VechID:reporting.VechID,
            RegistrationNo: reporting.RegistrationNo,
            DriverName: reporting.DriverName,
            PartyName: reporting.PartyName,
            PickupPlace: reporting.PickupPlace,
            DropPlace: reporting.DropPlace,
            StartMeter: reporting.StartMeter,
            PickupTime: reporting.PickupTime,
            ExecutiveName: reporting.ExecutiveName,
            BookingNo: reporting.BookingNo,
            EntryTime: reporting.EntryTime,
            PolutionNo: reporting.PolExpDate,
            CloseStatus: reporting.CloseStatus,
           

            Active: (reporting.Active == true) ? 1 : 0,
        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicles',
            data: reporting
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

    $scope.reporting = null;

    $scope.setreports = function (reporting) {
        $scope.reporting = reporting;
    };

    $scope.clearreporting = function () {
        $scope.reporting = null;
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








