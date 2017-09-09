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

                //  img.src = _URL.createObjectURL($scope.file);



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


    $scope.GetVehcileDetails = function () {

        $scope.VehiclesList = null;

        $scope.selectedVehicleList = parseLocation(window.location.search)['VID'];

        $http.get('/api/VehicleMaster/GetVehcileDetails?Vid=' + $scope.selectedVehicleList).then(function (res, data) {
            $scope.v = res.data[0];

            //if ($scope.VehiclesList.length > 0) {
            //    if ($scope.selectedVehicleList != null) {
            //        for (i = 0; i < $scope.VehiclesList.length; i++) {
            //            if ($scope.VehiclesList[i].id == $scope.selectedVehicleList) {
            //                $scope.v = $scope.VehiclesList[i];
            //                break;
            //            }
            //        }
            //    }
            //    else {
            //        $scope.s = $scope.VehiclesList[0];
            //        $scope.selectedVehicleList = $scope.VehiclesList[0].id;
            //    }

            //    $scope.getselectval($scope.selectedVehicleList);
            //}
            $scope.imageSrc = $scope.v.Photo;
        });
    }
    $scope.getselectval = function (v) {

        $http.get('/api/VehcileMaster/GetVehcileMaster?VID=' + $scope.selectedVehicle).then(function (res, data) {
            $scope.VehiclesList = res.data;
        });


    }
    $scope.GetCompanys = function () {
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;

        });
    }
      
    $scope.GetVehcileMaster = function () {
        $http.get('/api/VehicleMaster/GetVehcileMaster?VID=1').then(function (res, data) {
            $scope.VehiclesList = res.data;
        });
       
    }


    $scope.GetCompanies = function () {

        $http.get('/api/GetCompanyGroups?userid=-1').then(function (res, data) {
            $scope.Companies = res.data;
            $scope.Companies1 = res.data;


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
            $scope.cmpdata = res.data;
            $scope.showdialogue("Saved successfully")


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
            $scope.GetFleetStaff($scope.s);

        });
    }

    

    $scope.saveNew = function (newVehicle,flag) {
       
        if (newVehicle.c.Id == null) {
            alert('Please Enter CompanyId');
            return;
        }
        if (newVehicle.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        //var newVD = initdata.newfleet;
        if ($scope.initdata.newfleet.vt.Id == null || $scope.initdata.newfleet.vt.Id == null)
        {
            alert('Please Enter Type');
            return;
        }
        if ($scope.vm.Id == null || $scope.vm.Id == null) {
            alert('Please Enter Type');
            return;
        }
        if (newVehicle.OwnerName == null) {
            alert('Please Enter OwnerName');
            return;
        }
        if (newVehicle.ChasisNo == null) {
            alert('Please Enter ChasisNo');
            return;
        }
        if (newVehicle.Engineno == null) {
            alert('Please Enter Engineno');
            return;
        }       
        if (newVehicle.RoadTaxDate == null) {
            alert('Please Enter RoadTaxDate');
            return;
        }
        if (newVehicle.InsuranceNo == null) {
            alert('Please Enter InsuranceNo');
            return;
        }
        if (newVehicle.InsDate == null) {
            alert('Please Enter InsDate');
            return;
        }
        if (newVehicle.PolutionNo == null) {
            alert('Please Enter PolutionNo');
            return;
        }
        if (newVehicle.PolExpDate == null) {
            alert('Please Enter PolExpDate');
            return;
        }
        if (newVehicle.RCBookNo == null) {
            alert('Please Enter RCBookNo');
            return;
        }
        if (newVehicle.RCExpDate == null) {
            alert('Please Enter RCExpDate');
            return;
        }
        if (newVehicle.CompanyVechile == null) {
            alert('Please Enter CompanyVechile');
            return;
        }
        if (newVehicle.OwnerPhoneNo == null) {
            alert('Please Enter OwnerPhoneNo');
            return;
        }
        if (newVehicle.HomeLandmark == null) {
            alert('Please Enter HomeLandmark');
            return;
        }
        if (newVehicle.ModelYear == null) {
            alert('Please Enter ModelYear');
            return;
        }
        if (newVehicle.DayOnly == null) {
            alert('Please Enter DayOnly');
            return;
        }
       
        if ($scope.vr.Id == null || $scope.vr.Id == null) {
            alert('Please Enter VechMobileNo');
            return;
        }
        if (newVehicle.VechMobileNo == null) {
            alert('Please Enter VechMobileNo');
            return;
        }
        if (newVehicle.EntryDate == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (newVehicle.NewEntry == null) {
            alert('Please Enter NewEntry');
            return;
        }    

        var newVehicle = {

            flag: 'I',            
            VID: newVehicle.VID,
            CompanyId: newVehicle.c.Id,
            RegistrationNo: newVehicle.RegistrationNo,
            Type: $scope.initdata.newfleet.vt.Id,
            VehicleModelId: $scope.vm.Id,
            OwnerName: newVehicle.OwnerName,
            ChasisNo: newVehicle.ChasisNo,
            Engineno: newVehicle.Engineno,
            RoadTaxDate: newVehicle.RoadTaxDate,
            InsuranceNo: newVehicle.InsuranceNo,
            InsDate: newVehicle.InsDate,
            PolutionNo: newVehicle.PolutionNo,
            PolExpDate: newVehicle.PolExpDate,
            RCBookNo: newVehicle.RCBookNo,
            RCExpDate: newVehicle.RCExpDate,
            CompanyVechile: newVehicle.CompanyVechile,
            OwnerPhoneNo: newVehicle.OwnerPhoneNo,
            HomeLandmark: newVehicle.HomeLandmark,
            ModelYear: newVehicle.ModelYear,
            DayOnly: newVehicle.DayOnly,
            VehicleGroupId: newVehicle.vg.Id,
            ServiceTypeId: $scope.vr.Id,
            VechMobileNo: newVehicle.VechMobileNo,
            EntryDate: newVehicle.EntryDate,
            NewEntry: newVehicle.NewEntry,
            photo: $scope.imageSrc,

            Active: (newVehicle.Active == true) ? 1 : 0,


        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicles',
            data: newVehicle
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;
            $scope.GetVehcileMaster('VID=1');
        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.newVehicle = null;
   

    $scope.save = function (vech, flag) {
        if (vech.c.Id == null) {
            alert('Please Enter CompanyId');
            return;
        }
        if (vech.RegistrationNo == null) {
            alert('Please Enter RegistrationNo');
            return;
        }
        //var newVD = initdata.newfleet;
        if ($scope.initdata.newfleet.vt.Id == null || $scope.initdata.newfleet.vt.Id == null) {
            alert('Please Enter Type');
            return;
        }
        if ($scope.vm.Id == null || $scope.vm.Id == null) {
            alert('Please Enter Type');
            return;
        }
        if (vech.OwnerName == null) {
            alert('Please Enter OwnerName');
            return;
        }
        if (vech.ChasisNo == null) {
            alert('Please Enter ChasisNo');
            return;
        }
        if (vech.Engineno == null) {
            alert('Please Enter Engineno');
            return;
        }
        if (vech.RoadTaxDate == null) {
            alert('Please Enter RoadTaxDate');
            return;
        }
        if (vech.InsuranceNo == null) {
            alert('Please Enter InsuranceNo');
            return;
        }
        if (vech.InsDate == null) {
            alert('Please Enter InsDate');
            return;
        }
        if (vech.PolutionNo == null) {
            alert('Please Enter PolutionNo');
            return;
        }
        if (vech.PolExpDate == null) {
            alert('Please Enter PolExpDate');
            return;
        }
        if (vech.RCBookNo == null) {
            alert('Please Enter RCBookNo');
            return;
        }
        if (vech.RCExpDate == null) {
            alert('Please Enter RCExpDate');
            return;
        }       
        if (vech.OwnerPhoneNo == null) {
            alert('Please Enter OwnerPhoneNo');
            return;
        }
        if (vech.HomeLandmark == null) {
            alert('Please Enter HomeLandmark');
            return;
        }
        if (vech.ModelYear == null) {
            alert('Please Enter ModelYear');
            return;
        }
        if (vech.DayOnly == null) {
            alert('Please Enter DayOnly');
            return;
        }              
        if (vech.EntryDate == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (vech.NewEntry == null) {
            alert('Please Enter NewEntry');
            return;
        }

        var vech = {

            flag: 'U',
            VID: vech.VID,
            CompanyId: vech.c.Id,
            RegistrationNo: vech.RegistrationNo,
            Type: $scope.initdata.newfleet.vt.Id,
            VehicleModelId: $scope.vm.Id,
            OwnerName: vech.OwnerName,
            ChasisNo: vech.ChasisNo,
            Engineno: vech.Engineno,
            RoadTaxDate: vech.RoadTaxDate,
            InsuranceNo: vech.InsuranceNo,
            InsDate: vech.InsDate,
            PolutionNo: vech.PolutionNo,
            PolExpDate: vech.PolExpDate,
            RCBookNo: vech.RCBookNo,
            RCExpDate: vech.RCExpDate,
            CompanyVechile: vech.CompanyVechile,
            OwnerPhoneNo: vech.OwnerPhoneNo,
            HomeLandmark: vech.HomeLandmark,
            ModelYear: vech.ModelYear,
            DayOnly: vech.DayOnly,
            VehicleGroupId: vech.vg1.Id,
            ServiceTypeId: $scope.vr.Id,
            VechMobileNo: vech.VechMobileNo,
            EntryDate: vech.EntryDate,
            NewEntry: vech.NewEntry,
            photo: $scope.imageSrc,


            Active: (vech.Active == true) ? 1 : 0,


        }

        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/Vehicles',
            data: vech
        }
        $http(req).then(function (response) {

            alert("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
       
    };

    $scope.vech1 = null;

    $scope.setVehiclesList = function (v) {
        $scope.vech = v;
        $scope.imageSrc = v.Photo;
    };

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

    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            needvehicleType: '1',
            needServiceType: '1',            
            needCompanyName: '1',
            needVehicleMake: '1',
            needVehicleGroup: '1',
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

    $scope.setUsers = function (usr) {
        $scope.User1 = usr;
        $scope.imageSrc = null;
        document.getElementById('cmpNewLogo').src = "";
        $scope.imageSrc = usr.photo;
        document.getElementById('uactive').checked = (usr.Active == 1);

    }
    $scope.GetUsersinitData = function () {

        $scope.imageSrc = null;
        document.getElementById('cmpLogo').src = "";

        var date = new Date();
        var components = [
            date.getHours(),
            date.getMinutes(),
            date.getSeconds()
        ];

        var id = components.join("");
        $scope.EmpNo = 'EMP' + id;

        //get companies list   
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;
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








