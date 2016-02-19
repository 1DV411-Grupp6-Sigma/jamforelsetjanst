resultModule.controller("resultHomeViewModel", function ($scope, resultService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    consol.log("ResultHomeViewModel");

    $scope.viewModelHelper = viewModelHelper;
    $scope.resultService = resultService;

    var initialize = function () {
        //$scope.getOrganisationalUntsByCategoryId(1);
        $scope.getOperatorsById();
    }

    $scope.getOrganisationalUntsByCategoryId = function (categoryId) {
        viewModelHelper.apiGet('api/admin/allOU/' + categoryId, null, //get data from kolada based on id:s
            function (result) {
                $scope.organisationalUnits = result.data;
            });
    }

    initialize();
});