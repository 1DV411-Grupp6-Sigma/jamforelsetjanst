categoryModule.controller("rootViewModel", function ($rootScope, $scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "Hitta och jämför service";
    }

    //List with selected OU's
    $rootScope.listItems = collectorFactory.listOfSubjects;

    //Deletes all item on $scope.listItems
    $rootScope.deleteAllOperators = function () {
        collectorFactory.deleteAllSubjects();
    }

    //Toggle OU on the $scope.listItems
    $rootScope.toggleOperators = function (subject) {
        collectorFactory.toggleSubject(subject);
    }

    $rootScope.deleteOperator = function (subject) {
        collectorFactory.deleteSubject(subject);
    }

    $scope.compare = function () {
        viewModelHelper.navigateTo('category/' + $routeParams.categoryId + '/compare/');
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
