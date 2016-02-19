categoryModule.controller("categoryViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;


    var initialize = function () {
        $scope.getOrganisationalUntsByCategoryId($routeParams.categoryId);
    }

    $scope.getOrganisationalUntsByCategoryId = function (categoryId) {
        viewModelHelper.apiGet('api/operators_in_category/' + categoryId, null,
            function (result) {
                $scope.organisationalUnits = result.data;
            });
    }

    $scope.addOperatorToCompareList = function(operator) {
        $scope.categoryService.addSubject(operator);
        console.log($scope.categoryService.getSubjectList());
    }

    //Show OU:s inside a category
    $scope.showOperator = function (ou) {
        $scope.flags.shownFromList = true;
        viewModelHelper.navigateTo('category/' + $routeParams.categoryId + '/operator/' + ou.OrganisationalUnitId);
    }

    initialize();
});
