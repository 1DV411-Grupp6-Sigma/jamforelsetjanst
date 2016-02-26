categoryModule.controller("categoryViewModel", function ($rootScope, $scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    

    var initialize = function () {
        $scope.getOrganisationalUntsByCategoryId($routeParams.categoryId);
    }

    $scope.getStandardSettings = function (ou) {
        ou.class = "before-compare";
        ou.icon = "fi-plus";
        ou.text = "Jämför";
    }

    $scope.checkWhichSchoolsAreCompared = function (subject) {
        for (var i = 0; i < collectorFactory.listOfSubjects.length; i++) {
            if (collectorFactory.listOfSubjects[i].OrganisationalUnitId === subject.OrganisationalUnitId) {
                    subject.class = "after-compare";
                    subject.icon = "fi-check";
                    subject.text = "";
            }
        }
    }

    $scope.getOrganisationalUntsByCategoryId = function (categoryId) {
        viewModelHelper.apiGet('api/operators_in_category/' + categoryId, null,
            function (result) {
                $scope.organisationalUnits = result.data;
            });
    }


    //Show OU:s inside a category
    $scope.showOperator = function (ou) {
        $scope.flags.shownFromList = true;
        viewModelHelper.navigateTo('category/' + $routeParams.categoryId + '/operator/' + ou.OrganisationalUnitId);
    }

    //List with selected OU's
    $rootScope.listItems = collectorFactory.listOfSubjects;
    
    //Toggle OU on the $scope.listItems
    $rootScope.toggleOperators = function (subject) {
        collectorFactory.toggleSubject(subject);
    }

    $rootScope.deleteOperator = function(subject) {
        collectorFactory.deleteSubject(subject);
    }

    //Deletes all item on $scope.listItems
    $rootScope.deleteAllOperators = function () {
        collectorFactory.deleteAllSubjects();
    }


    initialize();
});
