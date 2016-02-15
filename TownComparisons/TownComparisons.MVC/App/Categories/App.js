
var categoryModule = angular.module('category', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        //$routeProvider.when('/', { templateUrl: '/App/Categories/Views/CategoriesView.html', controller: 'categoriesViewModel' });
        $routeProvider.when('/categories', { templateUrl: '/App/Categories/Views/CategoriesView.html', controller: 'categoriesViewModel' });
        $routeProvider.when('/category/:categoryId', { templateUrl: '/App/Category/Views/CategoryView.html', controller: 'categoryViewModel' });
        //$routeProvider.when('/ou/:ouId', { templateUrl: '/App/Categories/Views/OrganisationalUnitView.html', controller: 'organisationalUnitViewModel' });
        $routeProvider.otherwise({ redirectTo: '/categories' });
        //$locationProvider.html5Mode(true);
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

categoryModule.factory('categoryService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.categoryService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var categoryService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;

        self.categoryId = 0;

        return this;
    };
    myApp.categoryService = categoryService;
}(window.MyApp));
