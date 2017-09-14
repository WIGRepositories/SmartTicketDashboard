var app = angular.module('plunker', ['google-maps']);

app.controller('MainCtrl', function ($scope, $document) {
    // map object
    //---------------------------------
    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            //needvehicleType: '1',

            //needCompanyName: '1',
            needVehicleMake: '1',
            needServiceType: '1',
            needVehicleGroup: '1',
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

    //---------------------------------

    $scope.map = {
        control: {},
        center: {
            latitude: 17.3850,
            longitude: 78.4867
        },
        zoom: 16
    };

    // marker object
    //$scope.marker = {
    //    center: {
    //        latitude: 17.3850,
    //        longitude: 78.4867
    //    }
    //}

    // instantiate google map objects for directions
    var directionsDisplay = new google.maps.DirectionsRenderer();
    var directionsService = new google.maps.DirectionsService();
    var geocoder = new google.maps.Geocoder();

     //directions object -- with defaults
    //$scope.directions = {
    //    origin: "Lampex Electronics Limited, IDA Kukatpally, Hyderabad, Telangana",
    //    destination: "webingate solutions pvt ltd., Erragadda, Hyderabad, Telangana",
    //    showList: false
    // }
   
    // get directions using google maps api

    //--------------------
  
  
       
  
    //--------------------
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
                directionsDisplay.setPanel(document.getElementById('distance').innerHTML += response.routes[0].legs[0].distance.value + " meters");
                ;
                

                $scope.directions.showList = true;
            } else {
                alert('Google route unsuccesfull!');
            }
        });
    }

   
    
    

});

//app.controller('VehicleConfig', function($scope,$http)
//{
//    $scope.GetVehicleConfig = function () {

//        var vc = {
//            // needfleetowners:'1',
//            //needvehicleType: '1',

//            //needCompanyName: '1',
//            needVehicleMake: '1',
//            needServiceType: '1',
//            needVehicleGroup: '1',
//        };

//        var req = {
//            method: 'POST',
//            url: '/api/VehicleConfig/VConfig',
//            //headers: {
//            //    'Content-Type': undefined

//            data: vc


//        }
//        $http(req).then(function (res) {
//            $scope.initdata = res.data;
//        });

//    }
//})


    