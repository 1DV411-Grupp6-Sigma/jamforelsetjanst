resultModule.controller("rootViewModel", function ($scope, resultService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    console.log("RootViewModel.js");

    // This is the parent controller/viewmodel for 'customerModule' and its $scope is accesible
    // down controllers set by the routing engine. This controller is bound to the Customer.cshtml in the
    // Home view-folder.

    $scope.viewModelHelper = viewModelHelper;
    $scope.resultService = resultService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "ResultRootViewModel.js";
    }

    initialize();
});