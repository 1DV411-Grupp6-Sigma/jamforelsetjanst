
var adminModule = angular.module('admin', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/admin', { templateUrl: '/App/Admin/Views/AdminHomeView.html', controller: 'adminHomeViewModel' });
        $routeProvider.when('/admin/list', { templateUrl: '/App/Admin/Views/AdminListView.html', controller: 'adminListViewModel' });
        $routeProvider.when('/admin/show/:adminId', { templateUrl: '/App/Admin/Views/AdminView.html', controller: 'adminViewModel' });
        $routeProvider.otherwise({ redirectTo: '/admin' });
        $locationProvider.html5Mode(true);
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
