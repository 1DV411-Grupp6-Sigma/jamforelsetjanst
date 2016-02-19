
var categoryModule = angular.module('category', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/category/:categoryId', { templateUrl: '/App/Category/Views/CategoryView.html', controller: 'categoryViewModel' });
        $routeProvider.when('/category/:categoryId/compare', { templateUrl: '/App/Category/Views/CompareView.html', controller: 'compareViewModel' });
        $routeProvider.when('/category/:categoryId/operator/:operatorId', { templateUrl: '/App/Category/Views/OperatorView.html', controller: 'operatorViewModel' });
        $routeProvider.otherwise({ redirectTo: '/' });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    });

categoryModule.factory('categoryService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.categoryService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var categoryService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        var self = this;

        self.listOfSubjects = [];

        //Add a subject to list
        self.addSubject = function (subject) {
            self.listOfSubjects.push(subject);
        }

        //Deletes from list
        self.deleteSubject = function (subject) {
            self.listOfSubjects.splice(self.listOfSubjects.indexOf(subject), 1);
        }

        //Deletes from list if exists, else adds to list
        self.toggleSubject = function (subject) {
            var exists = false;
            for (var i = 0; i < self.listOfSubjects.length; i++) {
                if (self.listOfSubjects[i] === subject) {
                    exists = true;
                }
            }

            if (exists) {
                self.deleteSubject(subject);
            } else {
                self.addSubject(subject);
            }
        }

        //Deletes all in list
        self.deleteAllSubjects = function () {
            self.listOfSubjects.length = 0;
        }

        self.getSubjectList = function () {
            return self.listOfSubjects;
        }

        return this;
    };
    myApp.categoryService = categoryService;
}(window.MyApp));
