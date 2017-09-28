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
            $scope.Dl = res.data[0];
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
           // $scope.Dl.CompanyId = $scope.Companies[0];
           
        });
    }

    $scope.GetMaster = function () {
        $http.get('/api/DriverMaster/GetMaster?DId=1').then(function (res, data) {
            $scope.listdrivers = res.data;
        });
       // $scope.imageSrc = $scope.listdrivers.Photo;
    }
    $scope.docfiles = [];

    $scope.saveNew = function (Driverlist,flag) {
      
        
        //if (Driverlist.Id == null) {
        //    alert('Please Enter CompanyId');
        //    return;
        //}
        //if (Driverlist.NAme == null) {
        //    alert('Please Enter NAme');
        //    return;
        //}
        //if (Driverlist.Address == null) {
        //    alert('Please Enter Address');
        //    return;
        //}
        //if (Driverlist.City == null) {
        //    alert('Please Enter City');
        //    return;
        //}
        //if (Driverlist.Pin == null) {
        //    alert('Please Enter Pin');
        //    return;
        //}
        //if (Driverlist.PAddress == null) {
        //    alert('Please Enter PAddress');
        //    return;
        //}
        //if (Driverlist.PCity == null) {
        //    alert('Please Enter PCity');
        //    return;
        //}
        //if (Driverlist.PPin == null) {
        //    alert('Please Enter PPin');
        //    return;
        //}
        //if (Driverlist.OffMobileNo == null) {
        //    alert('Please Enter OffMobileNo');
        //    return;
        //}
        //if (Driverlist.PMobNo == null) {
        //    alert('Please Enter PMobNo');
        //    return;
        //}
        //if (Driverlist.DOB == null) {
        //    alert('Please Enter DOB');
        //    return;
        //}
        //if (Driverlist.DOJ == null) {
        //    alert('Please Enter DOJ');
        //    return;
        //}
        //if (Driverlist.BloodGroup == null) {
        //    alert('Please Enter BloodGroup');
        //    return;
        //}       
       
        

        var Driverlist = {

            flag:'I',
            DId:-1,
            CompanyId: Driverlist.Id,
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
            Remarks: Driverlist.Remarks,            
           // Photo: $scope.imageSrc
        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Driverlist',
            data: Driverlist
        }
        $http(req).then(function (response) {
           
            var res = response.data;
            window.location.href = "DriverDetails.html?DId=" + res[0].DId;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };   

    $scope.Driverlist = null;

    $scope.save = function (Dl,flag) {

        
        if (Dl.CompanyId.Id == null) {
            alert('Please Enter CompanyId');
            return;
        }
        if (Dl.NAme == null) {
            alert('Please Enter NAme');
            return;
        }
        if (Dl.City == null) {
            alert('Please Enter City');
            return;
        }
        if (Dl.Pin == null) {
            alert('Please Enter Pin');
            return;
        }
        if (Dl.PAddress == null) {
            alert('Please Enter PAddress');
            return;
        }
        if (Dl.PCity == null) {
            alert('Please Enter PCity');
            return;
        }
        if (Dl.PPin == null) {
            alert('Please Enter PPin');
            return;
        }
        if (Dl.OffMobileNo == null) {
            alert('Please Enter OffMobileNo');
            return;
        }
        if (Dl.PMobNo == null) {
            alert('Please Enter MobileNo');
            return;
        }
        if (Dl.DOB == null) {
            alert('Please Enter DOB');
            return;
        }
        if (Dl.DOJ == null) {
            alert('Please Enter DOJ');
            return;
        }
        if (Dl.BloodGroup == null) {
            alert('Please Enter BloodGroup');
            return;
        }
       
        if (Dl.Remarks == null) {
            alert('Please Enter Remarks');
            return;
        }



        var driver = {          

            flag: ($scope.selectedlistdrivers == -1)?'I':'U',
            DId: Dl.DId,
            CompanyId: Dl.CompanyId.Id,
            NAme: Dl.NAme,
            Address: Dl.Address1,
            City: Dl.City,
            Pin: Dl.Pin,
            PAddress: Dl.PAddress,
            PCity: Dl.PCity,
            PPin: Dl.PPin,
            OffMobileNo: Dl.OffMobileNo,
            PMobNo: Dl.PMobNo,
            DOB: Dl.DOB,
            DOJ: Dl.DOJ,
            BloodGroup: Dl.BloodGroup,           
            Remarks: Dl.Remarks,
         //   Photo: $scope.imageSrc,
            //licenseimage: $scope.imageSrc,
            //badgeimage: $scope.imageSrc,

        }

        var req = {
            method: 'POST',
            url: '/api/DriverMaster/Driverlist',
            data: driver
        }
        $http(req).then(function (response) {
            var res = response.data;
            window.location.href = "DriverDetails.html?DId="+res[0].DId;

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
    $scope.onFileSelect1 = function () {
        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    }

    $scope.GetVehicleConfig = function () {

        var vc = {
             needfleetowners:'1'//,
            //needvehicleType: '1',
            //needServiceType: '1',
            ////needCompanyName: '1',
            //needVehicleMake: '1',
            //needVehicleGroup: '1',
            //needDocuments: '1'
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
                    DriverId: $scope.selectedlistdrivers,
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
            url: '/api/DriverMaster/SaveDriverDoc',
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









