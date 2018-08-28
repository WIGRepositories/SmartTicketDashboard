
// JavaScript source code
// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularjs-dropdown-multiselect'])



app.directive('onFinishRender', function ($timeout) {

    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            if (scope.$last === true) {
                $timeout(function () {
                    scope.$emit('ngRepeatFinished');
                });
            }
        }
    }
});


var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $filter) {
    //if ($localStorage.uname == null) {
    //    window.location.href = "login.html";
    //}
    //$scope.uname = $localStorage.uname;
    //$scope.userdetails = $localStorage.userdetails;
    //$scope.Roleid = $scope.userdetails[0].roleid;
    //$scope.isAdmin = ($scope.Roleid == 1) ? 1 : 0;
    $scope.dropdownSettings = {
        idProperty:"id",
        checkBoxes: false,
        styleActive: true,
        smartButtonMaxItems: 3
    }
    

    //$scope.isSuperUser = ($scope.Roleid == 2) ? 2 : 0;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $http.get('/api/Objects/getRootObjects').then(function (res, data) {
        $scope.RootObjects = res.data;
    });


    //$scope.options = function () {
    //    $http.get('/api/Roles/getroles').then(function (response, data) {
    //        $scope.roles = response.data;
    //    });
    //}
    
    $scope.objectsAccesses = [];
    $scope.options = [];
    
   // $http.get('/api/Types/GetTypes?TypeGroupId=31').then(function (data) {        
     //     angular.forEach(data.data, function (value, index) {
       //       $scope.objectsAccesses.push({ id: value.TypeGroupId, label: value.Name });
         // });
        //});
    
    $http.get('/api/Objects/getObjAccsess?TypeGroupId=36').then(function (res, data) {
        // res.data;
        for (ol = 0; ol < res.data.length; ol++) {
            $scope.options.push({ id: res.data[ol].ID, label: res.data[ol].Name });
        }
    });

   
      

    $scope.getChildObject = function () {
        $http.get('/api/Objects/getChildObjects?RootObjectId=' + $scope.s.Id).then(function (res, data) {
            $scope.childobjects = res.data.Table;
            $scope.objectsAccesses = res.data.Table1;

            for (cnt = 0; cnt < $scope.childobjects.length; cnt++) {

                var accArr = new Array();

                var objAccessList = $filter('filter')($scope.objectsAccesses, { ObjectID: $scope.childobjects[cnt].Id });

                for (ac = 0; ac < objAccessList.length; ac++) {

                $scope.objectsAccesses[ac].options = new Array();

                    var acc = {
                        id: objAccessList[ac].TypeId,
                        label: objAccessList[ac].Name
                    }
                   accArr.push(acc);                    
               }               
             $scope.childobjects[cnt].test = accArr;
            }
           

        });
    }





$scope.processData1 = function (a) {
      
   

    var headers = a;

    //var header = [$scope.seloption];                  
    var lines = [];

    for (var i = 1; i < headers.length; i++) {
        // split content based on comma
        var data = headers[i];
        if (data == '' || data == null) continue;
        lines.push(list33(data));

        if (data.length == headers.length) {
            var tarr = [];
            for (var j = 0; j < headers.length; j++) {
                tarr.push(data[j]);
            }
            //lines.push(GetVehicles(data));
        }
    }

    //list
    var req = {
        method: 'POST',
        url: '/api/Objects/saveobj',
        data: lines
    }
    $http(req).then(function (res) {
        $scope.initdata = res.data;                        
        alert("Saved successfully");

    }, function (errres) {
        var errdata = errres.data;
        var errmssg = "Your details are incorrect";
        errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
        alert(errmssg);
        alert(errmssg);
    });
                
    //$scope.logdata = lines;
};

              
     



