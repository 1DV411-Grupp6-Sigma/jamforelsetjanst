adminModule.controller("adminOperatorViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.adminService = adminService;

    var initialize = function () {
        $scope.refreshOperator($routeParams.operatorId);
    }

    $scope.refreshOperator = function (operatorId) {
        viewModelHelper.apiGet('api/operators/' + operatorId, null,
            function (result) {
                console.log(result.data);
                adminService.operatorId = operatorId;
                $scope.operator = result.data;
            });
    }


    initialize();
});
