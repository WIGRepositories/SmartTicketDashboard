var app = angular.module('myApp1', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

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
  
    $scope.onFileSelect = function (files, $event) {

        //$scope.docfiles = [];
        var ext = files[0].name.split('.').pop();
        fileReader.readAsDataUrl(files[0], $scope, (ext == 'jpg') ? 1 : 4).then(function (result) {

            if (result.length > 2097152) {
                alert('Cannot upload file greater than 2 MB.');
                $event.stopPropagation();
                $event.preventDefault();
                return;
            }

            var book =
                 {
                     Id: -1,                

                     Area: (book.Area),

                     Place: (book.Place),
                     CompanyName: (book.CompanyName),
                     //image: ($scope.book == null || $scope.book.Image == null) ? null : $scope.book.Image,
                     imgcontent: (book.Title),
                     description: (book.Content ),
                     price: (book.PrizeAmount ),
                     AdvertismentAmount: (book.AdvertismentAmount ),//
                     image: files[0].name,
                    

                     AdvertismentDate: (AdvertismentDate ),
                     AdvertismentExpireDate: (book.AdvertismentExpiredDate ),
                     
                    flag: 'I'
                 }           


            //check if already the file exists                       
            for (cnt = 0; cnt < $scope.docfiles.length; cnt++) {
                if ($scope.docfiles[cnt].image == files[0].name) {
                    $scope.docfiles.splice(cnt, 1);
                }
            }


            $scope.docfiles.push(book);
            //if ($scope.DocFiles)
            //{
            //    $scope.DocFiles.push(doc);
            //}

        });
    };

    $scope.saveNew = function (adv, flag) {

        if (adv.CompanyName == null) {
            alert('Please Enter CompanyName');
            return;
        }
        //if (adv.Image == null) {
        //    alert('Please Enter Image');
        //    return;
        //}
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


        var Advertisment = {
            Id: -1,
            CompanyName: adv.CompanyName,
            Image: adv.Image,
            AdvertisementTitle: adv.Title,
            Description: adv.Description,
            Clarification: adv.Clarification,
            Conclusion: adv.Conclusion,
            AdvertismentDate: adv.AdvertismentDate,
            AdvertismentExpiredDate: adv.AdvertismentExpiredDate,
            PrizeAmount: adv.PrizeAmount,
            AdvertismentAmount: adv.AdvertismentAmount,
           
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

        var req = {
            method: 'POST',
            url: '/api/Advertisment/Advertismentsectionone',
            data: $scope.docfiles
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
});