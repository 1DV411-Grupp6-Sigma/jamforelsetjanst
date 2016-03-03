categoryModule.controller("categoryViewModel", function ($rootScope, $scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, collectorFactory, categoriesFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;

    $scope.sortByName = 'Name';
    $scope.sortByAddress = 'Address';
    $scope.sortAsc = 'sortAsc';
    $scope.sortDesc = 'sortDesc';
    $scope.sortOrder = $scope.sortAsc;
    $scope.classActive = 'active';
    $scope.classInvisible = 'invisible';
    
    var initialize = function () {
        categoryService.getCategory($routeParams.categoryId, afterCategoryLoaded);
        $scope.sortOuByName();
    }

    //runned after category has been loaded
    var afterCategoryLoaded = function () {
        $scope.pageHeading = 'Hitta och jämför ' + $rootScope.category.Name;
    }

    //Switch between sortings
    $scope.changeListView = function (value) {
        categoriesFactory.changeListView(value, $routeParams.categoryId);
    }


    $scope.setCompareSettingsForOu = function (ou) {
        if (ou != null) {
            //check if is in compare list
            var ouIsInCompare = collectorFactory.checkIfInList(ou);
            ou.class = (ouIsInCompare ? "after-compare" : "before-compare");
            ou.icon = (ouIsInCompare ? "fi-check" : "fi-plus");
            ou.text = (ouIsInCompare ? "" : "Jämför");
        }
    }


    //Show OU:s inside a category
    $scope.showOperator = function (ouId) {
        viewModelHelper.navigateTo('category/' + $routeParams.categoryId + '/operator/' + ouId);
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
        $scope.clearSortOuBy();

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

    // Sorts the Organisational Units by Address (Desc/Asc).
    $rootScope.sortOuByAddress = function () {
        $scope.clearSortOuBy();

        $scope.visibleAddress = '';
        $scope.sortOrder = $scope.sortAsc;
        $scope.activeAddress = $scope.classActive;

        if ($scope.sortBy == $scope.sortByAddress) {
            $scope.sortBy = '-' + $scope.sortByAddress;
            $scope.sortOrder = $scope.sortDesc;
        }
        else {
            $scope.sortBy = $scope.sortByAddress;
            $scope.sortOrder = $scope.sortAsc;
        }
    }

    $rootScope.clearSortOuBy = function () {

        $scope.visibleName = 'invisible';
        $scope.visibleAddress = 'invisible';
        $scope.activeName = '';
        $scope.activeAddress = '';
    }

    initialize();
});
