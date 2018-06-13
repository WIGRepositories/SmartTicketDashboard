var app = angular.module('plunker', ['google-maps','vsGoogleAutocomplete']);

app.controller('MainCtrl', function ($scope, $document,$http) {

    $scope.options = {
        types: ['(geocode)'],
        componentRestrictions: { country: 'FR' }
    }

    // map object
    //---------------------------------
    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            needvehicleType: '1',
            //needServiceType: '1',
            //needCompanyName: '1',
            needVehicleMake: '1'
            //needVehicleGroup: '1',
            //needDocuments: '1'
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
        });

    }

    $scope.GetConfigData = function () {

        var vc = {
            
            includeVehicleType: '1',
            includeVehicleGroup: '1',
            includeActiveCountry: '1',
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            $scope.ct = $scope.initdata.Table[0];
            $scope.s = $scope.initdata.Table1[0];
        });
    }

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

    $scope.GetPricinglist = function () {
        $scope.DistPricelist = null;

        $scope.selectedprice = parseLocation(window.location.search)['vdpid'];

        $http.get("/api/VehiclePricing/GetPricinglist?vdpid="+$scope.selectedprice).then(function (response, req) {
            $scope.Pricelist = response.data;
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

   
    var directionsDisplay = new google.maps.DirectionsRenderer();
    var directionsService = new google.maps.DirectionsService();
    var geocoder = new google.maps.Geocoder();

    $scope.distval = 0;
    $scope.unitprice = 0;

    $scope.getDirections = function () {
        //get the source latitude and longitude
        //get the target latitude and longitude
        $scope.srcLat = $scope.pickupPoint.place.geometry.location.lat();
        $scope.srcLon = $scope.pickupPoint.place.geometry.location.lng();
        $scope.destLat = $scope.dropPoint.place.geometry.location.lat();
        $scope.destLon = $scope.dropPoint.place.geometry.location.lng();

        $scope.srcName = $scope.pickupPoint.place.name;
        $scope.destName = $scope.dropPoint.place.name;
        //alert($scope.dropPoint.place.geometry.location.lat);
        var request = {
            origin: new google.maps.LatLng($scope.srcLat, $scope.srcLon),//$scope.directions.origin,
            destination: new google.maps.LatLng($scope.destLat, $scope.destLon),//$scope.directions.destination,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
                directionsDisplay.setMap($scope.map.control.getGMap());
                // directionsDisplay.setPanel(document.getElementById('distance').innerHTML += response.routes[0].legs[0].distance.value + " meters");
                
                $scope.distval = response.routes[0].legs[0].distance.value / 1000;
                $scope.distText = $scope.distval+" KM";

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
    }

    $scope.SetTotal = function () {
        $scope.total = eval($scope.unitprice) * eval($scope.distval);
    }
    
    $scope.SavePricing = function (flag) {
        //alert();

        
        var vdpc = {
            Id: -1,
            SourceLoc: $scope.srcName,
            DestinationLoc: $scope.destName,
            SourceLat: $scope.srcLat,
            SourceLng: $scope.srcLon,
            DestinationLat: $scope.destLat,
            DestinationLng: $scope.destLon,
            VehicleGroupId: $scope.vm.Id,
            VehicleTypeId: $scope.vt.Id,
            //PricingTypeId: directions.pricing,
            PricingTypeId: $scope.Pricelist.Pricing,
            Distance: $scope.distval,
            UnitPrice: $scope.Pricelist.UnitPrice,
            Amount: $scope.Pricelist.Amount,
            CountryId: $scope.ctry.Id,
            flag: 'I'
        }

        var req = {
            method: 'POST',
            url: '/api/VehiclePricing/VehicleDistanceConfig',
            data: vdpc
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
});

