categoryModule.controller("categoriesViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;

    var initialize = function () {
        $scope.viewAllCategories();
    }

    //Get all categories via APIHomeController
    $scope.viewAllCategories = function () {
        viewModelHelper.apiGet('api/home/categories', null,
            function (result) {
                $scope.groupCategories = result.data;
            });
    }

    //Show OU:s inside a category
    $scope.showCategory = function (category) {
        $scope.flags.shownFromList = true;
        viewModelHelper.navigateTo('category/' + category.Id + '/operators');
    }

    initialize();
});
