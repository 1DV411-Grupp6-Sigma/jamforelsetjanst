categoryModule.controller("compareViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    //$scope.operators = collectorFactory.listOfSubjects;
    $scope.operators = [
            {
                Name: "Skola1"
            },
            {
                Name: "Skola2"
            }
    ];

    console.log($scope.operators[0].Name);

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