$scope.processData = function (a) {

    //check if any value is selected
    //then iterate through the selected values
    //for each value push into arr or create a item
    //add the item to data for saving

    if (a.test.length > 0) {
        $scope.dd = [];

        for (it = 0; it < a.test.length; it++) {
            var objAccess = {
                Id: -1,
                Name: a.Name,
                ObjectId: a.Id,
                TypeId: a.test[it].id,
                flag: 'I'
            }
            $scope.dd.push(objAccess);
        }
    }

        

        //var list = {
        //    flag: 'U',
        //    Id: a.Id,
        //    Name: a.Name,            
        //    RootObjectId: a.RootObjectId,
        //    ParentID: a.ParentID,
        //    ObjectAccessesId: $scope.dd[0].TypeId,
        //    ObjectAccesses: $scope.dd
        //}

        var req = {
            method: 'POST',
            url: '/api/Objects/saveObjAcc',
            data: $scope.dd
        }
        $http(req).then(function (res) {
            $scope.initdata = res.data;
            alert("Saved successfully");

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
            
        });
    
        
}

   
   

    function GetVehicles(data) {

        var list = {
            RegistrationNo: data[0],
            ChasisNo: data[1],
            VehicleGroup: data[2],
            VehicleModel: data[3],
            Country: data[4],
            VehicleCode: data[5],
            FleetOwner: data[6],
            Engineno: data[7],
            VehicleType: data[8],
            VehicleMake: data[9],
            DriverId: data[10],
            ModelYear: data[11],
            HasAC: data[12],
            IsDriverowned: data[13],
            RoadTaxDate: data[14],
            InsDate: data[15],
            PolutionNo: data[16],
            PolExpDate: data[17],
            RCBookNo: data[18],
            RCExpDate: data[19],
            StatusId: data[20],
            IsVerified: data[21],
            EntryDate: data[22],





            flag: 'I'

        }
        return list;
    }
    //    alert($scope.example1model[0].label);
    //}
    $scope.save = function (NewObject, flag) {

        if (NewObject == null) {
            alert('please enter Name');
            return;
        }
        if (NewObject.Name == null) {
            alert('Please Enter Name');
            return;
        }

        if ($scope.p.Id == null) {
            alert('Please Enter ParentId');
            return;
        } 
        if (NewObject.RootObjectId == null) {
            alert('Please Enter RootObjectId');
            return;
        }
        //for (cnt = 0; cnt < $scope.getObjroles.length; cnt++) {
        //    if ($scope.getObjroles[cnt].test.length>0){
            
        //    }

        var SelNewObjects = {
            Name: NewObject.Name,
            Description: NewObject.Description,
            ParentId: $scope.p.Id,
            RootObjectId: NewObject.RootObjectId,
            CreatedOn: NewObject.CreatedOn,
            CreatedBy: NewObject.CreatedBy,
            Access: NewObject.Access,
            flag: 'I',
            Active: 1,



        }

        var req = {
            method: 'POST',
            url: '/api/Objects/saveobj',
            data: SelNewObjects
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currRole = null;
    };



    $scope.newChildObject = function (NewObject) {

        if (NewObject == null) {
            alert('Please enter name.');
            return;
        }

        if (NewObject.Name == null) {
            alert('Please enter name.');
            return;
        }





        var SelNewObjects = {


            Id: -1,
            Name: NewObject.Name,
            Description: NewObject.Description,
            ParentId: NewObject.ParentId,

            Active: 1,
            insupdflag: 'U'
        };

        var req = {
            method: 'POST',
            url: '/api/Objects/saveObjects',
            data: SelNewObjects
        }

        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            alert(errmssg);
        });
        $scope.currRole = null;
    };

    $scope.setCurrRole = function (grp) {
        $scope.currRole = grp;
    };

    $scope.clearCurrRole = function () {
        $scope.currRole = null;

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
    $scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
        //you also get the actual event object
        //do stuff, execute functions -- whatever...
        //alert("ng-repeat finished");
        $("#example-advanced").treetable({ expandable: true }, true);
    });


}

);

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, mssg) {

    $scope.mssg = mssg;
    $scope.ok = function () {
        $uibModalInstance.close('test');
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});





