// JavaScript source code
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
            });
        }
    };
});

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload, $timeout, fileReader, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    //-------get--------
    $scope.GetOperations = function () {
        //var countryId = $scope.ct.Id;
        //if (countryId == null) return;

        //var vgId = $scope.r.Id;
        //if (vgId == null) return;

        $http.get('/api/Operations/GetOperations').then(function (res, data) {
            $scope.Operations = res.data;
        });
    }
    //------get---------
    //------types------
    $scope.GetConfigData = function () {

        var vc = {
            includeFleetOwner: '1',
            includeVehicleType: '1',
            includeVehicleGroup: '1',
            includeVehicleModel: '1',
            includeVehicleMake: '1',
            includeActiveCountry: '1',
            includePackageTypeName: '1',
            includePackageNames: '1'
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            $scope.ct = $scope.initdata.Table4[0];
            $scope.r = $scope.initdata.Table[0];
            $scope.GetPackagesTypes();
        });
    }

    //------types------
    //-------post(I)--------
    $scope.saveNew = function (operate) {

        if (operate == null) {
            alert('Please enter name.');
            return;
        }

        if (operate.Name == null) {
            alert('Please enter name.');
            return;
        }

        var operations = {
            OpName: operate.Name,
            Code: operate.Code,            
            Description: operate.Description,
            Active: operate.Active,
            Id: -1,
            flag: 'I'
        };

        var req = {
            method: 'POST',
            url: '/api/Operations/OperationsPost',
            //headers: {
            //    'Content-Type': undefined
            data: operations
        }
        $http(req).then(function (response) {
            $scope.Group = null;

            alert("Saved successfully!");



        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };
    //----------post(I)-----------
    //---------post(U)--------
    $scope.save = function (Operation) {

        if (Operation == null) {
            alert('Please enter name.');
            return;
        }

        if (Operation.OpName == null) {
            alert('Please enter name.');
            return;
        }

        var SelOperation = {
            Name: Operation.OpName,
            Description: Operation.Description,
            Code:Operation.Code,
            Active: Operation.Active,           
            Id: Operation.Id,
            insupddelflag: 'U'
        };

        var req = {
            method: 'POST',
            url: '/api/Operations/OperationsPost',
            //headers: {
            //    'Content-Type': undefined
            data: SelOperation
        }
        $http(req).then(function (response) {

            $scope.showDialog("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Record is Not Saved";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        
        $scope.currGroup = null;

    };
    //-------post(U)------------
    $scope.setOperations = function (grp) {
        $scope.currGroup = grp;
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
    };
    //-----------------------------------------------

    $scope.UploadImg = function () {
        var fileinput = document.getElementById('fileInput');
        fileinput.click();

        //  
        //if ($scope.file == null)
        //{ $scope.file = fileinput.files[0]; }
        //fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
        //fileReader.onLoad($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    };
    $scope.onFileSelect1 = function () {

        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) {

            $scope.imageSrc = result;
        });
    }


    $scope.UploadImg1 = function () {
        var fileinput1 = document.getElementById('fileInput1');
        fileinput1.click();

        //  
        //if ($scope.file == null)
        //{ $scope.file = fileinput.files[0]; }
        //fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
        //fileReader.onLoad($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    };
    $scope.onFileSelect2 = function () {

        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) {

            $scope.imageSrc1 = result;
        });
    }
    //-----------------------------------------------

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
});




