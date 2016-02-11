
var adminModule = angular.module('admin', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/admin', { templateUrl: '/App/Admin/Views/AdminHomeView.html', controller: 'adminHomeViewModel' });
        $routeProvider.when('/admin/categories', { templateUrl: '/App/Admin/Views/AdminCategoriesView.html', controller: 'adminCategoriesViewModel' });
        $routeProvider.when('/admin/category/:categoryId', { templateUrl: '/App/Admin/Views/AdminCategoryView.html', controller: 'adminCategoryViewModel' });
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

        self.adminId = 0;

        return this;
    };
    myApp.adminService = adminService;
}(window.MyApp));
