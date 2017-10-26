var myapp1 = angular.module('myApp', ['ngStorage'])

var mycrtl1 = myapp1.controller('myCtrl', function ($scope, $http) {
    $scope.lat;
    $scope.lag;
    window.onload = function () {
        var mapOptions = {
            center: new google.maps.LatLng(17.3850, 78.4867),
            zoom: 14,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        var latlngbounds = new google.maps.LatLngBounds();
        var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
        google.maps.event.addListener(map, 'click', function (e) {
           
            $scope.lat = e.latLng.lat();
            $scope.lag = e.latLng.lng();

            alert("Latitude: " + e.latLng.lat() + "\r\nLongitude: " + e.latLng.lng());
        });
    }

    $scope.getmap = function () {

        $scope.lat = e.latLng.lat();
        $scope.lag = e.latLng.lng();
    }

    GMaps.prototype.addMarker = function (options) {
        var marker;
        if (options.hasOwnProperty('gm_accessors_')) {
            // Native google.maps.Marker object
            marker = options;
        }
        else {
            if ((options.hasOwnProperty('lat') && options.hasOwnProperty('lng')) || options.position) {
                marker = this.createMarker(options);
            }
            else {
                throw 'No latitude or longitude defined.';
            }
        }

        marker.setMap(this.map);

        if (this.markerClusterer) {
            this.markerClusterer.addMarker(marker);
        }

        this.markers.push(marker);

        GMaps.fire('marker_added', marker, this);

        return marker;
    };

    GMaps.prototype.addMarkers = function (array) {
        for (var i = 0, marker; marker = array[i]; i++) {
            this.addMarker(marker);
        }

        return this.markers;
    };
    
 });