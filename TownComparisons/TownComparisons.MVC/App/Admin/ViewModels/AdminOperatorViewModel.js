adminModule.controller("adminOperatorViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper, Upload) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.adminService = adminService;

    $scope.categoryId = $routeParams.categoryId;
    $scope.operatorId = $routeParams.operatorId;
    $scope.validationErrors = [];
    $scope.knownValidationErrors = [];
    $scope.closeValidationAlert = false;

    var initialize = function () {
        refreshOperator();
    }

    var refreshOperator = function () {
        viewModelHelper.apiGet('api/category/' + $scope.categoryId + '/operator/' + $scope.operatorId, null,
            function (result) {
                console.log(result.data);
                $scope.operator = result.data;
            });
    }

    $scope.saveOperator = function () {


        viewModelHelper.apiPost('api/admin/category/' + $scope.categoryId + '/operator/' + $scope.operatorId, $scope.operator,
            function (result) {
                //success
                console.log(result.data);
            },
            function (errors) {
                //failure
                adminService.parseErrors(errors);
            });
    }

    $scope.saveOperatorImage = function (imageFile) {

        console.log(imageFile);
        $scope.upload = Upload.upload({
            url: MyApp.rootPath + 'api/admin/category/' + $scope.categoryId + '/operator/' + $scope.operatorId + '/image', // webapi url
            method: "POST",
            //data: { fileUploadObj: $scope.fileUploadObj },
            file: imageFile
        }).progress(function (evt) {
            // get upload percentage
            console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
        }).success(function (data, status, headers, config) {
            // file is uploaded successfully
            console.log(data);
        }).error(function (data, status, headers, config) {
            // file failed to upload
            console.log(data);
        });

        /*
        viewModelHelper.apiPost('api/admin/category/' + $scope.categoryId + '/operator/' + $scope.operatorId + '/image', $scope.imageFile,
            function (result) {
                //success
                console.log(result.data);
            },
            function (errors) {
                //failure
                adminService.parseErrors(errors);
            });
            */
    }

    initialize();
});
