
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload'])

myapp1.directive('file-input', function ($parse) {
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

myapp1.directive("ngFileSelect", function () {

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

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload, fileReader) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
   
    //$scope.carouselImages = [{ "ID": 1, "Name": "TRAVEL WITH INTERBUS", "Caption": "Every Journey Matters....", "Path": "http://localhost:1476/UI/images/11.jpg" }
    //   , { "ID": 2, "Name": "Customer satisfaction", "Caption": "The comfort and convienience of travelling with INTERBUS", "Path": "http://localhost:1476/UI/images/12.png" }
    //   , { "ID": 3, "Name": "Online Ticket Booking", "Caption": "Automated ticketing increases performance and convienience", "Path": "http://localhost:1476/UI/images/13.jpg" }
    //   , { "ID": 4, "Name": "Hassel free travel", "Caption": "Get online tickets to make the journey hassel free", "Path": "http://localhost:1476/UI/images/14.jpg" }
    //   , { "ID": 5, "Name": "Extensive coverage", "Caption": "Wide network taking you to various destinations", "Path": "http://localhost:1476/UI/images/user.jpg" }
    //];
    $scope.GetCarousel = function () {
        $http.get('/api/Carousal/GetCarousel').then(function (res, data) {
            $scope.carouselImages = res.data;
        });
    }
    $scope.saveNew = function (Car, flag) {
        //if (User == null) {
        //    alert('Please enter Email.');
        //    return;
        //}

        //if (User.FirstName == null) {
        //    alert('Please enter first name.');
        //    return;
        //}

        //if (User.LastName == null) {
        //    alert('Please enter last name.');
        //    return;
        //}

        //if (User.EmailId == null) {
        //    //alert('Please enter Email.');
        //    return;
        //}

        ////if ($scope.EmpNo == null) {
        ////    alert('Please enter employee no.');
        ////    return;
        ////}       

        //if ($scope.cmp == null) {
        //    alert('Please select a company.');
        //    return;
        //}

        var U = {
            flag:'I',
            Id: -1,
            ImageName: Car.ImageName,
            Image: $scope.imageSrc,
            ImageCaption: Car.Title,
            ImageDesc: Car.Description,
        CreatedBy: Car.CreatedBy,
        ModifiedBy: Car.modifiedby

       
        }

        var req = {
            method: 'POST',
            url: '/api/Carousal/CarousalOperations',
            data: U
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;
            $scope.GetCarousel();
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.save = function (Carl, flag) {
        //if (User == null) {
        //    alert('Please enter Email.');
        //    return;
        //}

        //if (User.FirstName == null) {
        //    alert('Please enter first name.');
        //    return;
        //}

        //if (User.LastName == null) {
        //    alert('Please enter last name.');
        //    return;
        //}

        //if (User.EmailId == null) {
        //    //alert('Please enter Email.');
        //    return;
        //}

        ////if ($scope.EmpNo == null) {
        ////    alert('Please enter employee no.');
        ////    return;
        ////}       

        //if ($scope.cmp == null) {
        //    alert('Please select a company.');
        //    return;
        //}

        var carousel = {
            flag: 'U',
            Id: Carl.Id,
            ImageName: Carl.ImageName,
            Image: $scope.imageSrc,
            ImageCaption: Carl.Title,
            ImageDesc: Carl.Description,
            CreatedBy: Carl.CreatedBy,
            ModifiedBy: Carl.modifiedby


        }

        var req = {
            method: 'POST',
            url: '/api/Carousal/CarousalOperations',
            data: carousel
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;
            $scope.GetCarousel();
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };
  
    $scope.setcarouselImages = function (i) {
        $scope.carousel = i;
        $scope.imageSrc = null;
        document.getElementById('cmpNewLogo').src = "";
        $scope.imageSrc = usr.photo;
        document.getElementById('uactive').checked = (usr.Active == 1);

    }

    $scope.clearCarl = function () {
        $scope.i = null;
    }
    /*end of  vehicle schedule list*/
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

    $scope.showPreview = function () {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent1.html'            
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

    $scope.clearImg = function () {
        $scope.imageSrc = null;
        document.getElementById('cmpLogo').src = "";
        document.getElementById('cmpNewLogo').src = "";
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
});

