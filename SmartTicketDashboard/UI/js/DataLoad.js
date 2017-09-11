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

app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    $scope.compCol = 'CompanyName,Active';
    $scope.compArr = [{"Id":1,"Name":"CompanyName"},
    {"Id":2,"Name":"Active"}]

    $scope.userCol = 'FirstName,LastName,Emailid,Active';
    $scope.UserArr = [{"Id":1,"Name":"FirsName"},
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

    $scope.CardsCol = 'CardNumber,CardCategory';
    $scope.CardsArr = [{ "Id": 1, "CardNumber": "CardCategory" },
                        { "Id": 2, "CardNumber": "CardCategory" }]

    $scope.DriverVehicleAssignCol = 'VechMobileNo,OwnerName,Type'
    $scope.DriverVehicleAssignArr = [{ "Id": 1, "CardNumber": "CardCategory" },
                        { "Id": 2, "CardNumber": "CardCategory" }]

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    //$scope.GetDataLoad = function () {

    //    $http.get('/api/DataLoad/GetDataLoad').then(function (response, req) {
    //        $scope.list = response.data;
    //    });
    //}
    $scope.csv_link = 'DataUploadTemplates/CompanyList.csv';// + $window.location.search;

    $scope.SetOptionSettings = function () {
        switch ($scope.seloption) {
            case "1":
                
                $scope.mandatoryCols = $scope.compCol;
                //  $scope.optionsCols = 'Address,phone,emailid';

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

                    var header = [$scope.seloption];          

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
                        lines.push(GetCompany(data));

                        if (data.length == headers.length) {
                        var tarr = [];
                        for (var j = 0; j < headers.length; j++) {
                            tarr.push(data[j]);
                        }
                        //lines.push(GetCompany(data));
                        }
                    }

                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveCompanyGroups1',
                        data: lines
                    }
                    $http(req).then(function (res) {
                        $scope.initdata = res.data;
                        alert("Saved successfully")
                    });

                     //$scope.logdata = list;
                };


                function GetCompany(data) {

                    var list = {
                        Name: data[0],
                        code: data[1],
                        Description: data[2],
                        Address: data[3],
                        ContactNo1: data[4],
                        ContactNo2: data[5],
                        EmailId: data[6],
                        active: 1,
                        insupdflag: 'I'
                    }
                    return list;
                }

                $scope.save = function () {
                    if (active == null) {
                        return;
                    }
                    if (Name == null) {
                        return;
                    }
                    if (Code == null) {
                        return;
                    }
                    if (Address == null) {
                        return;
                    }
                    if (EmailId == null) {
                        return;
                    }
                    if (ContactNo1 == null) {
                        return;
                    }

                    $http(req).then(function (response) {

                        scope.showDialog("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        // $scope.showDialog(errmssg);
                        alert(errmssg);
                    });

                    //var req = {
                    //    method: 'POST',
                    //    url: '/api/DataLoad/SaveUsersGroup1',
                    //    data: lines
                    //}
                    //$http(req).then(function (res) {
                    //    $scope.initdata = res.data;
                    //});

                    // $scope.logdata = lines;
                };
                break;
            case "2":
                //users
                $scope.mandatoryCols = $scope.userCol;
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
                       alert("Saved successfully")
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
                        lines.push(GetDrivers(data));

                        //if (data.length == headers.length) {
                        //var tarr = [];
                        //for (var j = 0; j < headers.length; j++) {
                        //    tarr.push(data[j]);
                        //}
                        //lines.push(GetDrivers(data));
                        //}
                    }

                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveDriverGroups1',
                        data: lines
                    }
                    $http(req).then(function (res) {
                        $scope.initdata = res.data;
                        //$scope.showdialogue("Saved successfully")
                    });

                    // $scope.logdata = lines;
                };

                function GetDrivers(data) {

                    var list = {
                        NAme: data[0],
                        Address: data[1],
                        City: data[2],
                        Pin: data[3],
                        PAddress: data[4],
                        PCity: data[5],
                        PPin: data[6],
                        OffMobileNo: data[7],
                        PMobNo: data[8],
                        DOB: data[9],
                        DOJ: data[10],
                        BloodGroup: data[11],
                        LicenceNo: data[12],
                        LiCExpDate: data[13],
                        BadgeNo: data[14],
                        BadgeExpDate: data[15],
                        Remarks: data[16],
                        VehicleModelId: data[17],
                        //CompanyId: data[12],

                        flag: 'I'
                    }
                    return list;


                }

                $scope.save = function () {
                    if (Remarks == null) {
                        return;
                    }
                    if (NAme == null) {
                        return;
                    }
                    if (CompanyId == null) {
                        return;
                    }
                    if (Address == null) {
                        return;
                    }
                    if (BloodGroup == null) {
                        return;
                    }
                    if (City == null) {
                        return;
                    }

                    $http(req).then(function (response) {

                        scope.showDialog("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        $scope.showDialog(errmssg);
                        alert(errmssg);
                    });

                    //var req = {
                    //    method: 'POST',
                    //    url: '/api/DataLoad/SaveUsers',
                    //    data: lines
                    //}
                    //$http(req).then(function (res) {
                    //    $scope.initdata = res.data;
                    //});

                    // $scope.logdata = lines;
                };
                break;

            case "10":
                $scope.mandatoryCols = $scope.VehiclesCol;

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

                    var header = [$scope.seloption];


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
                        lines.push(GetVehicles(data));

                        if (data.length == headers.length) {
                        var tarr = [];
                        for (var j = 0; j < headers.length; j++) {
                            tarr.push(data[j]);
                        }
                        //lines.push(GetVehicles(data));
                        }
                        
                    }

                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveVehicleGroups1/',
                        data: lines
                    }
                    $http(req).then(function (res) {
                        $scope.initdata = res.data;
                        alert("Saved successfully")
                        
                    });

                     //$scope.logdata = lines;
                };

                function GetVehicles(data) {

                    var list = {
                        CompanyId: data[0],
                        //VID: data[1],
                        RegistrationNo: data[1],
                        Type: data[2],
                        OwnerName: data[3],
                        ChasisNo: data[4],
                        Engineno: data[5],
                        RoadTaxDate: data[6],
                        InsuranceNo: data[7],
                        InsDate: data[8],
                        PolutionNo: data[9],
                        PolExpDate: data[10],
                        RCBookNo: data[11],
                        RCExpDate: data[12],
                        CompanyVechile: data[13],
                        OwnerPhoneNo: data[14],
                        HomeLandmark: data[15],
                        ModelYear: data[16],
                        DayOnly: data[17],
                        VechMobileNo: data[18],
                        EntryDate: data[19],
                        NewEntry: data[20],
                        VehicleModelId: data[21],
                        ServiceTypeId: data[22],
                        VehicleGroupId: data[23],

                        flag: 'I'

                    }
                    return list;
                }

                $scope.save = function () {
                    if (CompanyId == null) {
                        return;
                    }
                    //if (VID == null) {
                    //    return;
                    //}
                    //if (RegistrationNo == null) {
                    //    return;
                    //}
                    if (Type == null) {
                        return;
                    }
                    if (OwnerName == null) {
                        return;
                    }
                    if (ChasisNo == null) {
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
                        alert(errmssg);
                    });
                };
                break;

            case "11":
                $scope.mandatoryCols = $scope.CardsCol;

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

                    var header = [$scope.seloption];          

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
                        lines.push(GetCards(data));

                        if (data.length == headers.length) {
                            var tarr = [];
                            for (var j = 0; j < headers.length; j++) {
                                tarr.push(data[j]);
                            }
                            //lines.push(GetCards(data));
                        }
                    }
                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveCardsGroup',
                        data: lines
                    }
                    $http(req).then(function (res) {
                        $scope.initdata = res.data;
                        alert("Saved successfully")
                    });

                    //$scope.logdata = list;
                };

                function GetCards(data) {

                    var list = {
                        CardNumber: data[0],
                        CardModel: data[1],
                        CardType: data[2],
                        CardCategory: data[3],
                        StatusId: data[4],
                        UserId: data[5],
                        Customer: data[6],
                        EffectiveFrom: data[7],
                        EffectiveTo: data[8],
                        //active: 1,
                        insupdflag: 'I'
                    }
                    return list;
                }

                $scope.save = function () {
                    if (active == null) {
                        return;
                    }
                    if (CardNumber == null) {
                        return;
                    }
                    if (CardModel == null) {
                        return;
                    }
                    if (CardType == null) {
                        return;
                    }
                 
                    $http(req).then(function (response) {

                        scope.showDialog("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        // $scope.showDialog(errmssg);
                        alert(errmssg);
                    });

                    //var req = {
                    //    method: 'POST',
                    //    url: '/api/DataLoad/SaveUsersGroup1',
                    //    data: lines
                    //}
                    //$http(req).then(function (res) {
                    //    $scope.initdata = res.data;
                    //});

                    // $scope.logdata = lines;
                };
                break;

            case "12":
                $scope.mandatoryCols = $scope.DriverVehicleAssignCol;
                //  $scope.optionsCols = 'Address,phone,emailid';

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

                    var header = [$scope.seloption];

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
                        lines.push(GetDriversVehicleAssign(data));

                        if (data.length == headers.length) {
                            var tarr = [];
                            for (var j = 0; j < headers.length; j++) {
                                tarr.push(data[j]);
                            }
                            //lines.push(GetCompany(data));
                        }
                    }

                    //list
                    var req = {
                        method: 'POST',
                        url: '/api/DataLoad/SaveDriverVehicleAssignGroup',
                        data: lines
                    }
                    $http(req).then(function (res) {
                        $scope.initdata = res.data;
                        alert("Saved successfully")
                    });

                    //$scope.logdata = list;
                };


                function GetDriversVehicleAssign(data) {

                    var list = {
                        CompanyId: data[0],
                        NAme: data[1],
                        Address: data[2],
                        City: data[3],
                        Pin: data[4],
                        PAddress: data[5],
                        PCity: data[6],
                        PPin: data[7],
                        OffMobileNo: data[8],
                        PMobNo: data[9],
                        DOB: data[10],
                        DOJ: data[11],
                        BloodGroup: data[12],
                        LicenceNo: data[13],
                        LiCExpDate: data[14],
                        BadgeNo: data[15],
                        BadgeExpDate: data[16],
                        Remarks: data[17],
                        //Id: data[18],
                        //VID: data[18],
                        RegistrationNo: data[18],
                        Type: data[19],
                        OwnerName: data[20],
                        ChasisNo: data[21],
                        Engineno: data[22],
                        RoadTaxDate: data[23],
                        InsuranceNo: data[24],
                        InsDate: data[25],
                        PolutionNo: data[26],
                        PolExpDate: data[27],
                        RCBookNo: data[28],
                        RCExpDate: data[29],
                        CompanyVechile: data[30],
                        OwnerPhoneNo: data[31],
                        HomeLandmark: data[32],
                        ModelYear: data[33],
                        DayOnly: data[34],
                        VechMobileNo: data[35],
                        EntryDate: data[36],
                        NewEntry: data[37],
                        VehicleModelId: data[38],
                        ServiceTypeId: data[39],
                        VehicleGroupId: data[40],
                        BookingNo: data[41],
                        ReqDate: data[42],
                        ReqTime: data[43],
                        CallTime: data[44],
                        CustomerName: data[45],
                        CusID: data[46],
                        PhoneNo: data[47],
                        AltPhoneNo: data[48],
                        PickupAddress: data[49],
                        LandMark: data[50],
                        PickupPlace: data[51],
                        DropPlace: data[52],
                        Package: data[53],
                        VehicleType: data[54],
                        NoofVehicle: data[55],
                        VechID: data[56],
                        DriverName: data[57],
                        PresentDriverLandMark: data[58],
                        ExecutiveName: data[59],
                        EffectiveDate: data[60],
                        EffectiveTill: data[61],
                        DriverId: data[62],

                        active: 1,
                        inspudflag: 'I'
                    }
                    return list;
                }

                $scope.save = function () {
                    //if (active == null) {
                    //    return;
                    //}
                    //if (Name == null) {
                    //    return;
                    //}
                    //if (Code == null) {
                    //    return;
                    //}
                    if (CustomerName == null) {
                        return;
                    }
                    //if (EmailId == null) {
                    //    return;
                    //}
                    //if (ContactNo1 == null) {
                    //    return;
                    //}

                    $http(req).then(function (response) {

                        scope.showDialog("Saved successfully!!");

                        $scope.data = null;
                        //$scope.GetCompanys();

                    }, function (errres) {
                        var errdata = errres.data;
                        var errmssg = "Your details are incorrect";
                        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                        // $scope.showDialog(errmssg);
                        alert(errmssg);
                    });

                    //var req = {
                    //    method: 'POST',
                    //    url: '/api/DataLoad/SaveUsersGroup1',
                    //    data: lines
                    //}
                    //$http(req).then(function (res) {
                    //    $scope.initdata = res.data;
                    //});

                    // $scope.logdata = lines;
                };
        }
    }

    $scope.downloadTemplate = function () {

        switch ($scope.seloption) {
            case "1":
                $scope.downloadFile('DataUploadTemplates/CompanyList.csv','CompanyList.csv');
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

    $scope.downloadFile = function (fileloc,filename) {
        var downloadLink = angular.element('<a></a>');
        downloadLink.attr('href', fileloc);
        downloadLink.attr('download', filename);
        downloadLink[0].click();
    }

    $scope.saveJSON = function () {       
        var blob = new Blob([$scope.logdata], { type: "application/csv;charset=utf-8;" });
        var downloadLink = angular.element('<a></a>');
        downloadLink.attr('href', window.URL.createObjectURL(blob));
        downloadLink.attr('download', 'CompanyList_log.csv');
        downloadLink[0].click();
    };


    
    //Recent Change
    //function GetUser(data) {

    //    var U = {
    //        Id: ((flag == 'I') ? User.Id : -1),
    //        FirstName: data[1],
    //        LastName: data[2],
    //        MiddleName: data[3],
    //        Email: data[4],
    //        ContactNo1: data[5],
    //        ContactNo2: data[6],
    //        Active: 1,
    //        insupdflag: flag
    //    }
    //    return U;
    //}
    
    //     $scope.save = function () {
    //         if (FirstName == null) {
    //             return;
    //         }
    //         if (LastName == null) {
    //             return;
    //         }
    //         if (MiddleName == null) {
    //             return;
    //         }
    //         if (Email == null) {
    //             return;
    //         }
    //         if (ContactNo1 == null) {
    //             return;   
    //         }
    //         if (ContactNo2 == null) {
    //             return;
    //         }
    //         if (Active == null) {
    //             return;
    //         }
            

    //         $http(req).then(function (response) {

    //            $scope.showDialog("Saved successfully!!");
               
    //             $scope.data = null;
    //             //$scope.GetCompanys();

    //         }, function (errres) {
         
    //         var errdata = errres.data;
    //         var errmssg = "Your details are incorrect";
    //         errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
    //         // $scope.showDialog(errmssg);
     
    //     });

       
    //     }
    //Recent Change
   







});




