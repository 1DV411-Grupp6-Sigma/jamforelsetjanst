operatorModule.controller("operatorViewModel", function ($scope, operatorService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.operatorService = operatorService;


    var initialize = function () {
        $scope.getOrganisationalUnitByOUId($routeParams.ouId);
        $scope
    }

    $scope.getOrganisationalUnitByOUId = function (ouId) {
        viewModelHelper.apiGet('api/admin/allOU/' + categoryId, null,
            function (result) {
                $scope.organisationalUnit = result.data;
            });
    }

    initialize();
});