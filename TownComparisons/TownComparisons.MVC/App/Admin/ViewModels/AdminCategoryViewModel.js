adminModule.controller("adminCategoryViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.adminService = adminService;

    var initialize = function () {
        $scope.refreshCategory($routeParams.categoryId);
    }

    $scope.refreshCategory = function (categoryId) {
        viewModelHelper.apiGet('api/admin/category/' + categoryId, null,
            function (result) {
                adminService.categoryId = categoryId;
                $scope.category = result.data;
            });
    }

    initialize();
});
