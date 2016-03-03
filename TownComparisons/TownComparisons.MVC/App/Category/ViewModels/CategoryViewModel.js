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
        $scope.showMe();
        $scope.detailedClass = "unavailable";
        $scope.getClientPosition();
    }

    $scope.showMe = function () {
        $scope.detailed = true;
        $scope.simple = false;
        $scope.detailedClass = "unavailable";
        $scope.simpleClass = "";
    }
    $scope.hideMe = function () {
        $scope.detailed = false;
        $scope.simple = true;
        $scope.simpleClass = "unavailable";
        $scope.detailedClass = "";
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

    // Gets clients position.
    $scope.getClientPosition = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                $scope.$apply(function () {
                    $scope.posLat = position.coords.latitude;
                    $scope.posLng = position.coords.longitude;
                });
            });
        }
    }

    // Gets distance between client and operators positions.
    $scope.getDistanceBetweenPositions = function (ou) {
        var lat1 = ou.Latitude;
        var lon1 = ou.Longitude;

        var R = 6371; // km 
        var x1 = $scope.posLat - lat1;
        var dLat = $scope.toRad(x1);
        var x2 = $scope.posLng - lon1;
        var dLon = $scope.toRad(x2);
        var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                        Math.cos($scope.toRad(lat1)) * Math.cos($scope.toRad($scope.posLat)) *
                        Math.sin(dLon / 2) * Math.sin(dLon / 2);
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c;

        return parseFloat(d.toFixed(2));
    }

    $scope.toRad = function (coord) {
        return coord * Math.PI / 180;
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

    $rootScope.sortOuByDistance = function () {
        $scope.clearSortOuBy();

        $scope.visibleDistance = '';
        $scope.sortOrder = $scope.sortAsc;
        $scope.activeDistance = $scope.classActive;
        $scope.sortBy = $scope.getDistanceBetweenPositions;
        $scope.sortOrder = $scope.sortAsc;
    }

    $rootScope.clearSortOuBy = function () {

        $scope.visibleName = 'invisible';
        $scope.visibleAddress = 'invisible';
        $scope.activeName = '';
        $scope.activeAddress = '';
        $scope.activeDistance = '';
    }

    initialize();
});
