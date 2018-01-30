// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap',])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetTicketDetails = function () {
        $http.get('/api/TicketGeneration/GetTicketDetails')
        .then(function (res) {
            $scope.TicketDetails = res.data;

        });

        $scope.AddTicket = function () {
            $http.get()
        }
    } 

   
    $scope.save = function (Group) {
        if (Group == null)
        {
            alert('Please enter ticketTypeId ');
            return;
        }
        if (Group.RefId == null) {
            alert('please enter RefId');
            return;
        }
        var Group = {
            RefId: Group.RefId,
            Type: Group.Type,
            CreatedBy: Group.CreatedBy,
            //Id: Group.Id,
            Raised: Group.Raised,
            TicketTitle: Group.TicketTitle,
            IssueDetails: Group.IssueDetails,
            AddInfo: Group.AddInfo,
            Status: Group.Status,
            Asign: Group.Asign,

            // "Id": 1, "Name": "hyioj", "Records": "bfdfsg",
        }

        var req = {
            method: 'POST',
            url: '/api/TroubleTicketingDetails/saveTroubleTicketingDetails',

            data: Group

        }

        $http(req).then(function (response) {
            $scope.currGroup = null;
            $scope.showdialogue("Saved successfully")
        });
    };   

});