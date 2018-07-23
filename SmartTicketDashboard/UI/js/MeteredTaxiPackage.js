var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload']);

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetChargesDiscounts = function () {

        //$scope.selectedChargeslist = parseLocation(window.location.search)['DId'];

        $http.get('/api/MeteredTaxiPackage/GetMeteredTaxiPackage').then(function (res, data) {
            $scope.Chargeslist = res.data;

        });
    }

    $scope.GetCategories = function () {
        //var grpid = (seltype) ? seltype.Id : -1;

        $http.get('/api/Types/TypesByGroupId?groupid=' + 29).then(function (res, data) {
            $scope.Categories = res.data;

        });

    }
    $scope.GetApplyAs = function () {
        //var grpid = (seltype) ? seltype.Id : -1;

        $http.get('/api/Types/TypesByGroupId?groupid=' + 4).then(function (res, data) {
            $scope.ApplyAs = res.data;

        });

    }
    $scope.Getvehtype = function () {
        //var grpid = (seltype) ? seltype.Id : -1;

        $http.get('/api/Types/TypesByGroupId?groupid=' + 12).then(function (res, data) {
            $scope.vehtype = res.data;

        });

    }


    $scope.SaveNew = function (taxipack, flag) {


        //if (Addcharges == null) {
        //    alert('Please Enter Name');
        //    return;
        //}
        //if (Addcharges.EntryDate == null) {
        //    alert('Please Enter EntryDate');
        //    return;
        //}
        //if (Addcharges.VechID == null) {
        //    alert('Please Enter VechID');
        //    return;
        //}
        //if (Addcharges.RegistrationNo == null) {
        //    alert('Please Enter RegistrationNo');
        //    return;
        //}
        //if (Addcharges.DriverName == null) {
        //    alert('Please Enter DriverName');
        //    return;
        //}
        //if (Addcharges.PartyName == null) {
        //    alert('Please Enter PartyName');
        //    return;
        //}
        //if (Addcharges.PickupPlace == null) {
        //    alert('Please Enter PickupPlace');
        //    return;
        //}
        //if (Addcharges.DropPlace == null) {
        //    alert('Please Enter DropPlace');
        //    return;
        //}
        //if (Addcharges.StartMeter == null) {
        //    alert('Please Enter StartMeter');
        //    return;
        //}
        //if (Addcharges.EndMeter == null) {
        //    alert('Please Enter EndMeter');
        //    return;
        //}
        //if (Addcharges.OtherExp == null) {
        //    alert('Please Enter OtherExp');
        //    return;
        //}
        //if (Addcharges.GeneratedAmount == null) {
        //    alert('Please Enter GeneratedAmount');
        //    return;
        //}
        //if (Addcharges.ActualAmount == null) {
        //    alert('Please Enter ActualAmount');
        //    return;
        //}

        //if (Addcharges.ExecutiveName == null) {
        //    alert('Please Enter ExecutiveName');
        //    return;
        //}
        //if (Addcharges.BNo == null) {
        //    alert('Please Enter BNo');
        //    return;
        //}
        //if (Addcharges.DropTime == null) {
        //    alert('Please Enter DropTime');
        //    return;
        //}
        //if (Addcharges.PickupTime == null) {
        //    alert('Please Enter PickupTime');
        //    return;
        //}
        //if (Addcharges.EntryTime == null) {
        //    alert('Please Enter EntryTime');
        //    return;
        //}



        var Addtaxipack = {

            flag: "I",
            Id: -1,           
            Code: taxipack.Code,
            PackageName: taxipack.PackageName,
            Description: taxipack.Description,
            OpId: $scope.OpId.Id,
            VehicleGroupId: $scope.vg.Id,
            VehicleTypeId: $scope.vt.Id
        }

        var req = {
            method: 'POST',
            url: '/api/MeteredTaxiPackage/SaveMeteredTaxiPackages',
            data: Addtaxipack
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Addchargesors = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;

    }

    $scope.Save = function (Edittaxipack) {


        //if (Addcharges == null) {
        //    alert('Please Enter Name');
        //    return;
        //}
        //if (Addcharges.EntryDate == null) {
        //    alert('Please Enter EntryDate');
        //    return;
        //}
        //if (Addcharges.VechID == null) {
        //    alert('Please Enter VechID');
        //    return;
        //}
        //if (Addcharges.RegistrationNo == null) {
        //    alert('Please Enter RegistrationNo');
        //    return;
        //}
        //if (Addcharges.DriverName == null) {
        //    alert('Please Enter DriverName');
        //    return;
        //}
        //if (Addcharges.PartyName == null) {
        //    alert('Please Enter PartyName');
        //    return;
        //}
        //if (Addcharges.PickupPlace == null) {
        //    alert('Please Enter PickupPlace');
        //    return;
        //}
        //if (Addcharges.DropPlace == null) {
        //    alert('Please Enter DropPlace');
        //    return;
        //}
        //if (Addcharges.StartMeter == null) {
        //    alert('Please Enter StartMeter');
        //    return;
        //}
        //if (Addcharges.EndMeter == null) {
        //    alert('Please Enter EndMeter');
        //    return;
        //}
        //if (Addcharges.OtherExp == null) {
        //    alert('Please Enter OtherExp');
        //    return;
        //}
        //if (Addcharges.GeneratedAmount == null) {
        //    alert('Please Enter GeneratedAmount');
        //    return;
        //}
        //if (Addcharges.ActualAmount == null) {
        //    alert('Please Enter ActualAmount');
        //    return;
        //}

        //if (Addcharges.ExecutiveName == null) {
        //    alert('Please Enter ExecutiveName');
        //    return;
        //}
        //if (Addcharges.BNo == null) {
        //    alert('Please Enter BNo');
        //    return;
        //}
        //if (Addcharges.DropTime == null) {
        //    alert('Please Enter DropTime');
        //    return;
        //}
        //if (Addcharges.PickupTime == null) {
        //    alert('Please Enter PickupTime');
        //    return;
        //}
        //if (Addcharges.EntryTime == null) {
        //    alert('Please Enter EntryTime');
        //    return;
        //}



        var Edittaxipack = {

            flag: "U",
            Id: Edittaxipack.Id,
            Code: Edittaxipack.Code,
            PackageName: Edittaxipack.PackageName,
            Description: Edittaxipack.Description,
            OpId: $scope.OpId.Id,
            VehicleGroupId: $scope.vg.Id,
            VehicleTypeId: $scope.vt.Id
        }

        var req = {
            method: 'POST',
            url: '/api/MeteredTaxiPackage/SaveMeteredTaxiPackages',
            data: Edittaxipack
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Edittaxipack = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });

        $scope.currGroup = null;

    }


    $scope.DeleteCharge = function (cd, flag) {
        var val = {
            flag: 'D',

            Id: cd.Id,
            Code: cd.Code,
            Title: cd.Title,
            Description: cd.Description,
            cdType: cd.cdType.Id,
            Category: cd.Category.Id,
            ApplyAs: cd.ApplyAs.Id,
            cdValue: cd.cdValue,
            FromDate: cd.FromDate,
            ToDate: cd.ToDate,
            //Active: (cd.Active == true) ? 1 : 0,
        }
        var req = {
            method: 'POST',
            url: '/api/SaveChargesDiscounts',
            data: val
        }
        $http(req).then(function (response) {

            alert("Deleted successfully!");

            $scope.currGroup = null;

        });
    };

    $scope.setCharges = function (cd) {
        $scope.Edittaxipack = cd;
    };

    $scope.GetConfigData = function () {

        var vc = {
            includeOperationName: '1',
            includeVehicleGroup: '1',
            includeVehicleType: '1',

        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
        });
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