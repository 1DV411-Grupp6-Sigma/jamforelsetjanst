adminModule.controller("adminOperatorsViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.adminService = adminService;

    var initialize = function () {
        $scope.refreshCategories();
    }

    $scope.refreshCategories = function () {
        viewModelHelper.apiGet('api/categories', null,
            function (result) {
                $scope.groupCategories = result.data;
            });
    }

    $scope.showCategory = function (category) {
        $scope.flags.shownFromList = true;
        viewModelHelper.navigateTo('admin/category/' + category.Id);
    }

    initialize();
});
