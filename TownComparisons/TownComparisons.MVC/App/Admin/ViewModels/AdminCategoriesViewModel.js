adminModule.controller("adminCategoriesViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.adminService = adminService;

    var initialize = function () {
        $scope.refreshCategories();
    }

    $scope.refreshCategories = function () {
        viewModelHelper.apiGet('api/categories', null,
            function (result) {
                $scope.categories = result.data;
            });
    }

    $scope.showCategory = function (category) {
        $scope.flags.shownFromList = true;
        viewModelHelper.navigateTo('category/show/' + category.CategoryId);
    }

    initialize();
});
