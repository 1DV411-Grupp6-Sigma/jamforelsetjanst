categoryModule.controller("categoryViewModel", function ($rootScope, $scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory, categoriesFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    $scope.sortByName = 'Name';
    $scope.sortAsc = 'sortAsc';
    $scope.sortDesc = 'sortDesc';
    $scope.classActive = 'active';
    $scope.classInvisible = 'invisible';
    
    var initialize = function () {
        $scope.getOrganisationalUntsByCategoryId($routeParams.categoryId);
        $scope.sortOuByName();
    }

    //Switch between sortings
    $scope.changeListView = function (value) {
        categoriesFactory.changeListView(value, $routeParams.categoryId);
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
        $scope.fileName = $scope.sortAsc;
        $scope.activeName = $scope.classActive;

        if ($scope.sortBy == $scope.sortByName) {
            $scope.sortBy = '-' + $scope.sortByName;
            $scope.fileName = $scope.sortDesc;
        }
        else {
            $scope.sortBy = $scope.sortByName;
            $scope.fileName = $scope.sortAsc;
        }
    }

    initialize();
});
