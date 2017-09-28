﻿var app = angular.module('myApp', ['ngStorage'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $filter) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $http.get('/api/typegroups/gettypegroups').then(function (res, data) {
        $scope.TypeGroups = res.data;
        $scope.getselectval();
    });

    $scope.GetCountries = function () {

        $http.get('/api/Countries/GetCountries').then(function (response, req) {
            $scope.Countries = response.data;

        });
    }

    $scope.getselectval = function (seltype) {
        var grpid = (seltype) ? seltype.Id : -1;

        $http.get('/api/Types/TypesByGroupId?groupid=' + grpid).then(function (res, data) {
            $scope.Types = res.data;

        });

    }

    $scope.saveUserDoc = function (seltype) {

        var countries = [];

        for (var cnt = 0; cnt < $scope.checkedArr.length; cnt++) {
            if ($scope.checkedArr[cnt].HasOperations == 0) {
                var fr = {
                    Id: $scope.checkedArr[cnt].Id,
                    HasOperations: 1
                }
                countries.push(fr);
            }
        }

        for (var cnt = 0; cnt < $scope.uncheckedArr.length; cnt++) {
            if ($scope.uncheckedArr[cnt].HasOperations == 1) {
                var fr = {
                    Id: $scope.uncheckedArr[cnt].Id,
                    HasOperations: 0
                }
                countries.push(fr);
            }
        }

        $http({
            url: '/api/Countries/SaveCountries',
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            data: countries,

        }).success(function (data, status, headers, config) {
            alert('Country details Saved Successfully');

        }).error(function (ata, status, headers, config) {
            alert('Country details NotSaved Successfully');
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

    $scope.toggleAll = function () {
        if ($scope.checkedArr.length === $scope.Countries.length) {
            $scope.uncheckedArr = $scope.checkedArr.slice(0);
            $scope.checkedArr = [];

        } else if ($scope.checkedArr.length === 0 || $scope.Countries.length > 0) {
            $scope.checkedArr = $scope.Countries.slice(0);
            $scope.uncheckedArr = [];
        }

    };

    $scope.exists = function (item, list) {
        return list.indexOf(item) > -1;
    };

    $scope.isChecked = function () {
        return $scope.checkedArr.length === $scope.Countries.length;
    };

});