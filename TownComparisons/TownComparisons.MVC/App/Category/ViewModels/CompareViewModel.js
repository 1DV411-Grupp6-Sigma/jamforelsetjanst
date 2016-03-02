categoryModule.controller("compareViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, $rootScope, collectorFactory) {

    //debugger;

    

    //This code block read both category ID and OperatorUnit IDs from the query string
    $scope.categoryID = $routeParams.categoryId;
    $scope.OperatorUnitList = [];
    for (var i = 0; i < $routeParams.id.length; i++) {
        $scope.OperatorUnitList.push($routeParams.id[i]);
    }

    $scope.OperatorUnits = []; //result from database (+Kolada?)

    //Do I really need these?
    $scope.viewModelHelper = viewModelHelper;
    //$scope.categoryService = categoryService;

    //In Initialize() call (new) API controller who goes to the service layer and gets data from database and Kolada
    var initialize = function () {
        $scope.getOrganisationalUnitInfoByOperatorID($scope.categoryID, $scope.OperatorUnitList);
        $scope.getOrganisationalUnitInfoByOperatorID2($scope.categoryID, $scope.OperatorUnitList);
    }

    //Get Organisational Unit Info via OperatorController
    $scope.getOrganisationalUnitInfoByOperatorID = function (categoryID, operatorIDs) {
        for (var j = 0; j < operatorIDs.length; j++) {
            viewModelHelper.apiGet('api/operators/' + operatorIDs[j], null, //gets data from database. loop through for more than one operator
                function (result) {

                    //var operatorUnit;
                    console.log(result.data); //result data from database

                    $scope.OperatorUnits.push(result.data);
                    //$scope.OperatorUnits.push($operatorUnit);
                });
            //viewModelHelper.apiGet('api/category/' + categoryID + '/properties?operators=' + operatorIDsV15E108000801,V15E108000701,OSV,OSV' + operatorIDs[j], null, //gets data from database. loop through for more than one operator
            //    function (result) {
            //        console.log(result.data); //result data from Kolada
            //        $scope.OperatorUnits.push(result.data);
            //    });
        }
    }

    $scope.getOrganisationalUnitInfoByOperatorID2 = function (categoryID, operatorIDs) {
        for (var k = 0; k < operatorIDs.length; k++) {
            viewModelHelper.apiGet('api/category/' + categoryID + '/properties?operators=' + operatorIDs[k], null, //V15E108000801,V15E108000701,OSV,OSV' + operatorIDs[j], null, //gets data from database. loop through for more than one operator
            function (result) {
                console.log('no2');
                console.log(result.data); //result data from Kolada
                //$scope.OperatorUnits.push(result.data);
            });
        }
    }

    initialize();
});