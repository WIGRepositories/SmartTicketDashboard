var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap']);
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {    
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;
    $scope.canShow = ($scope.Roleid == 1 || $scope.roleid == 2 || ($localStorage.uname == 'check check'));
  //  $scope.dashboardDS = $localStorage.dashboardDS;


    //if ($localStorage.userdetails && $localStorage.userdetails.length > 0 && $localStorage.userdetails[0])
    //$scope.userid = $localStorage.userdetails[0].userid;

    //now call GetDashboardDetails and pass userid as parameter


    $scope.GetFleetDetails = function () {

        if ($scope.cmp == null) {
            $scope.cmpdata = null;
            return;
        }

        if ($scope.s == null) {
            $scope.Fleet = null;
            return;
        }

        $http.get('/api/Fleet/getFleetList?cmpId=' + $scope.cmp.Id + '&fleetOwnerId=' + $scope.s.Id).then(function (res, data) {
            $scope.Fleet = res.data.Table;
        });
    }

    $scope.GetCompanies = function () {

        var vc = {
            needCompanyName: '1'
        };

        var req = {
            method: 'POST',
            url: '/api/VehicleConfig/VConfig',
            //headers: {
            //    'Content-Type': undefined
            data: vc
        }
        $http(req).then(function (res) {
            //$scope.initdata = res.data;
            $scope.companies = res.data;
        });

    }

    $scope.GetFleetOwners = function () {
        if ($scope.cmp == null) {
            $scope.cmpdata = null;
            $scope.Fleet = null;
            return;
        }
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
            $scope.cmpdata = res.data.Table;
        });
    }

    $scope.GetVehicleConfig = function () {

        var vc = {
            // needfleetowners:'1',
            needvehicleType: '1',
            needServiceType: '1',
            needvehiclelayout: '1',
            needCompanyName: '1'
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

    $scope.displocations = function (){
        var maplocations = $scope.locations;

                   var map = new google.maps.Map(document.getElementById('gmap_canvas'), {
                       zoom: 15,
                       center: new google.maps.LatLng(-17.8252, 31.0335), //17.8252� S, 31.0335� E
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
  

    $scope.GetDashboardDS = function ()
    {
        //retive the userid and roleid
        var roleid = $localStorage.userdetails[0].roleid;

        $http.get('/api/dashboard/getdashboard?userid=-1&roleid=' + roleid).then(function (res, data)
        {
            $scope.dashboardDS = res.data;
            $localStorage.dashboardDS = res.data;
        });
    }
    $scope.myVar = false;
    $scope.toggle = function () {
        $scope.myVar = !$scope.myVar;
        document.getElementById('btposstatus').innerHTML = ($scope.myVar) ? "Hide" : "Show";
    };
    $scope.show = function () {
        
    }

    $scope.GetInventoryItems = function () {
        $scope.Group = null;
        $http.get('/api/InventoryItem/GetInventoryItem?subCatId=1').then(function (response, req) {
            $scope.InventoryItem = response.data;

        });
    }

    $scope.savepurchases = function (Group) {
        if (Group == null) {
            alert('please select Item')
            return;
        }
        if (Group.Item.ItemName == null) {
            alert('please enter Item name')
            return;
        }
        if (Group.PerUnitPrice == null) {
            alert('please enter the Per Unit Price');
            return;
        }
        if (Group.Quantity == null) {
            alert('please enter the quantity');
            return;
        }
        if (Group.PurchaseOrderNumber == null) {
            alert('please enter Purchase Order Number');
            return;
        }

        if (Group.PurchaseDate == null) {
            alert('please enter the purchase order date');
            return;
        }
        var Group = {
            Id: -1,
            ItemName: Group.Item.ItemName,
            subCategoryId: Group.Item.SubCategoryId,
            Quantity: Group.Quantity,
            PerUnitPrice: Group.PerUnitPrice,
            PurchaseDate: Group.PurchaseDate,
            PurchaseOrderNumber: Group.PurchaseOrderNumber,
            ItemTypeId: Group.Item.Id
        }

        var req = {
            method: 'POST',
            url: '/api/InventoryPurchase/SaveInventoryPurchases',
            data: Group
        }
        $http(req).then(function (response) {

            $scope.showDialog("Saved successfully! ");

            $scope.Group = null;
          //  $scope.FirstPage();

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
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
    $scope.cities = [];

    var infoWindow = new google.maps.InfoWindow();

    $http.get('http://localhost:1476/api/Tracking/GetLatLongHistory').
        success(function (data) {

            $scope.cities = data;
            $scope.cities.forEach(function (city) {
                createMarker(city);
            });

        });

    var createMarker = function (city) {
        var marker = new google.maps.Marker({
            map: $scope.map,
            position: new google.maps.LatLng(city.Latitude, city.Longitude),
            title: city.city

        });
        marker.content = '<div class="infoWindowContent">' + city.description + '</div>';

        google.maps.event.addListener(marker, 'click', function () {
            infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
            infoWindow.open($scope.map, marker);
        });

        $scope.markers.push(marker);
    };

});
$(document).ready(function () {
    // add button style 
    $("[name='poll_bar'").addClass("btn btn-default");
    // Add button style with alignment to left with margin.
    $("[name='poll_bar'").css({ "text-align": "left", "margin": "5px" });

    //loop 
    $("[name='poll_bar'").each(
            function (i) {
                //get poll value 	
                var bar_width = (parseFloat($("[name='poll_val'").eq(i).text()) / 2).toString();
                bar_width = bar_width + "%"; //add percentage sign.										
                //set bar button width as per poll value mention in span.
                $("[name='poll_bar'").eq(i).width(bar_width);

                //Define rules.
                var bar_width_rule = parseFloat($("[name='poll_val'").eq(i).text());
                if (bar_width_rule >= 50) { $("[name='poll_bar'").eq(i).addClass("btn btn-sm btn-success") }
                if (bar_width_rule < 50) { $("[name='poll_bar'").eq(i).addClass("btn btn-sm btn-warning") }
                if (bar_width_rule <= 10) { $("[name='poll_bar'").eq(i).addClass("btn btn-sm btn-danger") }

                //Hide dril down divs
                $("#" + $("[name='poll_bar'").eq(i).text()).hide();
            });

    //On click main menu bar show its particular detail div.
    $("[name='poll_bar'").click(function () {
        //Hide all 
        $(".panel-body").children().hide();
        //Display only selected bar texted div sub chart.
        $("#" + $(this).text()).show();
        //If not inner drill down sub detail found then move to main menu.
        if ($("#" + $(this).text()).length == 0) {
            $("#Main").show();
        }
    });
});
//var myApp = angular.module('myApp', []);
//myApp.controller('mainCtrl', ['$scope', function ($scope) {

//     Set the default value of inputType
//    $scope.inputType = 'password';

//     Hide & show password function
//    $scope.hideShowPassword = function () {
//        if ($scope.inputType == 'password')
//            $scope.inputType = 'text';
//        else
//            $scope.inputType = 'password';
//    };

//}]);






