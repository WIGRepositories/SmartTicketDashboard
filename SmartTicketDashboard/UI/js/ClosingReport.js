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

    $scope.GetStops = function () {
        $http.get('/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
        });
    }

    $scope.saveNewStop = function (ClosingReport) {
        if (ClosingReport == null) {
            alert('Please Enter Name');
            return;
        }
        if (ClosingReport.SlNo == null) {
            alert('Please Enter SlNo');
            return;
        }
        if (ClosingReport.EntryDate  == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (ClosingReport.VechID  == null) {
            alert('Please Enter VechID');
            return;
        }
        if (ClosingReport.RegistrationNo  == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        if (ClosingReport.DriverName  == null) {
            alert('Please Enter DriverName');
            return;
        }
        if (ClosingReport.PartyName  == null) {
            alert('Please Enter PartyName');
            return;
        }
        if (ClosingReport.PickupPlace  == null) {
            alert('Please Enter PickupPlace');
            return;
        }
        if (ClosingReport.DropPlace  == null) {
            alert('Please Enter DropPlace');
            return;
        }
        if (ClosingReport.StartMeter == null) {
            alert('Please Enter StartMeter');
            return;
        }
        if (ClosingReport.EndMeter  == null) {
            alert('Please Enter EndMeter ');
            return;
        }
        if (ClosingReport.OtherExp  == null) {
            alert('Please Enter OtherExp ');
            return;
        }
        if (ClosingReport.GeneratedAmount == null) {
            alert('Please Enter GeneratedAmount,');
            return;
        }
        if (ClosingReport.ActualAmount  == null) {
            alert('Please Enter ActualAmount ');
            return;
        }
        if (ClosingReport.ExecutiveName  == null) {
            alert('Please Enter ExecutiveName ');
            return;
        }
        if (ClosingReport.DropTime == null) {
            alert('Please Enter DropTime ');
            return;
        }
        if (ClosingReport.PickupTime == null) {
            alert('Please Enter PickupTime');
            return;
        }
        if (ClosingReport.EntryTime == null) {
            alert('Please Enter EntryTime');
            return;
        }


        var ClosingReport = {
            Id: -1,
            Name: newStop.Name,
            Description: newStop.Description,
            Code: newStop.Code,

            Active: (newStop.Active == true) ? 1 : 0,

            insupdflag: "I"
        }

        var req = {
            method: 'POST',
            url: '/api/Stops/saveStops',
            data: ClosingReport
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








