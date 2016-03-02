categoryModule.controller("operatorViewModel", function ($rootScope, $scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    

    var initialize = function () {
        $scope.getOrganisationalUnitInfoByOUId($routeParams.operatorId); // testa "V15E128300201"
        //$scope.getOrganisationalUnitInfoByOUId("V15E128300201");
    }
    
    //Get Organisational Unit Info via OperatorController
    $scope.getOrganisationalUnitInfoByOUId = function (ouId) {
        viewModelHelper.apiGet('api/operators/' + ouId, null,
            function (result) {
                $scope.organisationalUnit = result.data;
            });
    }

    $scope.setCompareSettingsForOu = function (organisationalUnit) {
        var ouIsInCompare = $scope.checkIfOuIsInCompareList(organisationalUnit);
        organisationalUnit.class = (ouIsInCompare ? "before-compare" : "after-compare");
        organisationalUnit.icon = (ouIsInCompare ? "fi-check" : "fi-plus");
        organisationalUnit.text = (ouIsInCompare ? "" : "Jämför");
    }

    $scope.checkIfOuIsInCompareList = function (ou) {
        for (var i = 0; i < collectorFactory.listOfSubjects.length; i++) {
            if (collectorFactory.listOfSubjects[i].OrganisationalUnitId === ou.OrganisationalUnitId) {
                return true;
            }
        }
        return false;
    }

    /*$scope.checkWhichSchoolsAreCompared = function (subject) {
        for (var i = 0; i < collectorFactory.listOfSubjects.length; i++) {
            if (collectorFactory.listOfSubjects[i].OrganisationalUnitId != subject.OrganisationalUnitId) {
                subject.class = "after-compare";
                subject.icon = "fi-check";
                subject.text = "";
            }
        }
    }*/

    //$scope.getOrganisationalUnitInfoByOUId = function (ouId) {
    //    viewModelHelper.apiGet('api/operator/' + ouId, null,
    //        function (result) {
    //            $scope.organisationalUnit = result.data;
    //        });
    //}

    //$scope.showOrder = function () {
    //    if (orderService.orderId != 0) {
    //        $scope.flags.shownFromList = false;
    //        viewModelHelper.navigateTo('operator/' + orderService.orderId);
    //    }
    //}

    //List with selected OU's
    $rootScope.listItems = collectorFactory.listOfSubjects;

    //Toggle OU on the $scope.listItems
    $rootScope.toggleOperators = function (subject) {
        collectorFactory.toggleSubject(subject);
    }

    $rootScope.deleteOperator = function (subject) {
        collectorFactory.deleteSubject(subject);
    }

    //Deletes all item on $scope.listItems
    $rootScope.deleteAllOperators = function () {
        collectorFactory.deleteAllSubjects();
    }

    initialize();
});