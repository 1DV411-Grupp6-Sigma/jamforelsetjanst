
var adminModule = angular.module('admin', ['common', 'ngFileUpload'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/admin', { templateUrl: '/App/Admin/Views/AdminHomeView.html', controller: 'adminHomeViewModel' });
        $routeProvider.when('/admin/categories', { templateUrl: '/App/Admin/Views/AdminCategoriesView.html', controller: 'adminCategoriesViewModel' });
        $routeProvider.when('/admin/category/:categoryId', { templateUrl: '/App/Admin/Views/AdminCategoryShowView.html', controller: 'adminCategoryShowViewModel' });
        $routeProvider.when('/admin/category/:categoryId/edit', { templateUrl: '/App/Admin/Views/AdminCategoryEditView.html', controller: 'adminCategoryEditViewModel' });
        //$routeProvider.when('/admin/category/:categoryId/operator/:operatorId', { templateUrl: '/App/Admin/Views/AdminOperatorView.html', controller: 'adminOperatorViewModel' });
        //$routeProvider.when('/admin/category/:categoryId/query/:queryId', { templateUrl: '/App/Admin/Views/AdminQueryView.html', controller: 'adminQueryViewModel' });
        $routeProvider.otherwise({ redirectTo: '/admin' });

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

        self.getCategory = function (categoryId, success, failure) {
            doGetCategory(categoryId, true, success, failure);
        }
        self.getNormalCategory = function (categoryId, success, failure) {
            doGetCategory(categoryId, false, success, failure);
        }
        var doGetCategory = function(categoryId, adminModel, success, failure) {
            viewModelHelper.apiGet('api' + (adminModel ? '/admin' : '') + '/category/' + categoryId, null,
                function (result) {
                    self.categoryId = categoryId;
                    $rootScope.category = result.data;
                    if (success != null) {
                        success();
                    }
                },
                failure
            );
        }


        self.parseErrors = function (errors) {
            $rootScope.validationErrors = [];
            $rootScope.knownValidationErrors = [];
            $rootScope.closeValidationAlert = false;

            if (errors.data && errors.data.ModelState && angular.isObject(errors.data.ModelState)) {
                for (var key in errors.data.ModelState) {
                    for (var i = 0; i < errors.data.ModelState[key].length; i++) {
                        $rootScope.validationErrors.push({ name: key, message: errors.data.ModelState[key][i] });
                    }
                }
            } else {
                $rootScope.validationErrors.push('Kunde inte utföra åtgärden, kontrollera att allt är rätt inmatat.');
            };
        }

        $rootScope.hasValidationError = function (errorName) {
            //console.log('checking for error: ' + errorName);
            var errors = $rootScope.getValidationErrors(errorName);
            if (errors.length > 0) {
                console.log('errors found!');
                return true;
            }

            return false;
        }
        $rootScope.getValidationErrorMessage = function (errorName) {
            var errors = $rootScope.getValidationErrors(errorName);
            if (errors.length > 0)
                return errors[0].message;
            else
                return '';
        }
        $rootScope.getValidationErrors = function (errorName) {
            if (!$rootScope.knownValidationErrors) { $rootScope.knownValidationErrors = []; }

            if ($rootScope.validationErrors) {
                var result = $rootScope.validationErrors.filter(function (obj) {
                    return obj.name == errorName;
                });
                if (result.length > 0) {
                    //move errors found from the general array to known errors array
                    for (i = $rootScope.validationErrors.length - 1; i >= 0; i--) {
                        if ($rootScope.validationErrors[i].name == errorName) {
                            $rootScope.knownValidationErrors.push($rootScope.validationErrors[i]);
                            $rootScope.validationErrors.splice(i, 1);
                        }
                    }
                }
                var resultFromKnown = $rootScope.knownValidationErrors.filter(function (obj) {
                    return obj.name == errorName;
                });

                return result.concat(resultFromKnown);
            }
            return [];
        }

        $rootScope.closeAlert = function (index) {
            //viewModelHelper.flashMessages.splice(index, 1);
        };


        self.adminId = 0;

        return this;
    };
    myApp.adminService = adminService;
}(window.MyApp));
