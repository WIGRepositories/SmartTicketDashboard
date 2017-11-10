var app = angular.module('myApp1', ['ngStorage', 'ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal)
{
    $scope.GetHourBasePricing = function ()
    {

        var countryId = $scope.ct.Id;
        if (countryId == null) return;

        var vgId = $scope.vg.Id;
        if (vgId == null) return;

        $http.get("/api/HourBasedPricing/GetHourBasePricing?ctryId=" + countryId + "&vgId=" + vgId).then(function (response, req) {
            $scope.VechPricing = response.data;

            for (i = 0; i < $scope.initdata.Table.length; i++) {
                if ($scope.initdata.Table[i].Id == $scope.vDetails.StatusId) {
                    $scope.vDetails.StatusId = $scope.initdata.Table[i];
                    break;
                }
            }
        
        });
    }
    $scope.SavePricing = function (Vprice, flag) {

        if (Vprice == null) {
            alert('Please enter Pricing.');
            return;
        }
        if ($scope.vt.Id == null || $scope.vt.Id == "") {
            alert('Please enter VehicleType.');
            return;
        }
        if (Vprice.FromTime == null || Vprice.FromTime == "") {
            alert('Please enter Time.');
            return;
        }
        //emailid
        if (Vprice.ToTime == null) {
            alert('Please enter Time.');
            return;
        }

        if (Vprice.PricingType == null) {
            alert('Please enter Pricing.');
            return;
        }
        if (Vprice.FromDate == null) {
            alert('Please enter FromDate.');
            return;
        }
        if (Vprice.ToDate == null) {
            alert('Please enter ToDate.');
            return;
        }

        if (Vprice.c.Id == null) {
            alert('Please enter Country.');
            return;
        }
        if ($scope.vm.Id == null) {
            alert('Please enter VehicleGroup.');
            return;
        }



        var newSavePricing = {

            Id: -1,
            VehicleTypeId: $scope.vt.Id,
            FromTime: Vprice.FromTime,
            ToTime: Vprice.ToTime,
            Hours:Vprice.Hours,
            PricingType: Vprice.PricingType,
            FromDate: Vprice.FromDate,
            ToDate: Vprice.ToDate,                        
            CountryId: Vprice.c.Id,
            VehicleGroupId: $scope.vm.Id,
            price:Vprice.Price,
            insupddelflag: 'I'
        }


        var req = {
            method: 'POST',
            url: '/api/HourBasedPricing/SaveHourBasePricing',
            data: newSavePricing
        }
        $http(req).then(function (response) {

            alert("Saved successfully!!");

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
            needvehicleMake: '1'
            
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

    $scope.GetConfigData = function () {

        var vc = {
            includeVehicleType: '1',
            includeVehicleGroup: '1',           
            includeActiveCountry: '1'
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            $scope.ct = $scope.initdata.Table2[0];
            $scope.vg = $scope.initdata.Table[0];
            $scope.GetHourBasePricing();
        });
    }

    $scope.SavePricingChanges = function (DistPricing, flag) {
        if (DistPricing == null) {
            alert('Please enter Pricing.');
            return;
        }
        if ($scope.vm.Id == null || $scope.vm.Id == "") {
            alert('Please enter VehicleModel.');
            return;
        }
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


        var DistPricing = {
            Id: DistPricing.Id,
            VehicleGroupId: $scope.vm.Id,
            VehicleTypeId:$scope.vt.Id,
            Hours: DistPricing.Hours,
            FromTime: DistPricing.FromTime,
            ToTime: DistPricing.ToTime,
            FromDate: DistPricing.FromDate,
            ToDate:DistPricing.ToDate,
            Price: DistPricing.Price,
            PricingType:DistPricing.PricingType1,
            insupddelflag: 'U'

        }


        var req = {
            method: 'POST',
            url: '/api/HourBasedPricing/SaveHourBasePricing',
            data: DistPricing
        }
        $http(req).then(function (response) {

            alert("Updated successfully!!");
            $scope.GetHourBasePricing();
            $scope.DistPricing = null;

        }
        , function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;

        });
    };

        $scope.setVechPricing = function (Driver) {
            $scope.DistPricing = Driver;
        };

        $scope.clearVprice = function () {
            $scope.Driver = null;
        }
   
    });