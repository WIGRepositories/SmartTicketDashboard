var app = angular.module('myApp1', ['ngStorage', 'ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    $scope.GetDistanceBasePricing = function () {
        $http.get("/api/VehicleDistPricing/GetDistanceBasePricing").then(function (response, req) {
            $scope.VPricing = response.data;

        });
    }
    $scope.SavePricing = function (Group, flag) {

        if (Group == null) {
            alert('Please enter Pricing.');
            return;
        }
        if (Group.VehicleModel == null || Group.VehicleModel == "") {
            alert('Please enter VehicleModel.');
            return;
        }
        if (Group.FromKm == null || Group.FromKm == "") {
            alert('Please enter FromKm.');
            return;
        }
        //emailid
        if (Group.ToKm == null) {
            alert('Please enter ToKm.');
            return;
        }

        if (Group.Pricing == null) {
            alert('Please enter Pricing.');
            return;
        }

        var newSavePricing = {

            Id: Group.Id,
            VehicleModel: Group.VehicleModel,
            FromKm: Group.FromKm,
            ToKm: Group.ToKm,
            Pricing: Group.Pricing,

            insupddelflag: 'I'
        }


        var req = {
            method: 'POST',
            url: '/api/VehicleDistPricing/SaveVehicleDistPricing',
            data: newSavePricing
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");

            $scope.Group = null;
            //$scope.GetCompanys();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            // $scope.showDialog(errmssg);
            alert(errmssg);
        });
    };
    $scope.SavePricingChanges = function (currGroup, flag) {
        if (currGroup == null) {
            alert('Please enter Pricing.');
            return;
        }
        if (currGroup.VehicleModel == null || currGroup.VehicleModel == "") {
            alert('Please enter VehicleModel.');
            return;
        }
        if ($scope.FromKm == null || Group.FromKm == "") {
            alert('Please enter FromKm.');
            return;
        }
        //emailid
        if (currGroup.ToKm == null) {
            alert('Please enter ToKm.');
            return;
        }

        if (currGroup.Pricing == null) {
            alert('Please enter Pricing.');
            return;
        }


        var currGroup = {
            Id: currGroup.Id,
            VehicleModel: currGroup.VehicleModel,
            FromKm: currGroup.FromKm,
            ToKm: currGroup.ToKm,
            Pricing: currGroup.Pricing,
            insupddelflag: 'U'

        }


        var req = {
            method: 'POST',
            url: '/api/VehicleDistPricing/SaveHourBasePricing',
            data: currGroup
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");

            $scope.GetCompanys();
            $scope.currGroup = null;

        }
        , function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;

        });
    };
});