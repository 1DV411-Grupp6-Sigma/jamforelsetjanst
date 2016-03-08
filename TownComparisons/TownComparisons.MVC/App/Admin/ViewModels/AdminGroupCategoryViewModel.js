adminModule.controller("adminGroupCategoryViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.adminService = adminService;

    $scope.groupCategoryId = $routeParams.groupCategoryId;
    $scope.validationErrors = [];
    $scope.knownValidationErrors = [];
    $scope.closeValidationAlert = false;

    var initialize = function () {
        $scope.categoryHasBeenLoaded = false;
        $scope.pageHeading = 'Laddar in data...';

        getGroupCategory();
    }

    var getGroupCategory = function () {
        viewModelHelper.apiGet('api/admin/groupcategory/' + $scope.groupCategoryId, null,
            function (result) {
                $scope.groupCategory = result.data;
                $scope.categoryName = angular.copy($scope.groupCategory.Name); //to use without data binding to the category
                $scope.pageHeading = 'Grupp-kategori: ' + $scope.categoryName;
                $scope.categoryHasBeenLoaded = true;
            }
        );
    }

    $scope.saveGroupCategory = function () {

        viewModelHelper.apiPost('api/admin/groupcategory/' + $scope.groupCategoryId, $scope.groupCategory,
            function (result) {
                //success
                console.log(result.data);
                viewModelHelper.navigateTo('/admin');
            },
            function (errors) {
                //failure
                adminService.parseErrors(errors);
            });
    }

    $scope.cancelEditCategory = function () {
        viewModelHelper.navigateTo('admin');
    }


    initialize();
});
