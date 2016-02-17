var operatorModule = angular.module('operator', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        //$routeProvider.when('/', { templateUrl: '/App/Categories/Views/CategoriesView.html', controller: 'categoriesViewModel' });
        //$routeProvider.when('/operator/:ouId/operators', { templateUrl: '/App/Operators/Views/OperatorsHomeView.html', controller: 'operatorsHomeViewModel' });
        $routeProvider.when('/operator', { templateUrl: '/App/Operator/Views/OperatorView.html', controller: 'operatorViewModel' });
        $routeProvider.when('/operator/:ouId', { templateUrl: '/App/Operator/Views/OperatorView.html', controller: 'operatorViewModel' });
        //$routeProvider.when('/ou/:ouId', { templateUrl: '/App/Categories/Views/OrganisationalUnitView.html', controller: 'organisationalUnitViewModel' });
        $routeProvider.otherwise({ redirectTo: '/operators' });
        //$locationProvider.html5Mode(true);
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

operatorModule.factory('operatorService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.operatorService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var operatorService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;

        self.ouId = 0;

        return this;
    };
    myApp.operatorService = operatorService;
}(window.MyApp));