var operatorsModule = angular.module('operators', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/operators', { templateUrl: '/App/Operators/Views/OperatorsHomeView.html', controller: 'operatorsHomeViewModel' });
        $routeProvider.when('/operator/:categoryId', { templateUrl: '/App/Operators/Views/OperatorsHomeView.html', controller: 'operatorsHomeViewModel' });
        //$routeProvider.when('/admin/categories', { templateUrl: '/App/Admin/Views/AdminCategoriesView.html', controller: 'adminCategoriesViewModel' });
        //$routeProvider.when('/admin/category/:categoryId', { templateUrl: '/App/Admin/Views/AdminCategoryView.html', controller: 'adminCategoryViewModel' });
        $routeProvider.otherwise({ redirectTo: '/operators' });
        //$locationProvider.html5Mode(true);
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

operatorsModule.factory('operatorsService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.operatorsService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var operatorsService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;

        self.operatorsId = 0;

        return this;
    };
    myApp.operatorsService = operatorsService;
}(window.MyApp));
