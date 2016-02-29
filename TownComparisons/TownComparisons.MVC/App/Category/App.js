
var categoryModule = angular.module('category', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/category/:categoryId', {
                 templateUrl: '/App/Category/Views/CategoryView.html', 
                 controller: 'categoryViewModel'
            })
            .when('/category/:categoryId/compare', {
                templateUrl: '/App/Category/Views/CompareView.html',
                controller: 'compareViewModel'
                })
            .when('/category/:categoryId/operator/:operatorId', {
                templateUrl: '/App/Category/Views/OperatorView.html', 
                controller: 'operatorViewModel'
                })
            .when('/compare', {
                templateUrl: '/App/Category/Views/CompareView.html',
                controller: 'compareViewModel'
                })
            .otherwise({ redirectTo: '/' });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

categoryModule.factory('categoryService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.categoryService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var categoryService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;
        return this;
    };
    myApp.categoryService = categoryService;
}(window.MyApp));

