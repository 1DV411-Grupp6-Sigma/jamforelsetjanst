adminModule.controller("adminCategoryShowViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper, $modal) {

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

    $scope.openOperatorEditor = function (operatorId) {

        console.log('opening modal');
        adminService.selectedOperatorId = operatorId;

        var modalInstance = $modal.open({
            templateUrl: '/App/Admin/Views/AdminOperatorView.html', // myModalContent.html',
            controller: 'adminOperatorViewModel',
            scope: $scope
            /* resolve: {
                items: function () {
                    return $scope.items;
                }
            } */
        });

        modalInstance.result.then(function (operator) {
            //refresh page
            $window.location.href = $window.location.href;
            /*
            //replace current operator with new (didn't work)
            for (var i = 0; i < $scope.category.Category.OrganisationalUnits.length; i++) {
                if ($scope.category.Category.OrganisationalUnits[i].OrganisationalUnitId == operator.OrganisationalUnitId) {
                    $scope.category.Category.OrganisationalUnits[i] == operator;
                    console.log('found it!');
                    break;
                }
            }
            */
        }, function () {
            //modal cancelled, do something here?
        });
    };

    $scope.gotoEdit = function (mode) {
        adminService.editCategoryMode = mode;
        viewModelHelper.navigateTo('admin/category/' + adminService.categoryId + '/edit');
    }

    initialize();
});
