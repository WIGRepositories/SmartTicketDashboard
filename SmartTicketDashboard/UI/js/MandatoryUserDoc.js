var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetConfigData = function () {

        var vc = {
            //includeDocumentType:'1',
            includeActiveCountry: '1',
            includeUserType:'1'
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
           // $scope.checkedArr = $filter('filter')($scope.UserDocs, { Active: "1" });
            // $scope.uncheckedArr = $filter('filter')($scope.UserDocs, { Active: "0" });
            $scope.GetAssignedDocuments();
        });
    }

    $scope.GetAssignedDocuments = function () {

        var ctryId = ($scope.ctry == null || $scope.ctry.Id == null) ? -1 : $scope.ctry.Id;
        var utype = ($scope.utype == null || $scope.utype.Id == null) ? -1 : $scope.utype.Id;
        $http.get('/api/GetMandatoryUserDocs?ctryId=' + ctryId + '&utId=' + utype).then(function (res, data) {
            $scope.doctypes = res.data;
            $scope.checkedArr = $filter('filter')($scope.doctypes, { selected: "1" });
            $scope.uncheckedArr = $filter('filter')($scope.doctypes, { selected: "0" });
           
        });

    }
    $scope.checkedArr = new Array();
    $scope.uncheckedArr = new Array();
    

    $scope.saveUserDoc = function (ctry,utype) {

        var UserDocs = [];
      
        for (var cnt = 0; cnt < $scope.checkedArr.length; cnt++) {
            if ($scope.checkedArr[cnt].selected == 0) {
                var fr = {
                    flag: 'I',
                    Id:-1,
                    CountryId: ctry.Id,
                    UserTypeId: utype.Id,
                    DocTypeId:$scope.checkedArr[cnt].Id
                }
                UserDocs.push(fr);
            }
        }

        for (var cnt = 0; cnt < $scope.uncheckedArr.length; cnt++) {
            if ($scope.uncheckedArr[cnt].selected == 1) {
                var fr = {
                    flag: 'D',
                    Id: -1,
                    CountryId: ctry.Id,
                    UserTypeId: utype.Id,
                    DocTypeId:$scope.checkedArr[cnt].Id
                }
                UserDocs.push(fr);
            }
        }

        $http({
            url: '/api/SaveMandatoryUserDocs',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: UserDocs,

        }).success(function (data, status, headers, config) {
            alert('Documenents details Saved Successfully');

        }).error(function (ata, status, headers, config) {
            alert('Documenents details Not Saved ');
        });
    };

    $scope.toggle = function (item) {
        var idx = $scope.checkedArr.indexOf(item);
        if (idx > -1) {
            $scope.checkedArr.splice(idx, 1);
        }
        else {
            $scope.checkedArr.push(item);
        }

        var idx = $scope.uncheckedArr.indexOf(item);
        if (idx > -1) {
            $scope.uncheckedArr.splice(idx, 1);
        }
        else {
            $scope.uncheckedArr.push(item);
        }
    };

    $scope.exists = function (item, list) {
        if (list == null) return false;
        return list.indexOf(item) > -1;
    };

    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.UserDocs.length;
    };

});