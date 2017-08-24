/// <reference path="DataLoad.js" />
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])

app.directive('fileReader', function () {
    return {
        scope: {
            fileReader: "="
        },
        link: function (scope, element) {
            $(element).on('change', function (changeEvent) {
                var files = changeEvent.target.files;
                if (files.length) {
                    var r = new FileReader();
                    r.onload = function (e) {
                        var contents = e.target.result;
                        scope.$apply(function () {
                            scope.fileReader = contents;
                        });
                    };

                    r.readAsText(files[0]);
                }
            });
        }
    };
});

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    $scope.compCol = 'CompanyName,Active';
    $scope.compArr = [{ "Id": 1, "Name": "CompanyName" },
    { "Id": 2, "Name": "Active" }]

    $scope.userCol = 'FirstName,LastName,Emailid,Active';
    $scope.UserArr = [{ "Id": 1, "Name": "FirsName" },
                        { "Id": 2, "Name": "LastName" }]

    $scope.userroleCol = 'FirstName,LastName,Emailid,Role';
    $scope.UserroleArr = [{ "Id": 1, "Name": "FirsName" },
                        { "Id": 2, "Name": "LastName" }]

    $scope.fleetCol = 'VehicleRegno,FleetownerId,Active';
    $scope.fleetArr = [{ "Id": 1, "VehicleRegno": "FleetownerId" },
                        { "Id": 2, "VehicleRegno": "FleetownerId" }]

    $scope.stopCol = 'Name,Code,Active';
    $scope.stopArr = [{ "Id": 1, "Name": "Code" },
                        { "Id": 2, "Name": "Code" }]

    $scope.routesCol = 'RouteName,,Code,Active';
    $scope.routesArr = [{ "Id": 1, "RouteName": "Code" },
                        { "Id": 2, "RouteName": "Code" }]

    $scope.btposCol = 'POSId,FleetOwnerId,StatusId';
    $scope.btposArr = [{ "Id": 1, "POSId": "FleetOwnerId" },
                        { "Id": 2, "POSId": "FleetOwnerId" }]

    $scope.InveCol = 'Name,Category,Active';
    $scope.InveArr = [{ "Id": 1, "Name": "Category" },
                        { "Id": 2, "Name": "Category" }]

    $scope.DriverCol = 'Name,PMobNo,Address';
    $scope.DriverArr = [{ "Id": 1, "NAme": "Address" },
                        { "Id": 2, "NAme": "Address" }]

    $scope.VehiclesCol = 'VechMobileNo,OwnerName,Type';
    $scope.VehiclesArr = [{ "Id": 1, "VechMobileNo": "OwnerName" },
                        { "Id": 2, "VechMobileNo": "OwnerName" }]

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.GetDataLoad = function () {

        $http.get('/api/DataLoad/GetDataLoad').then(function (response, req) {
            $scope.GetDataLoad = response.data;
        });
    }
    $scope.csv_link = 'DataUploadTemplates/Users.csv';// + $window.location.search;

    $scope.SetOptionSettings = function () {
        switch ($scope.seloption) {
            case "1":

                $scope.mandatoryCols = $scope.compCol;
                //  $scope.optionsCols = 'Address,phone,emailid';
                break;
            case "2":
                //users
                $scope.mandatoryCols = $scope.userCol;
                break;
            case "3":
                //User Roles
                $scope.mandatoryCols = $scope.userroleCol;
                break;
            case "4":
                $scope.mandatoryCols = $scope.fleetCol;
                break;

            case "5":
                $scope.mandatoryCols = $scope.stopCol;
                break;

            case "6":
                $scope.mandatoryCols = $scope.routesCol;
                break;

            case "7":
                $scope.mandatoryCols = $scope.btposCol;
                break;

            case "8":
                $scope.mandatoryCols = $scope.InveCol;
                break;

            case "9":
                $scope.mandatoryCols = $scope.DriverCol;
                break;

            case "10":
                $scope.mandatoryCols = $scope.VehiclesCol;
                break;
        }
    }

    $scope.downloadTemplate = function () {

        switch ($scope.seloption) {
            case "1":
                $scope.downloadFile('DataUploadTemplates/CompanyList.csv', 'CompanyList.csv');
                break;
            case "2":
                //users
                $scope.downloadFile('DataUploadTemplates/Users.csv', 'Users.csv');
                break;
            case "3":
                //User Roles
                $scope.downloadFile('DataUploadTemplates/UserRoles.csv', 'UserRoles.csv');
                break;
            case "4":
                $scope.downloadFile('DataUploadTemplates/FleetDetails.csv', 'FleetDetails.csv');
                break;

            case "5":
                $scope.downloadFile('DataUploadTemplates/Stops.csv', 'Stops.csv');
                break;

            case "6":
                $scope.downloadFile('DataUploadTemplates/Routes.csv', 'Routes.csv');
                break;

            case "7":
                $scope.downloadFile('DataUploadTemplates/BtposDetails.csv', 'BtposDetails.csv');
                break;

            case "8":
                $scope.downloadFile('DataUploadTemplates/Inventory.csv', 'Inventory.csv');
                break;

        }
    }

    $scope.downloadFile = function (fileloc, filename) {
        var downloadLink = angular.element('<a></a>');
        downloadLink.attr('href', fileloc);
        downloadLink.attr('download', filename);
        downloadLink[0].click();
    }

    $scope.saveJSON = function () {
        var blob = new Blob([$scope.logdata], { type: "application/csv;charset=utf-8;" });
        var downloadLink = angular.element('<a></a>');
        downloadLink.attr('href', window.URL.createObjectURL(blob));
        downloadLink.attr('download', 'DriversList.csv');
        downloadLink[0].click();
    };



    $scope.importData = function () {
        $scope.processData($scope.fileContent);
    }




    $scope.processData = function (allText) {
        if (allText == null) {
            alert('Please insert file.');
            return;
        }
        // split content based on new line
        var allTextLines = allText.split(/\r\n|\n/);

        var headers = allTextLines[0].split(',');




        //validate header

        //var header = [$scope.seloption];          

        //    switch ($scope.seloption) {
        //        case "1":
        //            //company                                              
        //            $scope.mandatoryCols = $scope.compCol;

        //            alert("Colums are not matching");
        //            if (seloption == "CompanyName")


        //            break;


        //}


        var lines = [];

        for (var i = 1; i < allTextLines.length; i++) {
            // split content based on comma
            var data = allTextLines[i].split(',');
            lines.push(GetUser(data));

            //if (data.length == headers.length) {
            //var tarr = [];
            //for (var j = 0; j < headers.length; j++) {
            //    tarr.push(data[j]);
            //}
            //lines.push(GetCompany(data));
            //}
        }

        //list
        var req = {
            method: 'POST',
            url: '/api/DataLoad/SaveUsersGroup1',
            data: lines
        }
        $http(req).then(function (res) {
            $scope.initdata = res.data;
            //$scope.showdialogue("Saved successfully")
        });

        // $scope.logdata = lines;
    };


    function GetUser(data) {

        var U = {
            
            FirstName: data[0],
            LastName: data[1],
            MiddleName: data[2],
            EmpNo: data[3],
            Email: data[4],
            Address: data[5],
            RoleId: data[6],
            cmpId: data[7],
            ContactNo1: data[8],
            ContactNo2: data[9],
            Active: 1,
            insupdflag: 'I'
        }
        return U;
    }

    $scope.save = function () {
        if (FirstName == null) {
            return;
        }
        if (LastName == null) {
            return;
        }
        if (MiddleName == null) {
            return;
        }
        if (Email == null) {
            return;
        }
        if (ContactNo1 == null) {
            return;
        }
        if (ContactNo2 == null) {
            return;
        }
       

        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!!");

            $scope.data = null;
            //$scope.GetCompanys();

        }, function (errres) {

            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            // $scope.showDialog(errmssg);

        });


    }
   









});


