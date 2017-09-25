var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload']);

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetChargesDiscounts = function () {

        //$scope.selectedChargeslist = parseLocation(window.location.search)['DId'];

        $http.get('/api/GetAllChargesDiscounts').then(function (res, data) {
            $scope.Chargeslist = res.data;

        });
    }

    $scope.AddChargesDiscounts = function (Addcharges,flag) {

        
            //if (Addcharges == null) {
            //    alert('Please Enter Name');
            //    return;
            //}
            //if (Addcharges.EntryDate == null) {
            //    alert('Please Enter EntryDate');
            //    return;
            //}
            //if (Addcharges.VechID == null) {
            //    alert('Please Enter VechID');
            //    return;
            //}
            //if (Addcharges.RegistrationNo == null) {
            //    alert('Please Enter RegistrationNo');
            //    return;
            //}
            //if (Addcharges.DriverName == null) {
            //    alert('Please Enter DriverName');
            //    return;
            //}
            //if (Addcharges.PartyName == null) {
            //    alert('Please Enter PartyName');
            //    return;
            //}
            //if (Addcharges.PickupPlace == null) {
            //    alert('Please Enter PickupPlace');
            //    return;
            //}
            //if (Addcharges.DropPlace == null) {
            //    alert('Please Enter DropPlace');
            //    return;
            //}
            //if (Addcharges.StartMeter == null) {
            //    alert('Please Enter StartMeter');
            //    return;
            //}
            //if (Addcharges.EndMeter == null) {
            //    alert('Please Enter EndMeter');
            //    return;
            //}
            //if (Addcharges.OtherExp == null) {
            //    alert('Please Enter OtherExp');
            //    return;
            //}
            //if (Addcharges.GeneratedAmount == null) {
            //    alert('Please Enter GeneratedAmount');
            //    return;
            //}
            //if (Addcharges.ActualAmount == null) {
            //    alert('Please Enter ActualAmount');
            //    return;
            //}

            //if (Addcharges.ExecutiveName == null) {
            //    alert('Please Enter ExecutiveName');
            //    return;
            //}
            //if (Addcharges.BNo == null) {
            //    alert('Please Enter BNo');
            //    return;
            //}
            //if (Addcharges.DropTime == null) {
            //    alert('Please Enter DropTime');
            //    return;
            //}
            //if (Addcharges.PickupTime == null) {
            //    alert('Please Enter PickupTime');
            //    return;
            //}
            //if (Addcharges.EntryTime == null) {
            //    alert('Please Enter EntryTime');
            //    return;
            //}
     


            var Addcharges = {

                flag: "I",
                Id : Addcharges.Id ,
                EntryDate: Addcharges.EntryDate,
                VechID: Addcharges.VechID,
                RegistrationNo: Addcharges.RegistrationNo,
                DriverName: Addcharges.DriverName,
                PartyName: Addcharges.PartyName,
                PickupPlace: Addcharges.PickupPlace,
                DropPlace: Addcharges.DropPlace,
                StartMeter: Addcharges.StartMeter,
                EndMeter: Addcharges.EndMeter,
                OtherExp: Addcharges.OtherExp,
                GeneratedAmount: Addcharges.GeneratedAmount,
                ActualAmount: Addcharges.ActualAmount,
                ExecutiveName: Addcharges.ExecutiveName,
                BNo: Addcharges.BNo,
                DropTime: Addcharges.DropTime,
                PickupTime: Addcharges.PickupTime,
                EntryTime: Addcharges.EntryTime,


                Active: (Addcharges.Active == true) ? 1 : 0,
            }

            var req = {
                method: 'POST',
                url: '/api/ClosingAddcharges/closerprt',
                data: Addcharges
            }
            $http(req).then(function (response) {

                alert("Saved successfully!");

                $scope.Addchargesors = null;

            }, function (errres) {
                var errdata = errres.data;
                var errmssg = "Your Details Are Incorrect";
                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                $scope.showDialog(errmssg);
            });
            $scope.currGroup = null;
        
    }
});