﻿var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload'])

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
            });
        }
    };
});

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload, $timeout, fileReader, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }


    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetDrivers = function () {
        alert('There are no drivers');
    }
    $scope.GetConfigData = function () {

        var vc = {
            includeFleetOwner: '1',
            includeVehicleType:  '1',
            includeVehicleGroup:  '1',
            includeVehicleModel: '1',
            includeVehicleMake: '1',
            includeActiveCountry: '1'
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

   
    $scope.GetVehcileList = function () {
        $http.get('/api/VehicleMaster/GetVehcileList').then(function (res, data) {
            $scope.VehiclesList = res.data;
        });
        $scope.GetFleetOwners();
    }
    
    $scope.GetFleetOwners = function () {
        var vc = {
            needfleetowners: '1',
            cmpId: -1
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.cmpdata = res.data;           
        });
    }
    
    $scope.saveNew = function (newVehicle, flag) {
        
        if (newVehicle.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
       
        if (newVehicle.ChasisNo == null || newVehicle.ChasisNo == '') {
            alert('Please Enter chasis number');
            return;
        }
        if (newVehicle.Engineno == null || newVehicle.Engineno == '') {
            alert('Please Enter Engine number');
            return;
        }
        if (newVehicle.vt == null || newVehicle.vt.Id == null) {
            alert('Please select type');
            return;
        }
        if (newVehicle.vm == null || newVehicle.vm.Id == null) {
            alert('Please select make');
            return;
        }
        if (newVehicle.vmo == null || newVehicle.vmo.Id == null) {
            alert('Please select model');
            return;
        }
        if (newVehicle.vg == null || newVehicle.vg.Id == null) {
            alert('Please select group');
            return;
        }
        
        
        if (newVehicle.ModelYear == null) {
            alert('Please Enter ModelYear');
            return;
        }
       

        var newVehicle = {

            flag: 'I',
            Id: -1,
            VehicleCode: newVehicle.VCode,
            OwnerId: (newVehicle.f == null || newVehicle.f.Id == '') ? null : newVehicle.f.Id,
            RegistrationNo: newVehicle.RegistrationNo,
            ChasisNo: newVehicle.ChasisNo,
            Engineno: newVehicle.Engineno,
            VehicleGroupId: newVehicle.vg.Id,
            VehicleTypeId: newVehicle.vt.Id,
            VehicleModelId: newVehicle.vmo.Id,
            VehicleMakeId: newVehicle.vm.Id,
            ModelYear: newVehicle.ModelYear,
            StatusId: 15,      // new      
            HasAC: 1,
            isDriverOwned: 1,
            CountryId: (newVehicle.cn == null || newVehicle.cn.Id == '') ? null : newVehicle.cn.Id,
            DriverId:($scope.d !=null && $scope.d.Id !=null)?$scope.d.Id : null

        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicle',
            data: newVehicle
        }
        $http(req).then(function (res) {

            alert("Saved successfully!");
            var data = res.data;

            window.location.href = "vehicleDetails.html?VID="+res.data[0].Id;
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.newVehicle = null;   

    $scope.clearnewVehicle = function () {
        $scope.vech = null;
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







