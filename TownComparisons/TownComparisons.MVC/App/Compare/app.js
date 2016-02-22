//Service for adding objects to a list

/*
 * INSTRUCTIONS ON BOTTOM OF PAGE
*/

var collector = angular.module('collector', []);

collector.factory('collectorFactory', function () {
    var factory = {};
    //List that contains all selected subjects
    factory.listOfSubjects = [];

    //Add a subject to list
    factory.addSubject = function (subject) {
        factory.listOfSubjects.push(subject);
    }

    //Deletes from list
    factory.deleteSubject = function(subject) {
        factory.listOfSubjects.splice(factory.listOfSubjects.indexOf(subject), 1);
    }

    //Deletes from list if exists, else adds to list
    factory.toggleSubject = function(subject) {
        var exists = false;
        for (var i = 0; i < factory.listOfSubjects.length; i++) {
            if (factory.listOfSubjects[i] === subject) {
                exists = true;
            } 
        }

        if (exists) {
            factory.deleteSubject(subject);
        } else {
            factory.addSubject(subject);
        }
    }

    //Deletes all in list
    factory.deleteAllSubjects = function() {
        factory.listOfSubjects.length = 0;
    }

    return factory;
});

//INSTRUCTIONS
//htmlpage = AndreasTest/Index.cshtml

//TEST APP
var testApp = angular.module("testApp", ['common']);

//TEST CONTROLLER
testApp.controller("listViewModel", ['$scope', 'collectorFactory', function ($scope, collectorFactory) {

    //Dummy data
    $scope.categories = ["Skola1", "Skola2", "Skola3", "Skola4", "Skola5"];

    //This is the list of selected items
    $scope.listItems = collectorFactory.listOfSubjects;

    //add items to a list
    $scope.addSubject = function (subject) {
        collectorFactory.addSubject(subject);
    }

    //remove item from a list
    $scope.removeSubject = function(subject) {
        collectorFactory.deleteSubject(subject);
    }

    //toggle items on the list
    $scope.toggleSubject = function (subject) {
        collectorFactory.toggleSubject(subject);
    }

    //deletes all item on the list
    $scope.deleteAllSubjects = function () {
        collectorFactory.deleteAllSubjects();
    }
}]);
