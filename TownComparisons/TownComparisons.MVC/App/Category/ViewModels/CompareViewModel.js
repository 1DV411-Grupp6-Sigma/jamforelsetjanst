categoryModule.controller("compareViewModel", function ($scope, categoryService, $http, $q, $routeParams, $window, $location, viewModelHelper, $rootScope, collectorFactory) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.categoryService = categoryService;
    $scope.categoryID = $routeParams.categoryId;
    $scope.organisationalUnitIdsToCompare = [];


    var initialize = function () {
        //save operator ids to compare in an array
        for (var i = 0; i < $routeParams.id.length; i++) {
            $scope.organisationalUnitIdsToCompare.push($routeParams.id[i] + '');
        }

        //start loading category (and then compare results)
        categoryService.getCategory($scope.categoryID, getCompareResults);
    }

    //runned after category has been loaded
    var getCompareResults = function () {

        //load compare result data from API
        var organisationalUnitIdsString = $scope.organisationalUnitIdsToCompare.join(",");
        viewModelHelper.apiGet('api/category/' + $scope.categoryID + '/properties?operators=' + organisationalUnitIdsString, null, 
            function (result) {
                $scope.compareResults = result.data;
                console.log('no2');
                console.log(result.data);
            }
        );
    }
    
    initialize();
});