operatorsModule.controller("rootViewModel", function ($scope, operatorsService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    // This is the parent controller/viewmodel for 'customerModule' and its $scope is accesible
    // down controllers set by the routing engine. This controller is bound to the Customer.cshtml in the
    // Home view-folder.

    $scope.viewModelHelper = viewModelHelper;
    $scope.operatorsService = operatorsService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "Category Section";
    }

    //$scope.categoriesList = function () {
    //    viewModelHelper.navigateTo('admin/categories');
    //}

    //$scope.showCategory = function () {
    //    if (operatorsService.categoryId != 0) {
    //        $scope.flags.shownFromList = false;
    //        viewModelHelper.navigateTo('home/category/' + operatorsService.categoryId);
    //    }
    //}

    initialize();
});
