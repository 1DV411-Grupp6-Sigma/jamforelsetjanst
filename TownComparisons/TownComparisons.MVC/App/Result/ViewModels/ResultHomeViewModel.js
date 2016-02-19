resultModule.controller("resultHomeViewModel", function ($scope, resultService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.resultService = resultService;

    var initialize = function () {
        $scope.getOrganisationalUntsByCategoryId(1);
    }

    $scope.getOrganisationalUntsByCategoryId = function (categoryId) {
        viewModelHelper.apiGet('api/admin/allOU/' + categoryId, null, //hämta data från kolada baserat på id:n
            function (result) {
                $scope.organisationalUnits = result.data;
            });
    }

    initialize();
});
