categoryModule.controller("compareViewModel", function ($scope, $rootScope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    $scope.categoryID = 1; //categoryService.categoryID;
    $scope.operatorIDs = ["1", "2", "3", "4", "5", "6"]; //$rootScope.operatorIds;
    $scope.operatorID = 'V15E128300201';
    $scope.operators = [//];
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

    var initialize = function () {
        $scope.getOrganisationalUnitInfoByOperatorID($scope.operatorID);
        //$scope.getOrganisationalUnitsInCategoryByIds(1, 'V17E21008461');
        //$scope.loadOperatorsToCompare();
    }

    //Get Organisational Unit Info via OperatorController
    $scope.getOrganisationalUnitInfoByOperatorID = function (operatorID) {

        viewModelHelper.apiGet('api/operators/' + operatorID, null,
            function (result) {
                console.log(result.data);
                //$scope.organisationalUnit = result.data;
            });
    }

    initialize();
});