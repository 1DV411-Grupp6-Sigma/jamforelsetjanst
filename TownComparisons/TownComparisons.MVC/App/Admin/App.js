
var adminModule = angular.module('admin', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/admin', { templateUrl: '/App/Admin/Views/AdminHomeView.html', controller: 'adminHomeViewModel' });
        $routeProvider.when('/admin/categories', { templateUrl: '/App/Admin/Views/AdminCategoriesView.html', controller: 'adminCategoriesViewModel' });
        $routeProvider.when('/admin/category/:categoryId', { templateUrl: '/App/Admin/Views/AdminCategoryShowView.html', controller: 'adminCategoryShowViewModel' });
        $routeProvider.when('/admin/category/:categoryId/edit', { templateUrl: '/App/Admin/Views/AdminCategoryEditView.html', controller: 'adminCategoryEditViewModel' });
        $routeProvider.when('/admin/operators', { templateUrl: '/App/Admin/Views/AdminOperatorsView.html', controller: 'adminOperatorsViewModel' });
        $routeProvider.when('/admin/operators/:operatorId', { templateUrl: '/App/Admin/Views/AdminOperatorView.html', controller: 'adminOperatorViewModel' });
        $routeProvider.otherwise({ redirectTo: '/admin' });
        //$locationProvider.html5Mode(true);
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

adminModule.factory('adminService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.adminService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var adminService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;
    
        $rootScope.refreshCategories = function () {
            viewModelHelper.apiGet('api/categories', null,
                function (result) {
                    $rootScope.groupCategories = result.data;
                });
        }

        $rootScope.showCategory = function (categoryId) {
            viewModelHelper.navigateTo('admin/category/' + categoryId);
        }



        self.adminId = 0;

        return this;
    };
    myApp.adminService = adminService;
}(window.MyApp));
