categoryModule.controller("categoryViewModel", function ($rootScope, $scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    

    var initialize = function () {
        $scope.getOrganisationalUntsByCategoryId($routeParams.categoryId);
        $scope.sortOuById();
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

    // Sorts the Organisational Units by Name (Desc).
    $rootScope.sortOuByName = function () {
        $scope.visibleName = '';
        $scope.visibleId = 'invisible';
        $scope.fileName = 'sortAsc';
        $scope.activeName = 'active';
        $scope.activeId = '';

        if ($scope.sortBy == 'Name') {
            $scope.sortBy = '-Name';
            $scope.fileName = 'sortDesc';
        }
        else {
            $scope.sortBy = 'Name';
            $scope.fileName = 'sortAsc';
        }
    }

    // Sorts the Organisational Units by Id (Desc).
    $rootScope.sortOuById = function () {
        $scope.visibleId = '';
        $scope.visibleName = 'invisible';
        $scope.fileId = 'sortAsc';
        $scope.activeName = '';
        $scope.activeId = 'active';

        if ($scope.sortBy == 'OrganisationalUnitId') {
            $scope.sortBy = '-OrganisationalUnitId';
            $scope.fileId = 'sortDesc';
        }
        else {
            $scope.sortBy = 'OrganisationalUnitId';
            $scope.fileId = 'sortAsc';
        }
    }

    initialize();
});
