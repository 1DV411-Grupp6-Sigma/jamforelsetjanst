categoryModule.controller("categoriesViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

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
            //Can I run a function here?
        }
    }

    initialize();
});
