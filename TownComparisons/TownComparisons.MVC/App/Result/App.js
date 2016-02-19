var resultModule = angular.module('result', ['common']) //inject compare
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/result', { templateUrl: '/App/Result/Views/ResultHomeView.html', controller: 'ResultHomeViewModel' });
        $routeProvider.otherwise({ redirectTo: '/result' });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

resultModule.factory('resultService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.resultService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var resultService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;

        //self.operatorsId = 0;

        return this;
    };
    myApp.resultService = resultService;
}(window.MyApp));