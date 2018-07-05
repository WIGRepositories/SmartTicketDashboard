// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    $scope.page = 1;
    $scope.pagesize = $localStorage.pagesize;
    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.GetConfigData = function () {

        var vc = {
            
            includeActiveCountry: '1',
            includeState:'1',
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

    $scope.savenewbankdetials = function (account) {

        var Types = {
            Id: Types.Id,
            Name: Types.Name,
            Description: Types.Description,
            Active: Types.Active,
            TypeGroupId: Types.TypeGroupId,
            ListKey: Types.ListKey,
            Listvalue: Types.Listvalue,
            insupddelflag: 'U'
        };

        var req = {
            method: 'POST',
           // url: '/api/Types/SaveType',
            //headers: {
            //    'Content-Type': undefined
            data: Types
        }

        $http(req).then(function (response) {

            alert("Saved successfully!");



            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };
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




    $scope.setCompany = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;

    };
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

myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

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