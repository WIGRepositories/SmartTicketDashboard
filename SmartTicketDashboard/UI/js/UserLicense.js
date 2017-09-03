var app = angular.module('myApp', ['ngStorage'])

var ctrl = app.controller('Myctrlr', function ($scope, $http, $localStorage) {
    $scope.uname = $localStorage.uname;
    $scope.dashboardDS = $localStorage.dashboardDS;

    /* user details functions */
    $scope.uname = $localStorage.uname;

    $scope.GetLicenses = function () {
        $http.get('/api/GetLicensePayments').then(function (response, req) {
            $scope.Group = response.data;

        });
    }
    $scope.GetCountry = function () {

        $scope.checkedArr = [];
        $scope.uncheckedArr = [];
        $http.get('/api/Users/GetCountry?active=1').then(function (response, req) {
            $scope.Countries = response.data;           
            if ($scope.Countries.length > 0) {
                $scope.ctry = $scope.Countries[0];
                $scope.GetCountry($scope.ctry);
                $scope.checkedArr = $filter('filter')($scope.Countries, { HasOperations: "1" });
                $scope.uncheckedArr = $filter('filter')($scope.Countries, { HasOperations: "0" });
            }
        });
    }
    $scope.GetCompanies = function () {
        $http.get('/api/GetCompanyGroups?userid=-1').then(function (response, data) {
            $scope.Companies = response.data;
        });
    }
     $scope.getUsersnRoles = function () {
        if ($scope.s == null) {
            $scope.cmproles1 = null;
            $scope.cmpUsers1 = null;
            return;
        }
        var cmpId = ($scope.s == null) ? -1 : $scope.s.Id;

        $http.get('/api/Roles/GetCompanyRoles?companyId=' + cmpId).then(function (res, data) {
            $scope.cmproles1 = res.data;
        });

        $http.get('/api/Users/GetUsers?cmpId=' + cmpId).then(function (res, data) {
            $scope.cmpUsers1 = res.data;
        });
    }
});
   
