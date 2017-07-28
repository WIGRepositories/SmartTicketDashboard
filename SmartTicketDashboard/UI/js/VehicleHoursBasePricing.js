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
        if ($scope.vm.Id == null || $scope.vm.Id == "") {
            alert('Please enter VehicleModel.');
            return;
        }      
       
        if (Vprice.Hours == null) {
            alert('Please enter Hours.');
            return;
        }
        if (Vprice.FromTime == null) {
            alert('Please enter FromTime.');
            return;
        }
        if (Vprice.ToTime == null) {
            alert('Please enter ToTime.');
            return;
        }

        if (Vprice.Price == null) {
            alert('Please enter Price.');
            return;
        }


        var newSavePricing = {

            Id: Vprice.Id,
            VehicleModelId: $scope.vm.Id,
           // VehicleModelId: (Vprice.vm.Id != null) ? Vprice.vm.Id : Vprice.VehicleModel.Id,
            Hours: Vprice.Hours,
            FromTime: Vprice.FromTime,
            ToTime: Vprice.ToTime,
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
    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            needvehicleModel: '1'
            
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.initdata = res.data;
        });

    }
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
        if (DistPricing.FromTime == null) {
            alert('Please enter FromTime.');
            return;
        }
        if (DistPricing.ToTime == null) {
            alert('Please enter ToTime.');
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
            FromTime: DistPricing.FromTime,
            ToTime: DistPricing.ToTime,
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