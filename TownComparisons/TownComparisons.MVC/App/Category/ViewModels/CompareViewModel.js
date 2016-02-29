categoryModule.controller("compareViewModel", function ($scope, $rootScope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    //$scope.operatorIds = $rootScope.operatorIds;
    $scope.operatorIDs = ["1", "2", "3", "4", "5", "6"]; //$rootScope.operatorIds;
    $scope.operators = [
            {
                ID: 1,
                Name: "Tallbackaskolan",
                KPI: "Get KPI from Kolada"
            },
            {
                ID: 2,
                Name: "Hemskolan",
                KPI: "KPI"
            }
    ];

    debugger;

    //var initialize = function () {
    //    $scope.getOrganisationalUntsByCategoryId(1);
    //    $scope.loadOperatorsToCompare();
    //}

    //$scope.getOrganisationalUntsByCategoryId = function (categoryId) {
    //    viewModelHelper.apiGet('api/admin/allOU/' + categoryId, null, //get data from kolada based on id:s
    //        function (result) {
    //            $scope.organisationalUnits = result.data;
    //        });
    //}

    //$scope.loadOperatorsToCompare = function () {
    //    $scope.operatorsToCompare = $scope.categoryService.getSubjectList();
    //    console.log($scope.operatorsToCompare);
    //}

    //initialize();
});