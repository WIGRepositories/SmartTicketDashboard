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


    var parseLocation = function (location) {
        var pairs = location.substring(1).split("&");
        var obj = {};
        var pair;
        var i;

        for (i in pairs) {
            if (pairs[i] === "") continue;

            pair = pairs[i].split("=");
            obj[decodeURIComponent(pair[0])] = decodeURIComponent(pair[1]);
        }

        return obj;
    };


    $scope.Getdriverdetails = function () {

        $scope.driverdetails = null;

        $scope.selecteddriverdetails = parseLocation(window.location.search)['VechId'];

        $http.get('/api/DriverMaster/Getdriverdetails?DId=' + $scope.selecteddriverdetails).then(function (res, data) {
            $scope.driverdetails = res.data;

            if ($scope.driverdetails.length > 0) {
                if ($scope.selecteddriverdetails != null) {
                    for (i = 0; i < $scope.driverdetails.length; i++) {
                        if ($scope.driverdetails[i].id == $scope.selecteddriverdetails) {
                            $scope.v = $scope.driverdetails[i];
                            break;
                        }
                    }
                }
                else {
                    $scope.s = $scope.driverdetails[0];
                    $scope.selecteddriverdetails = $scope.driverdetails[0].id;
                }

                $scope.getselectval($scope.selecteddriverdetails);
            }
        });
    }
    $scope.getselectval = function (v) {

        $http.get('/api/DriverMaster/Getdriverdetails?DId=' + $scope.selecteddriverdetails).then(function (res, data) {
            $scope.driverdetails = res.data;
        });

    }



    $scope.GetCompanys = function () {
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;

        });
    }
    $scope.GetMaster = function () {
        $http.get('/api/DriverMaster/GetMaster?DId=1').then(function (res, data) {
            $scope.listdrivers = res.data;
        });
    }
    $scope.docfiles = [];

    $scope.onFileSelect = function (image, $event) {

        //$scope.docfiles = [];
        var ext = image[0].name.split('.').pop();
        fileReader.readAsDataUrl(image[0], $scope, (ext == 'img') ? 1 : 4).then(function (result) {

            if (result.length > 2097152) {
                alert('Cannot upload file greater than 2 MB.');
                $event.stopPropagation();
                $event.preventDefault();
                return;
            }

         

            //check if already the file exists                       
            for (cnt = 0; cnt < docfiles.length; cnt++) {
                if ($scope.docfiles[cnt].FileName == image[0].name) {
                    $scope.docfiles.splice(cnt, 1);
                }
            }

            $scope.docfiles.push(FileName);
            //if ($scope.DocFiles)
            //{
            //    $scope.DocFiles.push(doc);
            //}

        });
    };

     

    $scope.saveNew = function (Driverlist,flag) {
      
        
        if (Driverlist.Id == null) {
            alert('Please Enter CompanyId');
            return;
        }
        if (Driverlist.NAme == null) {
            alert('Please Enter NAme');
            return;
        }
        if (Driverlist.Address1 == null) {
            alert('Please Enter Address');
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
        

        var Driverlist = {

            flag:'I',
            DId:-1,
            CompanyId: Driverlist.Id,
            NAme: Driverlist.NAme,
            Address: Driverlist.Address1,
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
            FileName: Driverlist.FileName,
            
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

    $scope.Driverlist = null;

    $scope.save = function (driver, flag) {

        
        if (driver.CompanyId == null) {
            alert('Please Enter CompanyId');
            return;
        }
        if (driver.NAme == null) {
            alert('Please Enter NAme');
            return;
        }
        if (driver.City == null) {
            alert('Please Enter City');
            return;
        }
        if (driver.Pin == null) {
            alert('Please Enter Pin');
            return;
        }
        if (driver.PAddress == null) {
            alert('Please Enter PAddress');
            return;
        }
        if (driver.PCity == null) {
            alert('Please Enter PCity');
            return;
        }
        if (driver.PPin == null) {
            alert('Please Enter PPin');
            return;
        }
        if (driver.OffMobileNo == null) {
            alert('Please Enter OffMobileNo');
            return;
        }
        if (driver.PMobNo == null) {
            alert('Please Enter PMobNo');
            return;
        }
        if (driver.DOB == null) {
            alert('Please Enter DOB');
            return;
        }
        if (driver.DOJ == null) {
            alert('Please Enter DOJ');
            return;
        }
        if (driver.BloodGroup == null) {
            alert('Please Enter BloodGroup');
            return;
        }

        if (driver.LiCExpDate == null) {
            alert('Please Enter LiCExpDate');
            return;
        }
        if (driver.BadgeNo == null) {
            alert('Please Enter BadgeNo');
            return;
        }
        if (driver.BadgeExpDate == null) {
            alert('Please Enter BadgeExpDate');
            return;
        }
        if (driver.Remarks == null) {
            alert('Please Enter Remarks');
            return;
        }



        var driver = {

            flag: 'U',
            DId: driver.DId,
            CompanyId: driver.Companyid,
            NAme: driver.NAme,
            Address: driver.Address,
            City: driver.City,
            Pin: driver.Pin,
            PAddress: driver.PAddress,
            PCity: driver.PCity,
            PPin: driver.PPin,
            OffMobileNo: driver.OffMobileNo,
            PMobNo: driver.PMobNo,
            DOB: driver.DOB,
            DOJ: driver.DOJ,
            BloodGroup: driver.BloodGroup,
            LicenceNo: driver.LicenceNo,
            LiCExpDate: driver.LiCExpDate,
            BadgeNo: driver.BadgeNo,
            BadgeExpDate: driver.BadgeExpDate,
            Remarks: driver.Remarks,


        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Driver',
            data: driver
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");            

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
       
    };

    $scope.driver = null;

    $scope.setlistdrivers = function (cur) {
        $scope.driver = cur;
    };

    $scope.clearDriverlist = function () {
        $scope.cur = null;
    }
    

    $scope.validateFile = function ($event) {
       //  {
       //     alert('Please select docType');
       // //    $event.stopPropagation();
       // //    $event.preventDefault();
       //     return;
       //}
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








