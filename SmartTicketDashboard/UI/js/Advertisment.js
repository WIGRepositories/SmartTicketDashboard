var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap','angularFileUpload'])

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

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, fileReader, $upload) {

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetAdvertisment = function () {

        $http.get('/api/Advertisment/GetAdvertisment').then(function (response, req) {
            $scope.advertisement = response.data;
        });
    }
  
    

    $scope.saveNew = function (adv, flag) {

        if (adv.CompanyName == null) {
            alert('Please Enter CompanyName');
            return;
        }
        if ($scope.imageSrc == null) {
            alert('Please Enter Image');
            return;
        }
        if (adv.Title == null) {
            alert('Please Enter Title');
            return;
        }

        if (adv.Description == null ) {
            alert('Please Enter Description');
            return;
        }
        if (adv.AdvertismentDate == null) {
            alert('Please Enter AdvertismentDate');
            return;
        }
        //if (adv.AdvertismentExpiredDate == null) {
        //    alert('Please Enter AdvertismentExpiredDate');
        //    return;
        //}
        if (adv.AdvertismentAmount == null) {
            alert('Please Enter AdvertismentAmount');
            return;
        }
            if (adv.Area == null) {
                alert('Please Enter Area');
                return;
        }


        var Advertisment = {
            Id: -1,
            CompanyName: adv.CompanyName,
            Image: $scope.imageSrc,
            AdvertisementTitle: adv.Title,
            Description: adv.Description,
            Clarification: adv.Clarification,
            Conclusion: adv.Conclusion,
            AdvertismentDate: adv.AdvertismentDate,
            AdvertismentExpiredDate: adv.AdvertismentExpiredDate,
            Price: adv.PrizeAmount,
            AdvertisementAmount: adv.AdvertismentAmount,
            Area:adv.Area,
            flag: "I"
        }

        var req = {
            method: 'POST',
            url: '/api/Advertisment/Advertismentsectionone',
            data: Advertisment
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };
    $scope.save = function () {

        if (advEdit.CompanyName == null) {
            alert('Please Enter CompanyName');
            return;
        }
        if ($scope.imageSrc == null) {
            alert('Please Enter Image');
            return;
        }
        if (advEdit.Title == null) {
            alert('Please Enter Title');
            return;
        }

        if (advEdit.Description == null) {
            alert('Please Enter Description');
            return;
        }
        if (advEdit.AdvertismentDate == null) {
            alert('Please Enter AdvertismentDate');
            return;
        }
        //if (adv.AdvertismentExpiredDate == null) {
        //    alert('Please Enter AdvertismentExpiredDate');
        //    return;
        //}
        if (advEdit.AdvertismentAmount == null) {
            alert('Please Enter AdvertismentAmount');
            return;
        }
        if (advEdit.Area == null) {
            alert('Please Enter Area');
            return;


        }


        var Advertisment = {
            Id: -1,
            CompanyName: advEdit.CompanyName,
            Image: $scope.imageSrc,
            AdvertisementTitle: advEdit.Title,
            Description: advEdit.Description,
            Clarification: advEdit.Clarification,
            Conclusion: advEdit.Conclusion,
            AdvertismentDate: advEdit.AdvertismentDate,
            AdvertismentExpiredDate: advEdit.AdvertismentExpiredDate,
            Price: advEdit.PrizeAmount,
            AdvertisementAmount: advEdit.AdvertismentAmount,
            Area: advEdit.Area,
            flag: "U"
        }
        var req = {
            method: 'POST',
            url: '/api/Advertisment/Advertismentsectionone',
            data: Advertisment
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
    $scope.Advertisment = null;

    $scope.setadvertisement = function (a) {
        $scope.Advertisment = a;
    };

    $scope.clearvehlogout = function () {
        $scope.a = null;
    }
    $scope.validateFile = function ($event) {
        //if ($scope.assetDoc.docType == null) {
        //    alert('Please select docType');
        //    $event.stopPropagation();
        //    $event.preventDefault();
        //    return;
        //}
    }
    $scope.GetCompanies = function () {

        var vc = {
            needCompanyName: '1'
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined
            data: vc
        }
        $http(req).then(function (res) {
            //$scope.initdata = res.data;
            $scope.companies = res.data;
            $scope.showdialogue("Saved successfully")
        });

    }

    $scope.GetFleetOwners = function () {
        if ($scope.cmp == null) {
            $scope.cmpdata = null;
            $scope.Fleet = null;
            return;
        }
        var vc = {
            needfleetowners: '1',
            cmpId: $scope.cmp.Id
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.cmpdata = res.data.Table;
            $scope.showdialogue("Saved successfully")
        });
    }

    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            needvehicleType: '1',
            needServiceType: '1',
            needvehiclelayout: '1',
            needCompanyName: '1'
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
            $scope.showdialogue("Saved successfully")
           
        });

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
});