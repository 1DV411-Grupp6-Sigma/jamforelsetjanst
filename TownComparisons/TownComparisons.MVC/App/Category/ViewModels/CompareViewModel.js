categoryModule.controller("compareViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, $rootScope, collectorFactory) {

    //debugger;

    //this block of code will read the id from the query string
    $scope.OperatorUnitList = []; //IDs from
    for (var i = 0; i < $routeParams.id.length; i++) {
        $scope.OperatorUnitList.push($routeParams.id[i]); //will save id's to an array
    }

    $scope.OperatorUnits = []; //result from database + Kolada

    //Do I really need these?
    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    
    //only for test purpose
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

    //In Initialize() call (new) API controller who goes to the service layer and gets data from database and Kolada
    var initialize = function () {
        $scope.getOrganisationalUnitInfoByOperatorID($scope.OperatorUnitList);
    }

    //Get Organisational Unit Info via OperatorController
    $scope.getOrganisationalUnitInfoByOperatorID = function (operatorIDs) {
        for (var j = 0; j < operatorIDs.length; j++) {
            viewModelHelper.apiGet('api/operators/' + operatorIDs[j], null, //gets data from database. loop through for more than one operator
                function (result) {
                    console.log(result.data); //result data from server
                    $scope.OperatorUnits.push(result.data);
                });
        }
    }

    initialize();
});