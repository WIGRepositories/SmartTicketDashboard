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
        $scope.imageSrc = $scope.VehiclesList.Photo;
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
            Id:-1,
            VID: newVehicle.VID,
            CompanyId: newVehicle.c.Id,
            RegistrationNo: newVehicle.RegistrationNo,
            Type: $scope.initdata.newfleet.vt.Id,
            VehicleModelId: $scope.vm.Id,
            OwnerName: newVehicle.OwnerName,           
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
   

    $scope.save = function (v, flag) {
        if (v.c.Id == null) {
            alert('Please Enter CompanyId');
            return;
        }
        if (v.RegistrationNo == null) {
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
        if (v.OwnerName == null) {
            alert('Please Enter OwnerName');
            return;
        }              
        if (v.OwnerPhoneNo == null) {
            alert('Please Enter OwnerPhoneNo');
            return;
        }
        if (v.HomeLandmark == null) {
            alert('Please Enter HomeLandmark');
            return;
        }
        if (v.ModelYear == null) {
            alert('Please Enter ModelYear');
            return;
        }
        if (v.DayOnly == null) {
            alert('Please Enter DayOnly');
            return;
        }              
        if (v.EntryDate == null) {
            alert('Please Enter EntryDate');
            return;
        }
        if (v.NewEntry == null) {
            alert('Please Enter NewEntry');
            return;
        }

        var vech = {

            flag: 'U',
            VID: v.VID,
            CompanyId: v.c.Id,
            RegistrationNo: v.RegistrationNo,
            Type: $scope.initdata.newfleet.vt.Id,
            VehicleModelId: $scope.vm.Id,
            OwnerName: v.OwnerName,           
            CompanyVechile: v.CompanyVechile,
            OwnerPhoneNo: v.OwnerPhoneNo,
            HomeLandmark: v.HomeLandmark,
            ModelYear: v.ModelYear,
            DayOnly: v.DayOnly,
            VehicleGroupId: v.vg1.Id,
            ServiceTypeId: $scope.vr.Id,
            VechMobileNo: v.VechMobileNo,
            EntryDate: v.EntryDate,
            NewEntry: v.NewEntry,
            photo: $scope.imageSrc,


            Active: (v.Active == true) ? 1 : 0,


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
            //needCompanyName: '1',
            needVehicleMake: '1',
            needVehicleGroup: '1',
            needDocuments: '1'
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

    $scope.onFileSelect1 = function () {
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

    $scope.onFileSelect = function (files, $event) {
        $scope.modifiedDoc = null;
        var found = false;
        ////check if job already exists 
        //for (cnt = 0; cnt < $scope.currobj.files1.length; cnt++) {
        //    if ($scope.currobj.files1[cnt].docName == files[0].name) {
        //        found = true;
        //    }
        //}

        //if (found) {
        //    alert('Cannot add duplicte documents. Document with the same name already exists.');
        //    $event.stopPropagation();
        //    $event.preventDefault();
        //    return;
        //}

        var ext = files[0].name.split('.').pop();
        fileReader.readAsDataUrl(files[0], $scope, (ext == 'csv') ? 1 : 4).then(function (result) {
            //if (result.length > 2097152) {
            //    alert('Cannot upload file greater than 2 MB.');
            //    $event.stopPropagation();
            //    $event.preventDefault();
            //    return;
            //}

            var doc =
                {
                    Id: -1,
                    VehicleId: $scope.selectedVehicleList,
                    createdById: -1,//($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id,
                    UpdatedById: -1,//($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id,
                    FromDate: null,
                    ToDate: null,                   

                    docTypeId: ($scope.assetDoc == null) ? null : $scope.assetDoc.docType.Id,
                    docType: ($scope.assetDoc == null) ? null : $scope.assetDoc.docType.Name,//
                    docName: files[0].name,
                    docContent: result,

                    expiryDate: ($scope.assetDoc == null || $scope.assetDoc.expiryDate == null) ? null : getdate($scope.assetDoc.expiryDate),
                    dueDate: ($scope.assetDoc == null || $scope.assetDoc.dueDate == null) ? null : getdate($scope.assetDoc.dueDate),
                    insupddelflag: 'I'
                }

            $scope.modifiedDoc = doc;
            ////check if already the file exists                       
            //for (cnt = 0; cnt < $scope.currobj.files1.length; cnt++) {
            //    if ($scope.currobj.files1[cnt].docName == files[0].name) {
            //        $scope.currobj.files1.splice(cnt, 1);
            //    }
            //}

            //$scope.currobj.files1.push(doc);
            //if ($scope.DocFiles)
            //{
            //    $scope.DocFiles.push(doc);
            //}

        });
    };

    /*save job documents */
    $scope.SaveAssetDoc = function () {

        if ($scope.modifiedDoc == null) {

            alert('Select an asset document to modify.');
            return;
        }
        $scope.modifiedDoc.UpdatedById = ($scope.userdetails.Id == null) ? 1 : $scope.userdetails.Id;
        var req = {
            method: 'POST',
            url: '/api/VehicleMaster/SaveVehicleDoc',
            data: $scope.modifiedDoc
        }
        $http(req).then(function (response) {
            //  $scope.DocFiles = response.data.Table;
            $scope.DocFiles = response.data.Table;
            alert("Saved Successfully");

            $scope.modifiedDoc = null;
            $scope.assetDoc = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.modifiedDoc = null;
            $scope.assetDoc = null;
            $scope.showDialog(errmssg);
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








