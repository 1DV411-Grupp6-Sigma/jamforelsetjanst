adminModule.controller("adminCategoryShowViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.adminService = adminService;
    
    var initialize = function () {
        $scope.categoryHasBeenLoaded = false;
        $scope.pageHeading = 'Laddar kategori...';
        adminService.getCategory($routeParams.categoryId, afterCategoryHasBeenLoaded);
    }

    var afterCategoryHasBeenLoaded = function () {
        $scope.pageHeading = 'Kategori: ' + $scope.category.Category.Name;
        $scope.categoryHasBeenLoaded = true;
    }

    /*
    $scope.refreshCategory = function (categoryId) {
        viewModelHelper.apiGet('api/admin/category/' + categoryId, null,
            function (result) {
                adminService.categoryId = categoryId;
                $scope.category = result.data;
                $scope.pageHeading = 'Kategori: ' + $scope.category.Category.Name;
                $scope.categoryHasBeenLoaded = true;

                viewModelHelper.apiGet('api/category/' + categoryId + '/properties?operators=V15E108000801,V15E108000701,dfhdsjf', null,
                    function (result) {
                        console.log(result);
                    }
                );
            });
    }
    */

    $scope.gotoEdit = function (mode) {
        adminService.editCategoryMode = mode;
        viewModelHelper.navigateTo('admin/category/' + adminService.categoryId + '/edit');
    }

    initialize();
});
