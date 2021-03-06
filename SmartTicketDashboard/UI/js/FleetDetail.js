var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload'])

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


var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload, fileReader) {

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetCountry = function () {
        $http.get('/api/Users/GetCountry?active=1').then(function (response, req) {
            $scope.Countries = response.data;
            if ($scope.Countries.length > 0) {
                $scope.ctry = $scope.Countries[0];
                $scope.GetCountry($scope.ctry);
            }
        });
    }

    $scope.GetFleetDetails = function () {

        if ($scope.cmp == null) {
            $scope.Companies = null;
            return;
        }

        if ($scope.fc == null) {
            $scope.fleet = null;
            return;
        }

        $http.get('/api/Fleet/getFleetList?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.fc.Id).then(function (res, data) {
            $scope.Fleet = res.data.Table;
        });
    }

    $scope.GetCompanies = function () {

        $http.get('/api/GetCompanyGroups?userid=-1').then(function (res, data) {
            $scope.Companies = res.data;

            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.cmp = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
                    }
                }
               // $scope.GetFleetOwners();
            }
            else {
                document.getElementById('test').disabled = false;
            }
            $scope.GetFleetOwners($scope.cmp);
        });

    }


    $scope.GetFleetOwners = function () {


        //$http.get('/api/Getfleet').then(function (res, data) {
        //    $scope.fleet = res.data;

        //    if ($scope.userSId != 1) {
        //        //loop throug the companies and identify the correct one
        //        for (i = 0; i < res.data.length; i++) {
        //            if (res.data[i].Id == $scope.userSId) {
        //                $scope.s = res.data[i];
        //                document.getElementById('test1').disabled = true;
        //                break
        //            }
        //        }
        //    }
        //    else {
        //        document.getElementById('test1').disabled = false;
        //    }
        // //   $scope.GetFleetDetails($scope.s);
        //});

           
            var vc = {
                needfleetowners: '1',
                cmpId: $scope.cmp.Id,
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

            if ($scope.userSId != 1) {
                            //loop throug the fleetowners and identify the correct one
                            for (i = 0; i < res.data.Table.length; i++) {
                                if (res.data.Table[i].UserId == $scope.userSId) {
                                    $scope.s = res.data.Table[i];
                        document.getElementById('test1').disabled = true;
                        break
                    }
                }
            }
            else {
                document.getElementById('test1').disabled = false;
            }
            $scope.GetFleetDetails($scope.s);

        });
    }

    $scope.GetVehcileList = function () {
        $http.get('/api/VehicleMaster/GetVehcileList').then(function (res, data) {
            $scope.VehiclesList = res.data;
            $scope.imageSrc = $scope.VehiclesList.Photo;
        });
        $scope.GetFleetOwners();
    }

    $scope.GetConfigData = function () {

        var vc = {
            includeFleetOwner: '1',
            includeVehicleType: '1',
            includeVehicleGroup: '1',
            includeActiveCountry: '1',
            includeVehicleLayoutType: '1'
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

    //This will hide the DIV by default.
    //$scope.IsHidden = true;
    //$scope.ShowHide = function () {
    //    //If DIV is hidden it will be visible and vice versa.
    //    $scope.IsHidden = $scope.IsHidden ? false : true;
    //}


    //$scope.GetCompanies1 = function () {

    //    var vc = {
    //        needCompanyName: '1'
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        headers: {
    //            'Content-Type': undefined
    //        data: vc
    //    }
    //    $http(req).then(function (res) {
    //        $scope.initdata = res.data;
    //        $scope.companies1 = res.data;
    //    });

    //}

    //$scope.GetFleetOwners1 = function () {
    //    if ($scope.cmp1 == null) {
    //        $scope.cmp1data = null;
    //        $scope.Fleet = null;
    //        return;
    //    }
    //    var vc = {
    //        needfleetowners: '1',
    //        cmpId: $scope.cmp1.Id
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        headers: {
    //            'Content-Type': undefined

    //        data: vc


    //    }
    //    $http(req).then(function (res) {
    //        $scope.cmp1data = res.data.Table;
    //    });
    //}

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
        });

    }

    /* $scope.GetFleetDetails = function () {
 
         $http.get('/api/Fleet/getFleetList?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
             $scope.Fleet = res.data.Table;
         });
     }*/

    $scope.save = function (Fleet, flag) {
        if (Fleet == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }

        if (Fleet.VehicleRegNo == null || Fleet.VehicleRegNo == "") {
            alert('Please enter VehicleRegNo.');
            return;
        }
        if (Fleet.FuelUsed == null || Fleet.FuelUsed == "") {
            alert('Please enter FuelUsed.');
            return;
        }
        if (Fleet.ChasisNo == null || Fleet.ChasisNo == "") {
            alert('Please enter ChasisNo.');
            return;
        }
        
        //if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
        //    alert('Please select a type group');
        //    return;
        //}



        var Fleet = {
            Id: Fleet.Id,
            VehicleRegNo: Fleet.VehicleRegNo,
            VehicleTypeId: (Fleet.vt != null) ? Fleet.vt.Id : Fleet.VehicleTypeId,
            VehicleLayoutId: (Fleet.vl != null) ? Fleet.vl.Id : Fleet.LayoutTypeId,
            FleetOwnerId: $scope.s.Id,
            CompanyId: $scope.cmp.Id,
            ServiceTypeId: (Fleet.st != null) ? Fleet.st.Id : Fleet.ServiceTypeId,
            EngineNo: Fleet.EngineNo,
            FuelUsed: Fleet.FuelUsed,
            MonthAndYrOfMfr: Fleet.MonthAndYrOfMfr,
            ChasisNo: Fleet.ChasisNo,
            SeatingCapacity: Fleet.SeatingCapacity,
            DateOfRegistration: Fleet.DateOfRegistration,
            Active: 1,
            insupddelflag: 'U'
        };

        var req = {
            method: 'POST',
            url: '/api/Fleet/NewFleetDetails',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet


        }
        $http(req).then(function (res) {
           $scope.showDialog("Updated successfully!");
           
        });

        $scope. GetCompanies();
    }

    $scope.savenewfleetdetails = function (newVehicle, flag) {
        
        if (newVehicle.RegistrationNo == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }
        /* 
        if (newVD.VehicleRegNo == null) {
            alert('Please enter VehicleRegNo.');
            return;
        }
        if (Fleet.group == null || Fleet.VehicleTypeId.group.Id == null) {
            alert('Please select a type group');
            return;
        }
        */


        var Fleet = {
            flag: 'I',
            Id: -1,
            VehicleCode: newVehicle.VCode,
            OwnerId: (newVehicle.s == null || newVehicle.s.Id == '') ? null : newVehicle.s.Id,
            RegistrationNo: newVehicle.RegistrationNo,
            ChasisNo: newVehicle.ChasisNo,
            Engineno: newVehicle.Engineno,
            VehicleGroupId: newVehicle.vg.Id,
            VehicleTypeId: newVehicle.vt.Id,
            VehicleModelId: 13,//newVehicle.vmo.Id,
            VehicleMakeId: 21,//newVehicle.vm.Id,
            ModelYear: newVehicle.ModelYear,
            //StatusId: 15,      // new      
            HasAC: 1,
            isDriverOwned: 1,
            LayOutTypeId: newVehicle.lt.Id,
            CountryId: (newVehicle.cn == null || newVehicle.cn.Id == '') ? null : newVehicle.cn.Id,
            DriverId: ($scope.d != null && $scope.d.Id != null) ? $scope.d.Id : null,
            CompanyId:$scope.newVehicle.c.Id,
            Photo: $scope.imageSrc

        };

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicle',
            //headers: {
            //    'Content-Type': undefined

            data: Fleet
        }

        $http(req).then(function (response) {

          alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.setFleet = function (F) {
        $scope.currVD = F;
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
    $scope.onFileSelect1 = function () {

        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) {

            $scope.imageSrc = result;
        });
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
    $scope.filterValue = function ($event) {
        if (isNaN(String.fromCharCode($event.keyCode))) {
            $event.preventDefault();
        }
    };

    $scope.clearGroup = function () {
        $scope.currGroup = null;
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

