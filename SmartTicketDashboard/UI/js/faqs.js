var app = angular.module('faqs', ['ngStorage', 'ui.bootstrap']);

var ctrl = app.controller('myCtrl', function ($scope, $http, $localStorage, $uibModal) {

    if ($localStorage.uname == null) {
        window.location.href = "login.html";
    }
    $scope.uname = $localStorage.uname;
    $scope.userdetails = $localStorage.userdetails;
    $scope.userCmpId = $scope.userdetails[0].CompanyId;
    $scope.userSId = $scope.userdetails[0].UserId;
    $scope.Roleid = $scope.userdetails[0].roleid;

    $scope.Getlist = function () {
        $http.get("/api/faqs/Getlist").then(function (response, req) {
            $scope.FAQlist = response.data;
        });
    }

    $scope.saveNew = function (faq, flag) {

        if (faq.AppType == null || faq.AppType =="") {
            alert('Please Select AppType.');
            return;
        }
        if (faq.Category == null || faq.Category=="") {
            alert('Please Select Category.');
            return;
        }
        if (faq.CreatedBy == null || faq.CreatedBy == "") {
            alert('Please Enter name.');
            return;
        }
        if (faq.SubCategory == null || faq.SubCategory == "") {
            alert('Please Select SubCategory.');
            return;
        }
        if (faq.Question == null || faq.Question == "") {
            alert('Please Enter Question.');
            return;
        }
        if (faq.Answer == null || faq.Answer == "") {
            alert('Please Enter Answer.');
            return;
        }
        var faqs = {
            Id: -1,
            flag: 'I',
            AppType: faq.AppType,
            Category: faq.Category,
            SubCategory: faq.SubCategory,
            CreatedBy: faq.CreatedBy,
            Question: faq.Question,
            Answer: faq.Answer
        }
        var req = {
            method: 'POST',
            url: '/api/FAQs/SaveFAQs',
            data: faqs
        }
        $http(req).then(function (response) {

            alert("Saved successfully!!");
            $scope.GetList();
            $scope.newFaq = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            // $scope.showDialog(errmssg);
            alert(errmssg);
        });


        $scope.newFaq = null;
    };

    $scope.save = function (question) {

        if (question.AppType == null || question.AppType == "") {
            alert('Please Select AppType.');
            return;
        }
        if (question.Category == null || question.Category == "") {
            alert('Please Select Category.');
            return;
        }
        if (question.CreatedBy == null || question.CreatedBy == "") {
            alert('Please Enter name.');
            return;
        }
        if (question.SubCategory == null || question.SubCategory == "") {
            alert('Please Select SubCategory.');
            return;
        }
        if (question.Question == null || question.Question == "") {
            alert('Please Enter Question.');
            return;
        }
        if (question.Answer == null || question.Answer == "") {
            alert('Please Enter Answer.');
            return;
        }
        var question = {
            flag: 'U',
            Id: question.Id,
            AppType: question.AppType,
            Category: question.Category,
            SubCategory: question.SubCategory,
            CreatedBy: question.CreatedBy,
            Question: question.Question,
            Answer: question.Answer
        }
        var req = {
            method: 'POST',
            url: '/api/FAQs/SaveFAQs',
            data: question
        }
        $http(req).then(function (response) {

            alert("Updated successfully!!");

            $scope.newFaq = null;

        }, function (errres) {
            var errdata = errres.data;
            var errmssg = "Your details are incorrect";
            errmssg = (errdata && errdata.ExceptionMessage) ? errdata.ExceptionMessage : errdata.Message;
            // $scope.showDialog(errmssg);
            alert(errmssg);
        });


        $scope.newFaq = null;
    };

    $scope.setFAQlist = function (q) {
        $scope.question = q;
    };

    $scope.delete = function (faq, flag) {
        // $scope.q = faq;
        

            var val = {
                Id: faq.Id,
                flag: 'D',
                AppType: faq.AppType,
                Category: faq.Category,
                SubCategory: faq.SubCategory,
                CreatedBy: faq.CreatedBy,
                Question: faq.Question,
                Answer: faq.Answer
            }
        
        var req = {
            method: 'POST',
            url: '/api/FAQs/SaveFAQs',
            data: val
        }
        $http(req).then(function (response) {

            alert("Deleted successfully!!");

            $scope.newFaq = null;

        });

    };

    $scope.clearfaqs = function () {
        $scope.q = null;
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