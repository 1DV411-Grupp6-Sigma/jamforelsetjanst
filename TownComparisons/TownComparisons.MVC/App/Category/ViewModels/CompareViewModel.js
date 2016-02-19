categoryModule.controller("compareViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    console.log("ResultHomeViewModel");

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;

    var initialize = function () {
        $scope.getOrganisationalUntsByCategoryId(1);
        $scope.loadOperatorsToCompare();
    }

    $scope.getOrganisationalUntsByCategoryId = function (categoryId) {
        viewModelHelper.apiGet('api/admin/allOU/' + categoryId, null, //get data from kolada based on id:s
            function (result) {
                $scope.organisationalUnits = result.data;
            });
    }

    $scope.loadOperatorsToCompare = function () {
        $scope.operatorsToCompare = $scope.categoryService.getSubjectList();
        console.log($scope.operatorsToCompare);
    }

    initialize();
});