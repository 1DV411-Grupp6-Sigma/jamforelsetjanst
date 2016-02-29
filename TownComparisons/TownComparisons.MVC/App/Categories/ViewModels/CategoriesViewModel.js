categoryModule.controller("categoriesViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, categoriesFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;

    var initialize = function () {
        $scope.viewAllCategories();
    }
    //Get all categories based on category via APICategoriesController
    $scope.viewAllCategories = function () {
        viewModelHelper.apiGet('api/categories', null,
            function (result) {
                $scope.groupCategories = result.data;
            });
    }

    //Show all organisational units inside a category
    $scope.showCategory = function (category) {
        categoriesFactory.showCategory(category);
    }

     //Switch between sortings
    $scope.changeView = function (value) {
        categoriesFactory.changeView(value);
    }

    initialize();
});
