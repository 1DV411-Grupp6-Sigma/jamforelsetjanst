adminModule.controller("adminCategoryViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.adminService = adminService;

    var initialize = function () {
        $scope.stateFilter = 'All';
        $scope.refreshCategory($routeParams.categoryId);
    }

    $scope.refreshCategory = function (categoryId) {
        viewModelHelper.apiGet('api/admin/category/' + categoryId, null,
            function (result) {
                console.log(result.data);
                adminService.categoryId = categoryId;
                $scope.category = result.data;
            });
    }

    $scope.saveCategory = function () {
        setCategoryOrganisationalUnitsToUse();
        setCategoryQueriesToUse();

        viewModelHelper.apiPost('api/admin/category/' + adminService.categoryId, $scope.category.Category,
            function (result) {
                console.log(result.data);
            });
    }

    var setCategoryOrganisationalUnitsToUse = function () {
        var ousToUse = [];
        for (var i = 0; i < $scope.category.AllOrganisationalUnits.length; i++) {

            //if checked (Use == true)
            if ($scope.category.AllOrganisationalUnits[i].Use == true) {
                //add it
                ousToUse.push($scope.category.AllOrganisationalUnits[i]);
            }
        }
        console.log(ousToUse);
        $scope.category.Category.OrganisationalUnits = ousToUse;
    }
    var setCategoryQueriesToUse = function () {
        var queriesToUse = [];
        for (var i = 0; i < $scope.category.AllPropertyQueryGroups.length; i++) {
            for (var j = 0; j < $scope.category.AllPropertyQueryGroups[i].Queries.length; j++) {

                //if checked (Use == true)
                if ($scope.category.AllPropertyQueryGroups[i].Queries[j].Use == true) {

                    //check not the same query already has been added (if exists in multiple query groups)
                    var alreadyUsed = false;
                    for (var u = 0; u < queriesToUse.length; u++) {
                        if (queriesToUse[u].WebServiceName == $scope.category.AllPropertyQueryGroups[i].Queries[j].WebServiceName &&
                            queriesToUse[u].QueryId == $scope.category.AllPropertyQueryGroups[i].Queries[j].QueryId) {
                            alreadyUsed = true;
                        }
                    }
                    if (!alreadyUsed) {
                        //add it
                        queriesToUse.push($scope.category.AllPropertyQueryGroups[i].Queries[j]);
                    }
                }
            }
        }
        console.log(queriesToUse);
        $scope.category.Category.Queries = queriesToUse;
    }



    $scope.setStateFilter = function (filter) {
        $scope.stateFilter = filter;
    }

    $scope.searchForGroup = function (queryGroup) {

        if ($scope.searchAll !== undefined && $scope.searchAll.length !== 0) {
            var allMatch = false;
            if ($scope.doSearchGroupTitle(queryGroup, $scope.searchAll) == true) {
                allMatch = true;
            }
            else if ($scope.doSearchGroupQueryTitle(queryGroup, $scope.searchAll) == true) {
                allMatch = true;
            }

            if (!allMatch) {
                return false;
            }
        }

        if ($scope.searchQueryTitle !== undefined && $scope.searchQueryTitle.length !== 0) {
            if ($scope.doSearchGroupQueryTitle(queryGroup, $scope.searchQueryTitle) != true) {
                return false;
            }
        }

        if ($scope.doSearchGroupQueryUse(queryGroup) != true) {
            return false;
        }

        return true;
    };

    $scope.searchForQuery = function (query) {

        if ($scope.searchQueryTitle !== undefined && $scope.searchQueryTitle.length !== 0) {
            if ($scope.doSearchQueryTitle(query, $scope.searchQueryTitle) != true) {
                return false;
            }
        }
        if ($scope.doSearchQueryUse(query) != true) {
            return false;
        }

        return true;
    };


    $scope.doSearchGroupTitle = function (queryGroup, searchValue) {
        if (queryGroup.Title.toLowerCase().indexOf(searchValue) >= 0) {
            return true;
        }
        return false;
    }

    $scope.doSearchQueryTitle = function (query, searchValue) {
        if (query.Title.toLowerCase().indexOf(searchValue) >= 0) {
            return true;
        }
        return false;
    }
    $scope.doSearchGroupQueryTitle = function (queryGroup, searchValue) {
        for (var i = 0; i < queryGroup.Queries.length; i++) {
            if ($scope.doSearchQueryTitle(queryGroup.Queries[i], searchValue)) {
                return true;
            }
        }
        return false;
    }

    $scope.doSearchQueryUse = function (query) {
        if ($scope.stateFilter == 'All' ||
            ($scope.stateFilter == 'Chosen' && query.Use == true) ||
            ($scope.stateFilter == 'Unchosen' && query.Use != true)) {

            return true;
        }
        return false;
    }
    $scope.doSearchGroupQueryUse = function (queryGroup) {
        for (var i = 0; i < queryGroup.Queries.length; i++) {
            if ($scope.doSearchQueryUse(queryGroup.Queries[i])) {
                return true;
            }
        }
        return false;
    }

    initialize();
});
