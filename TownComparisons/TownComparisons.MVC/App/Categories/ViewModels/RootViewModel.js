categoryModule.controller("rootViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "Hitta och jämför service";
    }

    /*$scope.categoriesList = function () {
        viewModelHelper.navigateTo('categories');
    }*/

    /*$scope.showCategory = function () {
        if (categoryService.categoryId != 0) {
            $scope.flags.shownFromList = false;
            viewModelHelper.navigateTo('category/' + categoryService.categoryId + '/operators');
        }
    }*/

    initialize();
});
