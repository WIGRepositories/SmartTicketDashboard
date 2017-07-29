var app = angular.module('myApp1', ['ngStorage', 'ui.bootstrap'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    $scope.GetDistanceBasePricing = function () {
        $http.get("/api/VehicleDistPricing/GetDistanceBasePricing").then(function (response, req) {
            $scope.VPricing = response.data;

        });
    }
    $scope.SavePricing = function (Dist, flag) {

        if (Dist == null) {
            alert('Please enter Pricing.');
            return;
        }
        if ($scope.vm.Id == null || $scope.vm.Id == "") {
            alert('Please enter VehicleModel.');
            return;
        }
        if (Dist.FromKm == null || Dist.FromKm == "") {
            alert('Please enter FromKm.');
            return;
        }
        //emailid
        if (Dist.ToKm == null) {
            alert('Please enter ToKm.');
            return;
        }

        if (Dist.Pricing == null) {
            alert('Please enter Pricing.');
            return;
        }
        if (Dist.FromTime == null) {
            alert('Please enter FromTime.');
            return;
        }
        if (Dist.ToTime == null) {
            alert('Please enter ToTime.');
            return;
        }

        var Pricing = {

            Id: Dist.Id,
            VehicleModelId: $scope.vm.Id,
            FromKm: Dist.FromKm,
            ToKm: Dist.ToKm,
            Pricing: Dist.Pricing,
            FromTime: Dist.FromTime,
            ToTime: Dist.ToTime,
            insupddelflag: 'I'
        }


        var req = {
            method: 'POST',
            url: '/api/VehicleDistPricing/SaveVehicleDistPricing',
            data: Pricing
        }
        $http(req).then(function (response) {

            alert("Saved successfully!!");

            $scope.Group = null;
            //$scope.GetCompanys();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            // $scope.showDialog(errmssg);
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.Changes = null;
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

    $scope.Save = function (Changes, flag) {
        if (Changes == null) {
            alert('Please enter Pricing.');
            return;
        }
        if ($scope.vm1.Id == null || $scope.vm1.Id == "") {
            alert('Please enter VehicleModel.');
            return;
        }
        if (Changes.FromKm == null || Changes.FromKm == "") {
            alert('Please enter FromKm.');
            return;
        }
        //emailid
        if (Changes.ToKm == null) {
            alert('Please enter ToKm.');
            return;
        }

        if (Changes.Pricing == null) {
            alert('Please enter Pricing.');
            return;
        }
        if (Changes.FromTime == null) {
            alert('Please enter FromTime.');
            return;
        }
        if (Changes.ToTime == null) {
            alert('Please enter ToTime.');
            return;
        }


        var Changes = {
            Id: Changes.Id,
            VehicleModelId: $scope.vm1.Id,
            FromKm: Changes.FromKm,
            ToKm: Changes.ToKm,
            Pricing: Changes.Pricing,
           
            FromTime: Changes.FromTime,
            ToTime: Changes.ToTime,
            insupddelflag: 'U'

        }


        var req = {
            method: 'POST',
            url: '/api/VehicleDistPricing/SaveVehicleDistPricing',
            data: Changes
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.PricingChanges = null;

    $scope.setVPricing = function (vp) {
        $scope.Changes = vp;
    };

    $scope.clearDist = function () {
        $scope.vp = null;
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