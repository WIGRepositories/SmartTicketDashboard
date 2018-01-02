// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage','ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage,$uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetStops = function () {
        $http.get('/api/Stops/GetStops').then(function (res, data) {
            $scope.Stops = res.data;
        });
    }


    $scope.GetConfigData = function () {

        var vc = {
            includeActiveCountry: '1',     
            

        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            
            //$scope.ctry = $scope.initdata.Table1[0];

        });
    }


    $scope.displocations = function () {
        var maplocations = $scope.locations;

        var map = new google.maps.Map(document.getElementById('gmap_canvas'), {
            zoom: 15,
            center: new google.maps.LatLng(17.499800, 78.399597), //17.8252� S, 31.0335� E
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });


        var infowindow = new google.maps.InfoWindow();


        var marker, i;


        for (i = 0; i < maplocations.length; i++) {
            marker = new google.maps.Marker({
                position: new google.maps.LatLng(maplocations[i]['Xcoordinate'], maplocations[i]['Ycoordinate']),
                map: map
            });


            google.maps.event.addListener(marker, 'click', (function (marker, i) {
                return function () {
                    infowindow.setContent(maplocations[i][0]);
                    infowindow.open(map, marker);
                }
            })(marker, i));
        }

    }

    $scope.saveNewStop = function (newStop) {
        if (newStop == null)
        {
            alert('Please Enter Name');
            return;
        }
        if (newStop.Name == null)
        {
            alert('Please Enter Nmae');
            return;
        }       
        if (newStop.Code == null)
        {
            alert('Please Enter Code');
            return;
        }

        var newStop = {
            Id: -1,
            Name: newStop.Name,
            Description: newStop.Description,
            Code: newStop.Code,
           
            Active: (newStop.Active == true) ? 1 : 0,
          
            insupdflag: "I"
        }

        var req = {
            method: 'POST',
            url: '/api/Stops/saveStops',
            data: newStop
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.Stops1 = null;


    $scope.save = function (Stops, flag) {
        if (Stops == null) {
            alert('Please Enter Name');
            return;
        }
        if (Stops.Name == null) {
            alert('Please Enter Nmae');
            return;
        }
        if (Stops.Code == null) {
            alert('Please Enter Code');
            return;
        }

        var Stops = {
            Id: Stops.Id,
            Name: Stops.Name,
            Description: Stops.Description,
            Code: Stops.Code,

            Active: (Stops.Active == true) ? 1 : 0,


            insupdflag: "U"
        }

        var req = {
            method: 'POST',
            url: '/api/Stops/saveStops',
            data: Stops
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.Stops = null;

    $scope.setStops = function (usr) {
        $scope.Stops1 = usr;
    };

    $scope.clearStops = function () {
        $scope.Stops1 = null;
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

app.controller('mapCtrl', function ($scope, $http) {

    $scope.markers = [];
    $scope.location = [];





    $scope.CenterMap = function (ctry) {
        var lat = (ctry.latitude == null) ? 17.499800 : ctry.latitude;
        var long = (ctry.longitude == null) ? 78.399597 : ctry.longitude;
        var mapOptions = {
            zoom: 15,
            center: new google.maps.LatLng(lat, long),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }

        $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

        var infoWindow = new google.maps.InfoWindow();

        google.maps.event.addListener($scope.map, 'click', function (e) {
            createMarkerWithLatLon(e.latLng.lat(), e.latLng.lng());
            //$scope.lat = e.latLng.lat();
            //$scope.lag = e.latLng.lng();

            //alert("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());
        });
        $http.get('/api/DriverStatus/GetDriverlocation?ctnyId=' + $scope.ctry.Id).then(function (res, data) {
            $scope.currentloc = res.data;

            $scope.currentloc.forEach(function (loc) {
                createMarker(loc);
            });

        });


    }

    var createMarkerWithLatLon = function (lat, long) {
        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(lat, long),
            //title: loc.loc

            icon: marker
        });

        google.maps.event.addListener(marker, 'click', function () {
            alert();
            infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.setContent(marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);
    };

    var createMarker = function (loc) {
        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(loc.Latitude, loc.Longitude),
            //title: loc.loc

            icon: marker
        });
        marker.content = '<div class="infoWindow"</div>' + 'Driver Name: ' + loc.NAme + '<br> Driver Number: ' + loc.DriverNo + '<br> Vehicle Group: ' + loc.VehicleGroupId + '</div>';;

        var infoWindow = new google.maps.InfoWindow();

        google.maps.event.addListener(marker, 'click', function () {

            infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.setContent(marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);
    };



});
 

   




