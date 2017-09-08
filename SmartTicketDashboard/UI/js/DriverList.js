// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap',  'angularFileUpload'])

app.directive('file-input', function ($parse) {
    return {
        restrict: "EA",
        template: "<input type='file' />",
        replace: true,
        link: function (scope, element, attrs) {

            var modelGet = $parse(attrs.fileInput);
            var modelSet = modelGet.assign;
            var onChange = $parse(attrs.onChange);

            var updateModel = function () {
                scope.$apply(function () {
                    modelSet(scope, element[0].files[0]);
                    onChange(scope);
                });
            };

            element.bind('change', updateModel);
        }
    };
});

app.directive("ngFileSelect", function () {

    return {

        link: function ($scope, el) {

            el.on('click', function () {

                this.value = '';

            });

            el.bind("change", function (e) {

                $scope.file = (e.srcElement || e.target).files[0];



                var allowed = ["jpeg", "png", "gif", "jpg"];

                var found = false;

                var img;

                img = new Image();

                allowed.forEach(function (extension) {

                    if ($scope.file.type.match('image/' + extension)) {

                        found = true;

                    }

                });

                if (!found) {

                    alert('file type should be .jpeg, .png, .jpg, .gif');

                    return;

                }

                img.onload = function () {

                    var dimension = $scope.selectedImageOption.split(" ");

                    if (dimension[0] == this.width && dimension[2] == this.height) {

                        allowed.forEach(function (extension) {

                            if ($scope.file.type.match('image/' + extension)) {

                                found = true;

                            }

                        });

                        if (found) {

                            if ($scope.file.size <= 1048576) {

                                $scope.getFile();

                            } else {

                                alert('file size should not be grater then 1 mb.');

                            }

                        } else {

                            alert('file type should be .jpeg, .png, .jpg, .gif');

                        }

                    } else {

                        alert('selected image dimension is not equal to size drop down.');

                    }

                };

                //  img.src = _URL.createObjectURL($scope.file);



            });

        }

    };

});

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, fileReader,$upload) {
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

        $scope.listdrivers = null;

        $scope.selectedlistdrivers = parseLocation(window.location.search)['DId'];

        $http.get('/api/DriverMaster/Getdriverdetails?DId=' + $scope.selectedlistdrivers).then(function (res, data) {
            $scope.listdrivers = res.data;

            if ($scope.listdrivers.length > 0) {
                if ($scope.selectedlistdrivers != null) {
                    for (i = 0; i < $scope.listdrivers.length; i++) {
                        if ($scope.listdrivers[i].id == $scope.selectedlistdrivers) {
                            $scope.v = $scope.listdrivers[i];
                            break;
                        }
                    }
                }
                else {
                    $scope.s = $scope.listdrivers[0];
                    $scope.selectedlistdrivers = $scope.listdrivers[0].id;
                }

                $scope.getselectval($scope.selectedlistdrivers);
            }

            $scope.imageSrc = $scope.listdrivers[0].Photo;
        });
    }
    $scope.getselectval = function (v) {

        $http.get('/api/DriverMaster/Getdriverdetails?DId=' + $scope.selectedlistdrivers).then(function (res, data) {
            $scope.listdrivers = res.data;
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
        $scope.imageSrc = $scope.listdrivers[0].Photo;
    }
    $scope.docfiles = [];

   

     

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
            Photo: $scope.imageSrc,
            licenseimage: $scope.imageSrc,
            badgeimage:$scope.imageSrc,
      
            
        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Driverlist',
            data: Driverlist
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };   

    $scope.Driverlist = null;

    $scope.save = function (driver,flag) {

        
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
            CompanyId: driver.companyid,
            NAme: driver.NAme,
            Address: driver.Address1,
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
            Photo: $scope.imageSrc,
            //licenseimage: $scope.imageSrc,
            //badgeimage: $scope.imageSrc,

        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Driverlist',
            data: driver
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");            

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
       
    };

    $scope.driver = null;

    $scope.setlistdrivers = function (Dl) {
        $scope.driver = Dl;
        $scope.imageSrc = null;
        document.getElementById('cmpNewLogo').src = "";
        $scope.imageSrc = Dl.photo;
        document.getElementById('uactive').checked = (Dl.Active == 1);
    };

    $scope.clearDriverlist = function () {
        $scope.Dl = null;
    }
    
    $scope.UploadImg = function () {
        var fileinput = document.getElementById('fileInput');
        fileinput.click();

        //  
        //if ($scope.file == null)
        //{ $scope.file = fileinput.files[0]; }
        //fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
        //fileReader.onLoad($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    };   
    $scope.onFileSelect = function () {
        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
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








