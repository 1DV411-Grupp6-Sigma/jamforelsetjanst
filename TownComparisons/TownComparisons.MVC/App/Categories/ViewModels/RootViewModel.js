categoryModule.controller("rootViewModel", function ($rootScope, $scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "Hitta och jämför service";
    }

    //List with selected OU's
    $rootScope.listItems = collectorFactory.listOfSubjects;

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
