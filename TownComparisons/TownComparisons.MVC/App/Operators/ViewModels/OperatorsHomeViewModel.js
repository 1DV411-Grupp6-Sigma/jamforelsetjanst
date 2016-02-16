operatorsModule.controller("operatorsHomeViewModel", function ($scope, operatorsService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.operatorsService = operatorsService;


    var initialize = function () {
        $scope.getOrganisationalUntsByCategoryId(1);
    }

    $scope.getOrganisationalUntsByCategoryId = function (categoryId) {
        viewModelHelper.apiGet('api/admin/allOU/' + categoryId, null,
            function (result) {
                $scope.organisationalUnits = result.data;
            });
    }

    initialize();
});
