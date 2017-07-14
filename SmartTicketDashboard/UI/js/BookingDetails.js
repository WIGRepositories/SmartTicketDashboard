// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap'])
var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;


    $scope.GetBookingHistory = function () {
        $http.get('/api/BookAVehicle/GetBookingHistory?PhoneNo=').then(function (res, data) {
            $scope.book = res.data;
        });
    }
   
    $scope.save = function (book) {
        if (book == null) {
            alert('Please Enter Name');
            return;
        }
        if (book.BookingType == null) {
            alert('Please Enter BookingType');
            return;
        }
        if (book.ReqVehicle == null) {
            alert('Please Enter ReqVehicle');
            return;
        }
        if (book.Customername == null) {
            alert('Please Enter Customername');
            return;
        }
        if (book.CusID == null) {
            alert('Please Enter CusID');
            return;
        }
        if (book.PhoneNo == null) {
            alert('Please Enter PhoneNo');
            return;
        }
        if (book.AltPhoneNo == null) {
            alert('Please Enter AltPhoneNo');
            return;
        }
        if (book.CAddress == null) {
            alert('Please Enter CAddress');
            return;
        }
        if (book.PickupAddress == null) {
            alert('Please Enter PickupAddress');
            return;
        }
        if (book.LandMark == null) {
            alert('Please Enter LandMark');
            return;
        }
        if (book.Package == null) {
            alert('Please Enter Package');
            return;
            if (book.PickupPalce == null) {
                alert('Please Enter PickupPalce');
                return;
            }
            if (book.DropPalce == null) {
                alert('Please Enter DropPalce');
                return;
            }
            if (book.ReqType == null) {
                alert('Please Enter ReqType');
                return;
            }
            if (book.ExtraCharge == null) {
                alert('Please Enter ExtraCharge');
                return;
            }
            if (book.NoofVehicle == null) {
                alert('Please Enter NoofVehicle');
                return;
            }
            if (book.ExecutiveName == null) {
                alert('Please Enter ExecutiveName');
                return;
            }
            if (book.VID == null) {
                alert('Please Enter VID');
                return;
            }
            if (book.BookingStatus == null) {
                alert('Please Enter BookingStatus');
                return;
            }
            if (book.CustomerSMS == null) {
                alert('Please Enter CustomerSMS');
                return;
            }
            if (book.CancelReason == null) {
                alert('Please Enter CancelReason');
                return;
            }
            if (book.CBNo == null) {
                alert('Please Enter CBNo');
                return;
            }
           
            if (book.ModifiedBy == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.CancelBy == null) {
                alert('Please Enter CancelBy');
                return;
            }

            if (book.ReconfirmedBy == null) {
                alert('Please Enter ReconfirmedBy');
                    return;
                }
            if (book.AssignedBy == null) {
                alert('Please Enter AssignedBy');
                    return;
                }
            if (book.latitude == null) {
                alert('Please Enter latitude');
                    return;
                }
            if (book.longitude == null) {
                alert('Please Enter longitude');
                    return;
                }

            
        }

        var book = {
            flag:'I',
            Id: -1,
            BNo: book.BNo,
            BookingType: book.BookingType,
            ReqVehicle: book.ReqVehicle,
            Customername: book.Customername,
            CusID: book.CusID,
            PhoneNo: book.PhoneNo,
            AltPhoneNo: book.AltPhoneNo,
            CAddress: book.CAddress,
            PickupAddress: book.PickupAddress,
            LandMark: book.LandMark,
            Package: book.Package,
            PickupPalce: book.PickupPalce,
            DropPalce: book.DropPalce,
            ExtraCharge: book.ExtraCharge,
            NoofVehicle: book.NoofVehicle,
            ExecutiveName: book.ExecutiveName,
            VID: book.VID,
            BookingStatus: book.BookingStatus,
            CustomerSMS: book.CustomerSMS,
            CancelReason: book.CancelReason,
            CBNo: book.CBNo,
            ModifiedBy: book.ModifiedBy,
            CancelBy: book.CancelBy,
            ReconfirmedBy: book.ReconfirmedBy,
            AssignedBy: book.AssignedBy,
            latitude: book.latitude,
            longitude: book.longitude,

            

            insupdflag: "I"
        }

        var req = {
            method: 'POST',
            url: '/api/BookAVehicle/booking',
            data: book
        }
        $http(req).then(function (response) {

            alert("Saved successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your Details Are Incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

   


    $scope.saveupd = function (book) {
        if (book == null) {
            alert('Please Enter Name');
            return;
        }
        if (book.BookingType == null) {
            alert('Please Enter Nmae');
            return;
        }
        if (book.ReqVehicle == null) {
            alert('Please Enter Code');
            return;
        }
        if (book.Customername == null) {
            alert('Please Enter Code');
            return;
        }
        if (book.CusID == null) {
            alert('Please Enter Code');
            return;
        }
        if (book.PhoneNo == null) {
            alert('Please Enter Code');
            return;
        }
        if (book.AltPhoneNo == null) {
            alert('Please Enter Code');
            return;
        }
        if (book.CAddress == null) {
            alert('Please Enter Code');
            return;
        }
        if (book.PickupAddress == null) {
            alert('Please Enter Code');
            return;
        }
        if (book.LandMark == null) {
            alert('Please Enter Code');
            return;
        }
        if (book.Package == null) {
            alert('Please Enter Code');
            return;
            if (book.PickupPalce == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.DropPalce == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.ExtraCharge == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.NoofVehicle == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.ExecutiveName == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.VID == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.BookingStatus == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.CustomerSMS == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.CancelReason == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.CBNo == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.Code == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.ModifiedBy == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.CancelBy == null) {
                alert('Please Enter Code');
                return;
            }

            if (book.ReconfirmedBy == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.AssignedBy == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.latitude == null) {
                alert('Please Enter Code');
                return;
            }
            if (book.longitude == null) {
                alert('Please Enter Code');
                return;
            }


        }

        var book = {
            flag: 'I',
            Id: -1,
            BNo: book.BNo,
            BookingType: book.BookingType,
            ReqVehicle: book.ReqVehicle,
            Customername: book.Customername,
            CusID: book.CusID,
            PhoneNo: book.PhoneNo,
            AltPhoneNo: book.AltPhoneNo,
            CAddress: book.CAddress,
            PickupAddress: book.PickupAddress,
            LandMark: book.LandMark,
            Package: book.Package,
            PickupPalce: book.PickupPalce,
            DropPalce: book.DropPalce,
            ExtraCharge: book.ExtraCharge,
            NoofVehicle: book.NoofVehicle,
            ExecutiveName: book.ExecutiveName,
            VID: book.VID,
            BookingStatus: book.BookingStatus,
            CustomerSMS: book.CustomerSMS,
            CancelReason: book.CancelReason,
            CBNo: book.CBNo,
            ModifiedBy: book.ModifiedBy,
            CancelBy: book.CancelBy,
            ReconfirmedBy: book.ReconfirmedBy,
            AssignedBy: book.AssignedBy,
            latitude: book.latitude,
            longitude: book.longitude,



            insupdflag: "U"
        }

        var req = {
            method: 'POST',
            url: '/api/BookAVehicle/booking',
            data: book
        }
        $http(req).then(function (response) {

          alert("Updated successfully!");

            $scope.Group = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Not Updated";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            $scope.showDialog(errmssg);
        });
        $scope.currGroup = null;
    };

    $scope.book = null;

    $scope.setbook = function (usr) {
        $scope.book1 = usr;
    };

    $scope.clearbook = function () {
        $scope.book1 = null;
    }


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








