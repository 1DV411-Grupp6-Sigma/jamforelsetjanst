categoryModule.controller("alphabetViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, categoriesFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;

    var initialize = function () {
        $scope.viewCategoriesBasedOnAlphabet();
    }

    //Get all categories based on alphabet via APICategoriesController
    $scope.viewCategoriesBasedOnAlphabet = function () {
        viewModelHelper.apiGet('api/categories/alphabet', null,
            function (result) {
                $scope.alphabetCategories = result.data;
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
