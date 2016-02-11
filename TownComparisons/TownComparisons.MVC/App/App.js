var mainModule = angular.module('main', ['ngRoute']);

mainModule.controller('indexViewModel', function ($scope) {
    $scope.Message = "Angular is working.";
});