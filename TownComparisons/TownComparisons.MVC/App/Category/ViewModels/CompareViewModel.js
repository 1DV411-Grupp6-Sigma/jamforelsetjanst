categoryModule.controller("compareViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, $rootScope, collectorFactory) {

    //debugger;
    //$scope.OperatorUnitList = collectorFactory.listOfSubjects;

    //this block of code will read the id from the query string and could replace the line above
    
    $scope.OperatorUnitList = [];
    for (var i = 0; i < $routeParams.id.length; i++) {
        $scope.OperatorUnitList.push($routeParams.id[i]); //will save id's to an array

        /*this should replace '$scope.operatorID = $scope.OperatorUnitList[0].OrganisationalUnitId;'
        **but you have the same info in $scope.OperatorUnitList */
        //$scope.operatorID = $scope.OperatorUnitList[0];
    }
    
    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    
    //In Initialize() call (new) API controller who goes to the service layer and gets data from database and Kolada

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

    var initialize = function () {
        $scope.getOrganisationalUnitInfoByOperatorID($scope.operatorID);
 
    }

    //Get Organisational Unit Info via OperatorController
    $scope.getOrganisationalUnitInfoByOperatorID = function (operatorID) {

        viewModelHelper.apiGet('api/operators/' + operatorID, null, //gets data from database. loop through for more than one operator
            function (result) {
                console.log(result.data); //result data from server
                //$scope.organisationalUnit = result.data;
            });
    }

    initialize();
});