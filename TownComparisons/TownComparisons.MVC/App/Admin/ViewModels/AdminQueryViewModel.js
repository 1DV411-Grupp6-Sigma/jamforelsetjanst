adminModule.controller("adminOperatorViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper, Upload, $modalInstance) {

    //$scope.viewModelHelper = viewModelHelper;
    //$scope.adminService = adminService;

    $scope.categoryId = $routeParams.categoryId;
    $scope.operatorId = adminService.selectedOperatorId;
    $scope.validationErrors = [];
    $scope.knownValidationErrors = [];
    $scope.closeValidationAlert = false;

    $scope.objectFields = [{ field: 'Name', title: 'Namn', textarea: false },
                            { field: 'ShortDescription', title: 'Kort beskrivning', textarea: true },
                            { field: 'LongDescription', title: 'Längre beskrivning', textarea: true },
                            { field: 'Address', title: 'Adress', textarea: false },
                            { field: 'Contact', title: 'Kontakt', textarea: false },
                            { field: 'Telephone', title: 'Telefon', textarea: false },
                            { field: 'Email', title: 'E-post', textarea: false },
                            { field: 'Website', title: 'Webbsida', textarea: false },
                            { field: 'OrganisationalForm', title: 'Organisations-form', textarea: false },
                            { field: 'Other', title: 'Övrigt', textarea: true }];

    var initialize = function () {
        refreshOperator();
    }

    var refreshOperator = function () {
        viewModelHelper.apiGet('api/category/' + $scope.categoryId + '/operator/' + $scope.operatorId, null,
            function (result) {
                $scope.operator = result.data;
                $scope.operatorName = angular.copy($scope.operator.Name); //to use without data binding to the category
                $scope.pageHeading = $scope.operatorName;
            });
    }

    $scope.saveOperator = function () {

        viewModelHelper.apiPost('api/admin/category/' + $scope.categoryId + '/operator/' + $scope.operatorId, $scope.operator,
            function (result) {
                //success, close modal
                $modalInstance.close($scope.operator);
            },
            function (errors) {
                //failure
                adminService.parseErrors(errors);
            });
    }

    $scope.saveOperatorImage = function (imageFile) {

        $scope.upload = Upload.upload({
            url: MyApp.rootPath + 'api/admin/category/' + $scope.categoryId + '/operator/' + $scope.operatorId + '/image', // webapi url
            method: "POST",
            file: imageFile
        }).success(function (data, status, headers, config) {
            // file is uploaded successfully
            $scope.operator = data;
        }).error(function (data, status, headers, config) {
            // file failed to upload
            $scope.validationErrors.push({ name: '', message: 'Kunde inte spara bilden.' });
        });
    }

    $scope.cancelEditOperator = function () {
        //close (cancel) modal
        $modalInstance.dismiss('cancel');
    }

    initialize();
});
