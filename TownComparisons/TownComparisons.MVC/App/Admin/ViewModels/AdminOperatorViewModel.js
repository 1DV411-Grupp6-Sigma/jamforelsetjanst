adminModule.controller("adminOperatorViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.adminService = adminService;

    $scope.categoryId = $routeParams.categoryId;
    $scope.operatorId = $routeParams.operatorId;
    $scope.validationErrors = [];
    $scope.knownValidationErrors = [];
    $scope.closeValidationAlert = false;

    var initialize = function () {
        refreshOperator();
    }

    var refreshOperator = function () {
        viewModelHelper.apiGet('api/category/' + $scope.categoryId + '/operator/' + $scope.operatorId, null,
            function (result) {
                console.log(result.data);
                $scope.operator = result.data;
            });
    }


    initialize();
});
