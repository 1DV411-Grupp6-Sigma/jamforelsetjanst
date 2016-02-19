categoryModule.controller("rootViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "Kategori";
    }
    

    initialize();
});