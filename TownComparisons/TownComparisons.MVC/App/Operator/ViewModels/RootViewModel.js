operatorModule.controller("rootViewModel", function ($scope, operatorService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.operatorService = operatorService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {
        $scope.pageHeading = "Aktör";
    }
    

    initialize();
});