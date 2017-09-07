// JavaScript source code
// JavaScript source code
var app = angular.module('myApp', ['ngStorage', 'ui.bootstrap', 'angularFileUpload']);
app.directive('file-input', function ($parse) {
    return {
        restrict: "EA",
        template: "<input type='file' />",
        replace: true,
        link: function (scope, element, attrs) {

            var modelGet = $parse(attrs.fileInput);
            var modelSet = modelGet.assign;
            var onChange = $parse(attrs.onChange);

            var updateModel = function () {
                scope.$apply(function () {
                    modelSet(scope, element[0].files[0]);
                    onChange(scope);
                });
            };

            element.bind('change', updateModel);
        }
    };
});

app.directive("ngFileSelect", function () {

    return {

        link: function ($scope, el) {

            el.on('click', function () {

                this.value = '';

            });

            el.bind("change", function (e) {

                $scope.file = (e.srcElement || e.target).files[0];



                var allowed = ["jpeg", "png", "gif", "jpg"];

                var found = false;

                var img;

                img = new Image();

                allowed.forEach(function (extension) {

                    if ($scope.file.type.match('image/' + extension)) {

                        found = true;

                    }

                });

                if (!found) {

                    alert('file type should be .jpeg, .png, .jpg, .gif');

                    return;

                }

                img.onload = function () {

                    var dimension = $scope.selectedImageOption.split(" ");

                    if (dimension[0] == this.width && dimension[2] == this.height) {

                        allowed.forEach(function (extension) {

                            if ($scope.file.type.match('image/' + extension)) {

                                found = true;

                            }

                        });

                        if (found) {

                            if ($scope.file.size <= 1048576) {

                                $scope.getFile();

                            } else {

                                alert('file size should not be grater then 1 mb.');

                            }

                        } else {

                            alert('file type should be .jpeg, .png, .jpg, .gif');

                        }

                    } else {

                        alert('selected image dimension is not equal to size drop down.');

                    }

                };

                //  img.src = _URL.createObjectURL($scope.file);



            });

        }

    };

});

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal, $upload,fileReader) {
    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.dashboardDS = $localStorage.dashboardDS;

    $scope.GetSubCategories = function () {

        $http.get('/api/SubCategory/getsubcategory?catid=6').then(function (response, req) {
            $scope.SubCategory = response.data;
        });
    }

    $scope.GetInventoryItems = function () {

        $http.get('/api/InventoryItem/GetInventoryItem?subCatId=-1').then(function (response, req) {
            $scope.InventoryItems = response.data;
          //  $scope.getselectval();

        });
    }

    //  $scope.getselectval = function (seltype) {
    //    var grpid = (seltype) ? seltype.Id : -1;
    ////to save new inventory item
    //    $http.get('/api/Inventory/getsubcategory?subcatid=1' + grpid).then(function (res, data) {
    //        $scope.Item = res.data;
    //    });
    //  }
    //  $scope.getselectval = function (seltype) {
    //      var grpid = (seltype) ? seltype.Id : -1;
    //      //to save new inventory item
    //      $http.get('/api/Inventory/getsubcategory?catid=6' + grpid).then(function (res, data) {
    //          $scope.Item = res.data;
    //      });
    //  }


      $scope.saveNewItem = function (Item) {
          if (Item == null) {
              alert('Please enter Item Name.');
              return;
          }

          if (Item.ItemName == null) {
              alert('Please enter Item Name.');
              return;
          }
          if (Item.Code == null) {
              alert('please enter Code');
              return;
          }
          if (Item.SubCategory == null) {
              alert('please select subcategory');
              return;
          }
          var Item = {
              Id: -1,
              ItemName: Item.ItemName,
              ItemImage: $scope.imageSrc,
              Code: Item.Code,
              Description: Item.Description,
              Category: 6,// Item.Category.Id,
              SubCategory:Item.SubCategory.Id,
              ReOrderPoint: Item.ReOrderPoint,
              price:Item.price,
              Itemmodel: Item.Itemmodel,
              features:Item.features

          }

          var req = {
              method: 'POST',
              url: '/api/InventoryItem/SaveInventoryItem',
              data: Item
          }
          $http(req).then(function (response) {

            alert("Saved successfully!");

              $scope.Group = null;
              $scope.GetInventoryItems();

          }, function (errres) {
              var errdata = errres.data;
              var errmssg = "Your details are incorrect";
              errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
              alert(errmssg);
          });
          $scope.currGroup = null;
      };

        $scope.save = function (Item) {
            if (Item == null) {
                alert('Please enter Item Name.');
                return;
            }

            if (Item.ItemName == null) {
                alert('Please enter Item Name.');
                return;
            }
            if (Item.Code == null) {
                alert('please enter Code');
                return;
            }
            if (Item.SubCategory == null) {
                alert('please select subcategory');
                return;
            }
            var Item = {
                Id: Item.Id,
                ItemName: Item.ItemName,
                ItemImage: Item.ItemImage,
                Code: Item.Code,
                Description: Item.Description,
                Category: 6,//Item.Category,
                SubCategory: 1,//Item.SubCategory.Id,
                ReOrderPoint: Item.ReOrderPoint,
                price: Item.Price,
                Itemmodel: Item.ItemModel,
                features: Item.Features,
                
            }

            var req = {
                method: 'POST',
                url: '/api/InventoryItem/SaveInventoryItem',
                data: Item
            }
            $http(req).then(function (response) {

              alert("Saved successfully!");

                $scope.Group = null;
                $scope.GetInventoryItems();

            }, function (errres) {
                var errdata = errres.data;
                var errmssg = "Your details are incorrect";
                errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
                alert(errmssg);
            });
          $scope.currGroup = null;
      };
      $scope.Items1 = null;


    $scope.setItem = function (item) {
        $scope.CurrItem = item;        
    };

    $scope.clearItems1 = function () {
        $scope.Items1 = null;
    }

    $scope.UploadImg = function () {
        var fileinput = document.getElementById('fileInput');
        fileinput.click();

        //  
        //if ($scope.file == null)
        //{ $scope.file = fileinput.files[0]; }
        //fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
        //fileReader.onLoad($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    };

    $scope.onFileSelect = function () {
        fileReader.readAsDataUrl($scope.file, $scope).then(function (result) { $scope.imageSrc = result; });
    }

    $scope.clearImg = function () {
        $scope.imageSrc = null;
        document.getElementById('cmpLogo').src = "";
        document.getElementById('cmpNewLogo').src = "";
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