﻿// JavaScript source code
var myapp1 = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'google-maps'])

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http, $localStorage, $document) {
   
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    //   $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;
    $scope.markers = [];
    stopsList = [];
    $scope.RouteDetails = [];
   
    $scope.map = {
        control: {},
        center: {
            latitude: 17.3850,
            longitude: 78.4867
        },
        zoom: 16       

    };    
    var directionsDisplay = new google.maps.DirectionsRenderer();
    var directionsService = new google.maps.DirectionsService();
    var geocoder = new google.maps.Geocoder();
    $scope.getDirections = function () {
        var request = {
            origin: $scope.origin,
            destination: $scope.destination,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };

        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
                directionsDisplay.setMap($scope.map.control.getGMap());
                // directionsDisplay.setPanel(document.getElementById('distance').innerHTML += response.routes[0].legs[0].distance.value + " meters");
                $scope.distText = response.routes[0].legs[0].distance.text;
                $scope.distval = response.routes[0].legs[0].distance.value;
                //response.routes[0].bounds["f"].b
                //17.43665
                //response.routes[0].bounds["b"].b
                //78.41263000000001


                //response.routes[0].bounds["f"].f
                //17.45654
                //response.routes[0].bounds["b"].f
                //78.44829                

                $scope.srcLat = response.routes[0].bounds["f"].b;
                $scope.srcLon = response.routes[0].bounds["b"].b;
                $scope.destLat = response.routes[0].bounds["f"].f;
                $scope.destLon = response.routes[0].bounds["b"].f;
                //$scope.directions.showList = true;
            } else {
                alert('Google route unsuccesfull!');
            }
        });
       
    }
    $scope.displocations = function () {
        var maplocations = $scope.locations;

        var map = new google.maps.Map(document.getElementById('gmap_canvas'), {
            zoom: 15,
            center: new google.maps.LatLng(lat, long), //17.8252° S, 31.0335° E
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

    $scope.CenterMap = function () {
        var srclat = $scope.srcLat;
        var srclng = $scope.srcLon;
        var destlat = $scope.destLat;
        var destlng = $scope.destLon;
        //var lat = (event.latitude == null) ? 17.3850 : event.latitude;
        //var long = (event.longitude == null) ? 78.4867 : event.longitude;
        //var lat =  17.3850;
        //var long = 78.4867;
        var mapOptions = {
            zoom: 8,
            center: new google.maps.LatLng(srclat, srclng, destlat, destlng),
            //mapTypeId: google.maps.MapTypeId.ROADMAP
        }

        var map = new google.maps.Map(document.getElementById('map'), mapOptions);
        
        var infoWindow = new google.maps.InfoWindow();

        google.maps.event.addListener(map, 'click', function (event) {
            createMarkerWithLatLon(map, event.latLng);
           
        });
       

       createMarkerWithLatLon(lat, long);
       
        //createMarker(lat,long);
    }
    $scope.CenterMap1 = function () {

        var lat = 17.3850;
        var long = 78.4867;
        var mapOptions = {
            zoom: 8,
            center: new google.maps.LatLng(lat, long),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }

        //$scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

        var infoWindow = new google.maps.InfoWindow();

        google.maps.event.addListener($scope.map, 'click', function (event) {
            createMarkerWithLatLon(loc.lat(), loc.long());

        });


      //  createMarkerWithLatLon(lat, long);

        $scope.MapOptions = {
            center: new google.maps.LatLng($scope.Markers[0].lat, $scope.Markers[0].lng),
            zoom: 8,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
 
        //Initializing the InfoWindow, Map and LatLngBounds objects.
        $scope.InfoWindow = new google.maps.InfoWindow();
        $scope.Latlngbounds = new google.maps.LatLngBounds();
        $scope.Map = new google.maps.Map(document.getElementById("dvMap"), $scope.MapOptions);
 
        //Looping through the Array and adding Markers.
        for (var i = 0; i < $scope.Markers.length; i++) {
            var data = $scope.Markers[i];
            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
 
            //Initializing the Marker object.
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: $scope.Map,
                title: data.title
            });
 
            //Adding InfoWindow to the Marker.
            (function (marker, data) {
                google.maps.event.addListener(marker, "click", function (e) {
                    $scope.InfoWindow.setContent("<div style = 'width:200px;min-height:40px'>" + data.description + "</div>");
                    $scope.InfoWindow.open($scope.Map, marker);
                });
            })(marker, data);
 
            //Plotting the Marker on the Map.
            $scope.Latlngbounds.extend(marker.position);
        }
 
        //Adjusting the Map for best display.
        $scope.Map.setCenter($scope.Latlngbounds.getCenter());
        $scope.Map.fitBounds($scope.Latlngbounds);
  

        //createMarker(lat,long);


    }
    var createMarker = function (lat,long) {
        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(lat,long),
            //title: loc.loc

            icon: marker
        });
        //marker.content = '<div class="infoWindow"</div>' + 'Driver: ' + loc.NAme + '<br> Driver Contact No: ' + loc.DriverNo + '<br> Vehicle Model: ' + loc.VehicleGroupId + '</div>';;

        google.maps.event.addListener(marker, 'click', function () {
            alert();
            infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.setContent(marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);
    };
    var createMarkerWithLatLon = function (map1,latLng) {
        var marker = new google.maps.Marker({
            map: map1,
            position: new google.maps.LatLng(latLng.lat(), latLng.lng()),
            //title: loc.loc

            icon: marker
        });

        //google.maps.event.addListener(marker, 'click', function () {
        //    alert();
        //    infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
        //    infoWindow.setContent(marker.content);
        //    infoWindow.open($scope.map, marker);
        //});

        $scope.markers.push(marker);

        var infowindow = new google.maps.InfoWindow({
            content: 'Latitude: ' + latLng.lat() + '<br>Longitude: ' + latLng.lng()
        });
        infowindow.open(map1, marker);
    };
    $scope.SaveRouteStops = function (directions, flag) {
        if (arrlist.length == 0) {
            alert('Please Select Stops..!')
            return;
        }
        for (var i = 0; i < arrlist.length; i++) {

        }

        var directions = {
            Id: directions.Id,
            SourceLoc: directions.origin,
            DestinationLoc: directions.destination,
            SourceLat: $scope.srcLat,
            SourceLng: $scope.srcLon,
            DestinationLat: $scope.destLat,
            DestinationLng: $scope.destLon,
            VehicleModelId: directions.vm.Id,
            VehicleTypeId: directions.v.Id,
            //PricingTypeId: directions.pricing,
            PricingTypeId: 1,
            Distance: $scope.distval,
            UnitPrice: directions.unitprice,
            Amount: directions.total,
            flag: flag

        };

        var req = {
            method: 'POST',
            url: '/api/VehiclePricing/VehicleDistanceConfig',
            data: directions
        }

        $http(req).then(function (response) {

            alert("Saved successfully!");
            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
    }
    //$scope.GetRoutes = function () {
    //    $http.get('/api/FleetOwnerRouteDetails/GetRoutes').then(function (res, data) {
    //        $scope.routes = res.data;
    //        // GetRouteDetails($scope.routes[0].Id);
    //    });

    //    $http.get('/api/Stops/GetStops').then(function (res, data) {
    //        $scope.Stops = res.data;
    //    });

    //}
    $scope.GetCompanies = function () {

        $http.get('/api/GetCompanyGroups?userid=-1').then(function (res, data) {
            $scope.Companies = res.data;

            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.cmp = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
                    }
                }
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
            $scope.GetFORoutes($scope.s);

        });

        //$http.get('/api/Getfleet').then(function (res, data) {
        //    $scope.fleet = res.data;

        //    if ($scope.userSId != 1) {
        //        loop throug the companies and identify the correct one
        //        for (i = 0; i < res.data.length; i++) {
        //            if (res.data[i].Id == $scope.userSId) {
        //                $scope.s = res.data[i];
        //                document.getElementById('test1').disabled = true;
        //                break
        //            }
        //        }
        //    }
        //    else {
        //        document.getElementById('test1').disabled = false;
        //    }
        //    $scope.getFleetOwnerRoute($scope.s);
        //});
    }

    //$scope.GetFleetOwners = function () {
    //    if ($scope.cmp == null) {
    //        $scope.FleetOwners = null;
    //        return;
    //    }
    //    var vc = {
    //        needfleetowners: '1',
    //        cmpId: $scope.cmp.Id
    //    };

    //    var req = {
    //        method: 'POST',
    //        url: '/api/VehicleConfig/VConfig',
    //        //headers: {
    //        //    'Content-Type': undefined

    //        data: vc


    //    }
    //    $http(req).then(function (res) {
    //        $scope.cmpdata = res.data;
    //    });
    //}


    //This will hide the DIV by default.
    $scope.IsHidden = true;
    $scope.ShowHide = function () {
        //If DIV is hidden it will be visible and vice versa.
        $scope.IsHidden = $scope.IsHidden ? false : true;
    }
  
    $scope.GetFORoutes = function () {


        if ($scope.s == null) {
            $scope.routes = null;
            return;
        }
       
        var vc = {
            needFleetOwnerRoutes: '1',
            fleetownerId: $scope.s.Id
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined

            data: vc


        }
        $http(req).then(function (res) {
            $scope.sdata = res.data;
           // GetRouteDetails1();
        });
    }

    $scope.GetRouteDetails = function () {
        $scope.RouteDetails = [];
        if ($scope.r == null || $scope.r.RouteId == null) {
            //alert('Please select a route.');
            $scope.RouteDetails = [];
            return;
        }
        $http.get('/api/FleetOwnerRouteDetails/GetFleetOwnerRouteDetails?fleetownerid=' + $scope.s.Id + '&routeid=' + $scope.r.RouteId).then(function (res, data) {
            $scope.RouteDetails = res.data;

            $scope.origin = $scope.RouteDetails.Table[0].source;
            $scope.destination = $scope.RouteDetails.Table[0].dest;
            //$scope.getDirections();
            route($scope.origin, $scope.destination);

        });        
    }

    $scope.SetCurrStop = function (currStop, indx) {
        //alert(currStop.StopName);
        $scope.currStop = currStop;
        currStop.newassigned = currStop.assigned;
        $scope.currStopIndx = indx;
    }

    $scope.save = function () {

        if ($scope.s == null) {         
            return;
        }       

        var stops = $scope.RouteDetails.Table1;

        var fleetownerstops = new Array();
        for (i = 0; i < stops.length; i++) {
            if (stops[i].newassigned != null  && stops[i].assigned != stops[i].newassigned) {
                var item = {
                    "FleetOwnerId": $scope.s.Id,
                    "RouteId": $scope.r.RouteId,
                    "StopId": stops[i].stopid,
                    "insupddelflag": (stops[i].newassigned == "1") ? "I" : "D"
                }
                fleetownerstops.push(item)
            }
        }
       
        if (fleetownerstops.length == 0) return;
        //write the post logic and test
        var req = {
            method: 'POST',
            url: '/api/FleetOwnerRouteDetails/SaveFleetOwnerRouteDetails',
            data: fleetownerstops

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
myapp1.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});