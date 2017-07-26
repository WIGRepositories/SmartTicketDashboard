var app = angular.module('myApp1', ['ngStorage', 'ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal)
{
    $scope.GetHourBasePricing = function ()
    {
        $http.get("/api/HourBasedPricing/GetHourBasePricing").then(function (response, req) {
            $scope.VechPricing = response.data;
        
        });
    }
    $scope.SavePricing = function (Vprice, flag) {

        if (Vprice == null) {
            alert('Please enter Pricing.');
            return;
        }
        if (Vprice.VehicleModel == null || Vprice.VehicleModel == "") {
            alert('Please enter VehicleModel.');
            return;
        }
       
        //emailid
        if (Vprice.Hours == null) {
            alert('Please enter Hours.');
            return;
        }

        if (Vprice.Price == null) {
            alert('Please enter Price.');
            return;
        }

        var newSavePricing = {

            Id: Vprice.Id,
            VehicleModel: Vprice.VehicleModel,
            Hours: Vprice.Hours,
           
            Price: Vprice.Price,

            insupddelflag: 'I'
        }


        var req = {
            method: 'POST',
            url: '/api/HourBasedPricing/SaveHourBasePricing',
            data: newSavePricing
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");

            $scope.Vprice = null;
            //$scope.GetCompanys();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            // $scope.showDialog(errmssg);
            alert(errmssg);
        });
    };
    $scope.SavePricingChanges = function (DistPricing, flag) {
        if (DistPricing == null) {
            alert('Please enter Pricing.');
            return;
        }
        if (DistPricing.VehicleModel == null || DistPricing.VehicleModel == "") {
            alert('Please enter VehicleModel.');
            return;
        }
       
        //emailid
        if (DistPricing.Hours == null) {
            alert('Please enter Hours.');
            return;
        }

        if (DistPricing.Price == null) {
            alert('Please enter Pricing.');
            return;
        }


        var SaveDistPricing = {
            Id: DistPricing.Id,
            VehicleModel: DistPricing.VehicleModel,
            
            Hours: DistPricing.Hours,
            Price: DistPricing.Price,
            insupddelflag: 'U'

        }


        var req = {
            method: 'POST',
            url: '/api/HourBasedPricing/SaveHourBasePricing',
            data: SaveDistPricing
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");

            $scope.GetHourBasePricing();
            $scope.DistPricing = null;

        }
        , function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;

        });
    };
    });