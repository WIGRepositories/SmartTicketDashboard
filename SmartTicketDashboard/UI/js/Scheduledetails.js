﻿// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'google-maps', 'vsGoogleAutocomplete'])

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.options = {
        types: ['(geocode)'],
        componentRestrictions: { country: 'FR' }
    }

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

    $scope.GetRoutes = function () {
        $http.get('/api/Routes/GetRoutes').then(function (res, data) {
            $scope.routes = res.data;

        });
    }

    $scope.GetRouteDetails = function (route) {
        if (route == null || route.Id == null) {
            //alert('Please select a route.');
            $scope.RouteDetails = [];
            return;
        }
        $http.get('/api/routedetails/getroutedetails?routeid=' + route.Id).then(function (res, data) {
            $scope.RouteDetails = res.data;
            $scope.srcname = $scope.RouteDetails.Table[0].source;
            $scope.destname = $scope.RouteDetails.Table[0].dest;
            $scope.srcLat = $scope.RouteDetails.Table[0].srclat;
            $scope.srcLon = $scope.RouteDetails.Table[0].srclng;
            $scope.destLat = $scope.RouteDetails.Table[0].destlat;
            $scope.destLon = $scope.RouteDetails.Table[0].destlng;

            $scope.getDirections();
        });

    }

    $scope.GetScheduleDetails = function () {

        //$scope.Schedulelist = parseLocation(window.location.search)['Id'];
        $http.get('/api/Schedule/GetScheduleTiming?Id=' + $scope.r.Id).then(function (res, data) {
            $scope.sclist = res.data;


            for (i = 0; i < $scope.routes.length; i++) {
                if ($scope.routes[i].Id == $scope.sclist[0].SDId) {
                    $scope.st = $scope.routes[i];
                    break;
                }
            }
          
            $scope.pickupPoint = $scope.sclist[0].StopName;
            $scope.scddetails.ArrivalTime = $scope.sclist[0].ArrivalTime;
            $scope.scddetails.DepartureTime = $scope.sclist[0].DepatureTime;

            //$scope.getDirections();


        });

    }

    $scope.map = {
        control: {},
        center: {
            latitude: 17.3850,
            longitude: 78.4867
        },
        zoom: 16
    };
    $scope.distval = 0;



    var directionsDisplay = new google.maps.DirectionsRenderer();
    var directionsService = new google.maps.DirectionsService();
    var geocoder = new google.maps.Geocoder();


    $scope.getDirections = function () {
        //get the source latitude and longitude
        //get the target latitude and longitude
        $scope.srcLat = $scope.pickupPoint.place.geometry.location.lat();
        $scope.srcLon = $scope.pickupPoint.place.geometry.location.lng();
        //$scope.destLat = $scope.dropPoint.place.geometry.location.lat();
        //$scope.destLon = $scope.dropPoint.place.geometry.location.lng();

        $scope.srcName = $scope.pickupPoint.place.name;
        // $scope.destName = $scope.dropPoint.place.name;
        //alert($scope.dropPoint.place.geometry.location.lat);
        var request = {
            origin: new google.maps.LatLng($scope.srcLat, $scope.srcLon),//$scope.directions.origin,
            //destination: new google.maps.LatLng($scope.destLat, $scope.destLon),//$scope.directions.destination,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
                directionsDisplay.setMap($scope.map);
                // directionsDisplay.setPanel(document.getElementById('distance').innerHTML += response.routes[0].legs[0].distance.value + " meters");

                $scope.distval = response.routes[0].legs[0].distance.value / 1000;
                $scope.distText = $scope.distval + " KM";

                //response.routes[0].bounds["f"].b
                //17.43665
                //response.routes[0].bounds["b"].b
                //78.41263000000001


                //response.routes[0].bounds["f"].f
                //17.45654
                //response.routes[0].bounds["b"].f
                //78.44829                

                //$scope.srcLat = response.routes[0].bounds["f"].b;
                //$scope.srcLon = response.routes[0].bounds["b"].b;
                //$scope.destLat = response.routes[0].bounds["f"].f;
                //$scope.destLon = response.routes[0].bounds["b"].f;              

                //$scope.directions.showList = true;
            } else {
                alert('Google route unsuccesfull!');
            }


        });
        $scope.location();

    }


    $scope.saveNew = function (scdetails, flag) {

        if (scdetails == null) {
            alert('Please Enter Details');
            return;
        }
        if ($scope.rt.Id == null) {
            alert('Please Enter Route');
            return;
        }
        //if (scdetails.srcname == null) {
        //    alert('Please Enter Source');
        //    return;
        //}
        if (scdetails.ArrivalTime == null) {
            alert('Please Enter Arrival Time');
            return;
        }
        if (scdetails.DepartureTime == null) {
            alert('Please Enter Departure Time');
            return;
        }


        var scdlist = {

            flag: 'I',
            Id: -1,
            StopName: $scope.pickupPoint.place.name,
            ArrivalTime: scdetails.ArrivalTime,
            DepartureTime: scdetails.DepartureTime,
            SDId: $scope.rt.Id
        }

        var req = {
            method: 'POST',
            url: '/api/Schedule/ScheduleTimings',
            data: scdlist
        }
        $http(req).then(function (response) {

            var res = response.data;
            alert("Saved Successfully")
            $scope.GetSchedulelist();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.scdlist = null;

    $scope.Save = function (scdlist, flag) {

        if (scdlist == null) {
            alert('Please Enter Details');
            return;
        }
        if ($scope.srcName == null) {
            alert('Please Enter Source');
            return;
        }

        if ($scope.destName == null) {
            alert('Please Enter Destination');
            return;
        }
        if ($scope.vm.Id == null) {
            alert('Please Enter Vehicle Group');
            return;
        }
        if ($scope.vt.Id == null) {
            alert('Please Enter Vehicle Type');
            return;
        }
        if (scdlist.s == null) {
            alert('Please Enter Status');
            return;
        }


        var dd = {

            flag: 'U',
            Id: $scope.scdlist.Id,
            Src: $scope.srcName,
            Dest: $scope.destName,
            VehicleGroupId: $scope.vm.Id,
            VehicleTypeId: $scope.vt.Id,
            StatusId: scdlist.s,
            CountryId: $scope.ctry.Id,
            Fromdate: scdlist.fromdate,
            Todate: scdlist.todate,
            CountryId: $scope.ctry.Id,
            SrcLat: $scope.srcLat,
            SrcLong: $scope.srcLon,
            DestLat: $scope.destLat,
            DestLong: $scope.destLon



        }

        var req = {
            method: 'POST',
            url: '/api/Schedule/Schedulelist',
            data: dd
        }
        $http(req).then(function (response) {

            var res = response.data;
            alert("Saved Successfully")
            $scope.GetSchedulelist();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.setlistdrivers = function (Dl) {
        $scope.driver = Dl;
        $scope.imageSrc = null;
        document.getElementById('cmpNewLogo').src = "";
        $scope.imageSrc = Dl.photo;
        document.getElementById('uactive').checked = (Dl.Active == 1);
    };

    $scope.clearDriverlist = function () {
        $scope.Dl = null;
        $scope.imageSrc = null;
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
    /*save job documents */

    $scope.GetConfigData = function () {

        var vc = {

            includeStatus: '1',
            includeVehicleGroup: '1',
            includeVehicleType: '1'
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











