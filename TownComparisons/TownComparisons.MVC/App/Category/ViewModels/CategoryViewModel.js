categoryModule.controller("categoryViewModel", function ($rootScope, $scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory, categoriesFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    $scope.sortByName = 'Name';
    $scope.sortAsc = 'sortAsc';
    $scope.sortDesc = 'sortDesc';
    $scope.sortOrder = $scope.sortAsc;
    $scope.classActive = 'active';
    $scope.classInvisible = 'invisible';
    
    var initialize = function () {
        //$scope.getOrganisationalUntsByCategoryId($routeParams.categoryId);
        $scope.getCategory($routeParams.categoryId);
        $scope.sortOuByName();
    }

    //Switch between sortings
    $scope.changeListView = function (value) {
        categoriesFactory.changeListView(value, $routeParams.categoryId);
    }

    $scope.setCompareSettingsForOu = function (ou) {
        //check if is in compare list
        var ouIsInCompare = $scope.checkIfOuIsInCompareList(ou);
        ou.class = (ouIsInCompare ? "after-compare" : "before-compare");
        ou.icon = (ouIsInCompare ? "fi-plus" : "fi-check");
        ou.text = (ouIsInCompare ? "Jämför" : "");
    }

    $scope.checkIfOuIsInCompareList = function (ou) {
        for (var i = 0; i < collectorFactory.listOfSubjects.length; i++) {
            if (collectorFactory.listOfSubjects[i].OrganisationalUnitId === ou.OrganisationalUnitId) {
                return true;
            }
        }
        return false;
    }

    /*
    $scope.getOrganisationalUntsByCategoryId = function (categoryId) {
        viewModelHelper.apiGet('api/operators_in_category/' + categoryId, null,
            function (result) {
                $scope.organisationalUnits = result.data;
            });
    }
    */

    $scope.getCategory = function (categoryId) {
        viewModelHelper.apiGet('api/category/' + categoryId, null,
            function (result) {
                $scope.category = result.data;
                $scope.pageHeading = 'Hitta och jämför ' + $scope.category.Name;
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

    // Sorts the Organisational Units by Name (Desc/Asc).
    $rootScope.sortOuByName = function () {
        $scope.visibleName = '';
        $scope.sortOrder = $scope.sortAsc;
        $scope.activeName = $scope.classActive;

        if ($scope.sortBy == $scope.sortByName) {
            $scope.sortBy = '-' + $scope.sortByName;
            $scope.sortOrder = $scope.sortDesc;
        }
        else {
            $scope.sortBy = $scope.sortByName;
            $scope.sortOrder = $scope.sortAsc;
        }
    }

    initialize();
});
