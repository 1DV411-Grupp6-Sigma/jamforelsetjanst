operatorModule.controller("operatorViewModel", function ($scope, operatorService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.operatorService = operatorService;


    var initialize = function () {
        $scope.getOrganisationalUnitInfoByOUId($routeParams.ouId);
    }
    
    //Get Organisational Unit Info via OperatorController
    $scope.getOrganisationalUnitInfoByOUId = function (ouId) {
        viewModelHelper.apiGet('operator/' + ouId, null,
            function (result) {
                $scope.organisationalUnit = result.data;
            });
    }

    //$scope.showOrder = function () {
    //    if (orderService.orderId != 0) {
    //        $scope.flags.shownFromList = false;
    //        viewModelHelper.navigateTo('operator/' + orderService.orderId);
    //    }
    //}

    initialize();
});