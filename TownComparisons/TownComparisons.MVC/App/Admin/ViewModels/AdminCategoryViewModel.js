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
