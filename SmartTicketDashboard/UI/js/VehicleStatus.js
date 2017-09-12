var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    $scope.canShow = ($scope.Roleid == 1 || $scope.roleid == 2 || ($localStorage.uname == 'check check'));

    $scope.GetVehiclelocation = function () {
        $http.get('/api/VehicleStatus/GetVehiclelocation').then(function (res, data) {
            $scope.Vehicleloc = res.data;
        });

    }

    $scope.GetCompanies = function () {

        $http.get('/api/GetCompanyGroups?userid=-1').then(function (res, data) {
            $scope.Companies = res.data;
            $scope.Companies1 = res.data;


            if ($scope.userCmpId != 1) {
                //loop throug the companies and identify the correct one
                for (i = 0; i < res.data.length; i++) {
                    if (res.data[i].Id == $scope.userCmpId) {
                        $scope.cmp = res.data[i];
                        document.getElementById('test').disabled = true;
                        break
                    }
                }
                // $scope.GetFleetOwners();
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
            $scope.showdialogue("Saved successfully")


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
            $scope.GetFleetStaff($scope.s);

        });
    }



    $scope.displocations = function () {
        var maplocations = $scope.locations;

        var map = new google.maps.Map(document.getElementById('gmap_canvas'), {
            zoom: 20,
            center: new google.maps.LatLng(-17.8252, 31.0335), //17.8252° S, 31.0335° E
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


    $scope.getBTPOSMonitoring = function () {
        $http.get('/api/BTPOSMonitoringPage/GetBTPOSMonitoring').then(function (response, data) {
            $scope.BTPOSMonitoring = response.data;

            $scope.locations = response.data;
            $scope.displocations();
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

    var mapOptions = {
        zoom: 8,
        center: new google.maps.LatLng(17.3850, 78.4867),
        mapTypeId: google.maps.MapTypeId.ROADMAP

    }
    $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

    $scope.markers = [];
    $scope.location = [];

    var infoWindow = new google.maps.InfoWindow();

    $http.get('http://localhost:1476/api/DriverStatus/GetDriverlocation').
        success(function (data) {

            $scope.location = data;
            $scope.location.forEach(function (loc) {
                createMarker(loc);
            });

        });
    //---------------
    //var markerIcon = {
    //    url: 'http://image.flaticon.com/icons/svg/252/252025.svg',
    //    scaledSize: new google.maps.Size(80, 80),
    //    origin: new google.maps.Point(0, 0),
    //    anchor: new google.maps.Point(32, 65),
    //    labelOrigin: new google.maps.Point(40, 33)
    //};

    //var markerLabel = 'Cars';
    //var marker = new google.maps.Marker({
    //    map: map,
    //    animation: google.maps.Animation.DROP,
    //    position: markerLatLng,
    //    icon: markerIcon,
    //    label: {
    //        text: markerLabel,
    //        color: "#eb3a44",
    //        fontSize: "16px",
    //        fontWeight: "bold"
    //    }
    //});
    //---------------
    var createMarker = function (loc) {
        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(loc.Latitude, loc.Longitude),
            //title: loc.loc
            //icon: {
            //    path:'http://localhost:1476/UI/images/Indigo-taxi.png'
            //    }
            icon: "/UI/images/Red-2-icon.png"
        });
        marker.content = '<div class="infoWindow"</div>' +'Driver: '+loc.NAme +'<br> Driver Contact No: ' +loc.DriverNo + '<br> Vehicle Model: '+loc.VehicleModelId+ '</div>';;

        google.maps.event.addListener(marker, 'click', function () {
            //infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.setContent(marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);
    };



});
