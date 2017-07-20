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

    $scope.GetMaster = function () {
        $http.get('/api/DriverMaster/GetMaster?DId=1').then(function (res, data) {
            $scope.Driverslist = res.data;
        });
    }

    $scope.savelist = function (Driverlist) {
      
        if (Driverlist.DId == null) {
            alert('Please Enter DId');
            return;


        }
        if (Driverlist.NAme == null) {
            alert('Please Enter NAme');
            return;
        }
        if (Driverlist.City == null) {
            alert('Please Enter City');
            return;
        }
        if (Driverlist.Pin == null) {
            alert('Please Enter Pin');
            return;
        }
        if (Driverlist.PAddress == null) {
            alert('Please Enter PAddress');
            return;
        }
        if (Driverlist.PCity == null) {
            alert('Please Enter PCity');
            return;
        }
        if (Driverlist.PPin == null) {
            alert('Please Enter PPin');
            return;
        }
        if (Driverlist.OffMobileNo == null) {
            alert('Please Enter OffMobileNo');
            return;
        }
        if (Driverlist.PMobNo == null) {
            alert('Please Enter PMobNo');
            return;
        }
        if (Driverlist.DOB == null) {
            alert('Please Enter DOB');
            return;
        }
        if (Driverlist.DOJ == null) {
            alert('Please Enter DOJ');
            return;
        }
        if (Driverlist.BloodGroup == null) {
            alert('Please Enter BloodGroup');
            return;
        }
        
        if (Driverlist.LiCExpDate == null) {
            alert('Please Enter LiCExpDate');
            return;
        }
        if (Driverlist.BadgeNo == null) {
            alert('Please Enter BadgeNo');
            return;
        }
        if (Driverlist.BadgeExpDate == null) {
            alert('Please Enter BadgeExpDate');
            return;
        }
        if (Driverlist.Remarks == null) {
            alert('Please Enter Remarks');
            return;
        }
       
        

        var Driverlist = {
            
            DId: Driverlist.id,
            NAme: Driverlist.NAme,
            Address: Driverlist.Address,
            City: Driverlist.City,
            Pin: Driverlist.Pin,
            PAddress: Driverlist.PAddress,
            PCity: Driverlist.PCity,
            PPin: Driverlist.PPin,
            OffMobileNo: Driverlist.OffMobileNo,
            PMobNo: Driverlist.PMobNo,
            DOB: Driverlist.DOB,
            DOJ: Driverlist.DOJ,
            BloodGroup: Driverlist.BloodGroup,
            LicenceNo: Driverlist.LicenceNo,
            LiCExpDate: Driverlist.LiCExpDate,
            BadgeNo: Driverlist.BadgeNo,
            BadgeExpDate: Driverlist.BadgeExpDate,
            Remarks: Driverlist.Remarks,

            
        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Driver',
            data: Driverlist
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.drivers = null;


    $scope.save = function (Driverlist, flag) {
        if (Driverlist == null) {
            alert('Please Enter Driverlist');
            return;
        }
        if (Driverlist.DId == null) {
            alert('Please Enter DId');
            return;
        }
        if (Driverlist.NAme == null) {
            alert('Please Enter NAme');
            return;
        }
        if (Driverlist.City == null) {
            alert('Please Enter City');
            return;
        }
        if (Driverlist.Pin == null) {
            alert('Please Enter Pin');
            return;
        }
        if (Driverlist.PAddress == null) {
            alert('Please Enter PAddress');
            return;
        }
        if (Driverlist.PCity == null) {
            alert('Please Enter PCity');
            return;
        }
        if (Driverlist.PPin == null) {
            alert('Please Enter PPin');
            return;
        }
        if (Driverlist.OffMobileNo == null) {
            alert('Please Enter OffMobileNo');
            return;
        }
        if (Driverlist.PMobNo == null) {
            alert('Please Enter PMobNo');
            return;
        }
        if (Driverlist.DOB == null) {
            alert('Please Enter Code');
            return;
        }
        if (Driverlist.DOJ == null) {
            alert('Please Enter DOB');
            return;
        }
        if (Driverlist.BloodGroup == null) {
            alert('Please Enter BloodGroup');
            return;
        }

        if (Driverlist.LiCExpDate == null) {
            alert('Please Enter LiCExpDate');
            return;
        }
        if (Driverlist.BadgeNo == null) {
            alert('Please Enter BadgeNo');
            return;
        }
        if (Driverlist.BadgeExpDate == null) {
            alert('Please Enter BadgeExpDate');
            return;
        }
        if (Driverlist.Remarks == null) {
            alert('Please Enter Remarks');
            return;
        }

        var Driverlist = {
           
            DId: Driverlist.id,
            NAme: Driverlist.NAme,
            Address: Driverlist.Address,
            City: Driverlist.City,
            Pin: Driverlist.Pin,
            PAddress: Driverlist.PAddress,
            PCity: Driverlist.PCity,
            PPin: Driverlist.PPin,
            OffMobileNo: Driverlist.OffMobileNo,
            PMobNo: Driverlist.PMobNo,
            DOB: Driverlist.DOB,
            DOJ: Driverlist.DOJ,
            BloodGroup: Driverlist.BloodGroup,
            LicenceNo: Driverlist.LicenceNo,
            LiCExpDate: Driverlist.LiCExpDate,
            BadgeNo: Driverlist.BadgeNo,
            BadgeExpDate: Driverlist.BadgeExpDate,
            Remarks: Driverlist.Remarks,

           
        }


        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Driver',
            data: Driverlist
        }
        $http(req).then(function (response) {

           alert("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.Driverlist = null;

    $scope.setDriverlist = function (usr) {
        $scope.drivers = usr;
    };

    $scope.clearDriverlist = function () {
        $scope.drivers = null;
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








