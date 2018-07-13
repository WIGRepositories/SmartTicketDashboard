var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload']);

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetPackages = function () {
        $http.get('/api/Packages/GetPackages').then(function (res, data) {
            $scope.package = res.data;
        });
    }

    $scope.GetPackageDiscounts = function () {
        $http.get('/api/ChargesDiscounts/GetPackageDiscounts').then(function (res, data) {
            $scope.Discounts = res.data;
        });
    }

    $scope.SaveNew = function (Discount, flag) {


        if (Discount == null) {
            alert('Please Enter Name');
            return;
        }
        if (Discount.Code == null) {
            alert('Please Enter Code');
            return;
        }
        if ($scope.p == null || $scope.p.Id == null) {
            alert('Please Enter Package');
            return;
        }
        if ($scope.t == null || $scope.t.Id == null) {
            alert('Please Enter Type');
            return;
        }
        if ($scope.ApplyOn == null || $scope.ApplyOn.Id == null) {
            alert('Please Enter Apply On');
            return;
        }
        if ($scope.u == null || $scope.u.Id == null) {
            alert('Please Enter Unit');
            return;
        }
        if ($scope.ut == null || $scope.ut.Id == null) {
            alert('Please Enter Unit Type');
            return;
        }      
        if (Discount.dt == null) {
            alert('Please Enter Discount Type');
            return;
        }
        if (Discount.Value == null) {
            alert('Please Enter Value');
            return;
        }
        if (Discount.EffectiveDate == null) {
            alert('Please Enter Effective Date');
            return;
        }
        if (Discount.ExpiryDate == null) {
            alert('Please Enter Expiry Date');
            return;
        }

        var Adddiscounts = {

            flag: "I",
            Id: -1,
            Code: Discount.Code,
            PackageId: $scope.p.Id,
            TypeId: $scope.t.Id,
            ApplyOn: $scope.ApplyOn.Id,           
            UnitTypeId: $scope.ut.Id,
            UnitId: $scope.u.Id,
            DiscountTypeId: Discount.dt,
            Value: Discount.Value,
            EffectiveDate: Discount.EffectiveDate,
            ExpiryDate: Discount.ExpiryDate,
        }

        var req = {
            method: 'POST',
            url: '/api/ChargesDiscounts/SavePackageDiscounts',
            data: Adddiscounts
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");
            $scope.GetPackageDiscounts();
            $scope.Addchargesors = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;

    }

    $scope.Save = function (Editdiscount) {


        if (Editdiscount == null) {
            alert('Please Enter Name');
            return;
        }
        if (Editdiscount.Code == null) {
            alert('Please Enter Code');
            return;
        }
        if ($scope.pp == null || $scope.pp.Id == null) {
            alert('Please Enter Package');
            return;
        }
        if ($scope.type == null || $scope.type.Id == null) {
            alert('Please Enter Type');
            return;
        }
        if ($scope.ApplyOn == null || $scope.ApplyOn.Id == null) {
            alert('Please Enter Apply On');
            return;
        }
        if ($scope.unit == null || $scope.unit.Id == null) {
            alert('Please Enter Unit');
            return;
        }
        if ($scope.unittype == null || $scope.unittype.Id == null) {
            alert('Please Enter Unit Type');
            return;
        }
        if (Editdiscount.DiscountType == null) {
            alert('Please Enter Discount Type');
            return;
        }
        if (Editdiscount.Value == null) {
            alert('Please Enter Value');
            return;
        }
        if (Editdiscount.EffectiveDate == null) {
            alert('Please Enter Effective Date');
            return;
        }
        if (Editdiscount.ExpiryDate == null) {
            alert('Please Enter Expiry Date');
            return;
        }

        var Editdiscounts = {

            flag: "U",
            Id: Editdiscount.Id,
            Code: Editdiscount.Code,
            PackageId: $scope.pp.Id,
            TypeId: $scope.type.Id,
            ApplyOn: $scope.ApplyOn.Id,
            UnitTypeId: $scope.unittype.Id,
            UnitId: $scope.unit.Id,
            DiscountTypeId: Editdiscount.DiscountType,
            Value: Editdiscount.Value,
            EffectiveDate: Editdiscount.EffectiveDate,
            ExpiryDate: Editdiscount.ExpiryDate,
        }

        var req = {
            method: 'POST',
            url: '/api/ChargesDiscounts/SavePackageDiscounts',
            data: Editdiscounts
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
        $scope.Editdiscount = cd;
    };

    $scope.GetConfigData = function () {

        var vc = {
            includeApplicability: '1',
            includeApplicabilityType: '1',
            includeUnitType: '1',
            includeUnit: '1',         
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