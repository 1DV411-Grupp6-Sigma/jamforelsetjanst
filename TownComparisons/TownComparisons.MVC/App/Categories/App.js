
var categoryModule = angular.module('category', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        //$routeProvider.when('/', { templateUrl: '/App/Categories/Views/CategoriesView.html', controller: 'categoriesViewModel' });
        $routeProvider
            .when('/categories', {
                 templateUrl: '/App/Categories/Views/CategoriesView.html', controller: 'categoriesViewModel'
            })
            //Show sorting A-Ö
            .when('/categories/alphabet', {
                     templateUrl: '/App/Categories/Views/AlphabetView.html', controller: 'categoriesViewModel'
                })
            //Default is detailed list
            .when('/category/:categoryId', {
                     templateUrl: '/App/Category/Views/CategoryView.html', controller: 'categoryViewModel'
                })
            //View simple list
            .when('/category/:categoryId/enkel', {
                templateUrl: '/App/Category/Views/SimpleView.html',
                controller: 'categoryViewModel'
            })
            .when('/category/:categoryId/compare', {
                     templateUrl: '/App/Category/Views/CompareView.html',
                     controller: 'compareViewModel'
                })
            .when('/category/:categoryId/operator/:operatorId', {
                     templateUrl: '/App/Category/Views/OperatorView.html', controller: 'operatorViewModel'
                })
            .otherwise({ redirectTo: '/categories' });
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

        //load a category
        self.getCategory = function (categoryId, success, failure) {
            viewModelHelper.apiGet('api/category/' + categoryId, null,
                function (result) {
                    $rootScope.category = result.data;

                    if (success != null) {
                        success();
                    }
                },
                failure
            );
        }

        return this;
    };
    myApp.categoryService = categoryService;
}(window.MyApp));



//Factory for global functions on categoryModule
categoryModule.factory('categoriesFactory', function (viewModelHelper) {
    var factory = {};

    //Show all organisational units inside a category
    factory.showCategory = function (category) {
        viewModelHelper.navigateTo('category/' + category.Id);
    }


    //Switch between sorting
    factory.changeView = function (value) {
        if (value == undefined) {
            viewModelHelper.navigateTo('categories');
        }
        else {
            viewModelHelper.navigateTo('categories' + value);
        }
    }

    //Switch between listing
    factory.changeListView = function (value, urlParam) {
        if (value == undefined) {
            viewModelHelper.navigateTo('category/' + urlParam);
        }
        else {
            viewModelHelper.navigateTo('category/' + urlParam + value);
        }
    }


    return factory;
});
