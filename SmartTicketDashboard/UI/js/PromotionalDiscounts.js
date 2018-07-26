var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload']);

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetPromotionalDiscount = function () {
        $http.get('/api/ChargesDiscounts/GetPromotionalDiscount').then(function (res, data) {
            $scope.promdisc = res.data;

        });
    }


    $scope.SaveNew = function (disc, flag) {

        if (disc == null) {
            alert('Please Enter Name');
            return;
        }
        if (disc.Code == null) {
            alert('Please Enter Code');
            return;
        }
        if ($scope.opcode == null || $scope.opcode.Id == null) {
            alert('Please Enter Operation Name');
            return;
        }
        if (disc.Condition == null) {
            alert('Please Enter Condition');
            return;
        }
        if ($scope.v == null || $scope.v.Id == null) {
            alert('Please Enter Value Type');
            return;
        }
        if ($scope.ApplyOn == null || $scope.ApplyOn.Id == null) {
            alert('Please Enter Apply On');
            return;
        }
        if ($scope.t == null || $scope.t.Id == null) {
            alert('Please Enter Type');
            return;
        }
        if (disc.FromValue == null) {
            alert('Please Enter From Value');
            return;
        }
        if (disc.ToValue == null) {
            alert('Please Enter To Value');
            return;
        }
        if ($scope.a == null || $scope.a.Id == null) {
            alert('Please Enter Applicability');
            return;
        }
        if (disc.Value == null) {
            alert('Please Enter Value');
            return;
        }

        var discounts = {

            flag: "I",
            Id: -1,
            Code: disc.Code,
            OpCode: $scope.opcode.Id,
            Condition: disc.Condition,
            ValueType: $scope.v.Id,
            ApplyOn: $scope.ApplyOn.Id,
            TypeId: $scope.t.Id,           
            FromValue: disc.FromValue,
            ToValue: disc.ToValue,
            Applicability:$scope.a.Id,
            Value: disc.Value
           
            
        }

        var req = {
            method: 'POST',
            url: '/api/ChargesDiscounts/SavePromotionalDiscount',
            data: discounts
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

    $scope.Save = function (prodisc) {


        if (prodisc == null) {
            alert('Please Enter Name');
            return;
        }
        if (prodisc.Code == null) {
            alert('Please Enter Code');
            return;
        }
        if ($scope.opcode == null || $scope.opcode.Id == null) {
            alert('Please Enter Operation Name');
            return;
        }
        if (prodisc.Condition == null) {
            alert('Please Enter Condition');
            return;
        }
        if ($scope.v == null || $scope.v.Id == null) {
            alert('Please Enter Value Type');
            return;
        }
        if ($scope.ApplyOn == null || $scope.ApplyOn.Id == null) {
            alert('Please Enter Apply On');
            return;
        }
        if ($scope.t == null || $scope.t.Id == null) {
            alert('Please Enter Type');
            return;
        } 
        if (prodisc.FromValue == null) {
            alert('Please Enter From Value');
            return;
        }
        if (prodisc.ToValue == null) {
            alert('Please Enter To Value');
            return;
        }
        if ($scope.a == null || $scope.a.Id == null) {
            alert('Please Enter Applicability');
            return;
        }
        if (prodisc.Value == null) {
            alert('Please Enter Value');
            return;
        }       
        
        var Editcharges = {

            flag: "U",
            Id: prodisc.Id,
            Code: prodisc.Code,
            OpCode: $scope.opcode.Id,
            Condition: prodisc.Condition,
            ValueType: $scope.v.Id,
            ApplyOn: $scope.ApplyOn.Id,
            TypeId: $scope.t.Id,
            FromValue: prodisc.FromValue,
            ToValue: prodisc.ToValue,
            Applicability: $scope.a.Id,
            Value: prodisc.Value
           
        }

        var req = {
            method: 'POST',
            url: '/api/ChargesDiscounts/SavePromotionalDiscount',
            data: Editcharges
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Editcharges = null;

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
            Active: (cd.Active == true) ? 1 : 0,
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
        $scope.prodisc = cd;
    };

    $scope.GetConfigData = function () {

        var vc = {
            includeApplicability: '1',
            includeApplicabilityType: '1',
            includeOperationName: '1',
            includeValueType: '1',
            includeApplyOn:'1',
           
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
});