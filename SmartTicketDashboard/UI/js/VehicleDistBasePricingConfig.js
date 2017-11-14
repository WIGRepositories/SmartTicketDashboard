var app = angular.module('plunker', ['google-maps']);

app.controller('MainCtrl', function ($scope, $document,$http) {
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
        };

        var req = {
            method: 'POST',
            url: '/api/Types/ConfigData',
            data: vc
        }

        $http(req).then(function (res) {
            $scope.initdata = res.data;
            $scope.ct = $scope.initdata.Table4[0];
            $scope.s = $scope.initdata.Table5[0];
            $scope.r = $scope.initdata.Table[0];
            $scope.GetVehcileList();
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

   
    $scope.getDirections = function () {
        var request = {
            origin: $scope.directions.origin,
            destination: $scope.directions.destination,
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
                $scope.directions.showList = true;
            } else {
                alert('Google route unsuccesfull!');
            }
         
        });
    }

    
    
    $scope.SavePricing = function (directions,flag) {
        //alert();

        
        var directions = {
            Id: directions.Id,
            SourceLoc : directions.origin,
            DestinationLoc: directions.destination,
            SourceLat : $scope.srcLat, 
            SourceLng : $scope.srcLon  ,
            DestinationLat : $scope.destLat,
            DestinationLng :$scope.destLon,
            VehicleGroupId : directions.vm.Id,
            VehicleTypeId : directions.v.Id,
            //PricingTypeId: directions.pricing,
            PricingTypeId:1,
            Distance: $scope.distval,
            UnitPrice:directions.unitprice,
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
});

