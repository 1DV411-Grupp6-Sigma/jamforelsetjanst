categoryModule.controller("alphabetViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

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
        $scope.flags.shownFromList = true;
        viewModelHelper.navigateTo('category/' + category.Id);
    }

    //Maybe this function should be global?
    $scope.changeView = function (value) {
        $scope.flags.shownFromList = true;
        if (value == undefined) {
            viewModelHelper.navigateTo('categories');
        }
        else {

            viewModelHelper.navigateTo('categories' + value);
        }
    }

    initialize();
});
