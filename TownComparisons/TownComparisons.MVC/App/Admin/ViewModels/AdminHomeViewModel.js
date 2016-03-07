adminModule.controller("adminHomeViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.adminService = adminService;


    var initialize = function () {
        $scope.refreshCategories();

    }

    var removeCategory = function (categoryId) {

    }

    initialize();
});
