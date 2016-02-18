//Service for adding units to a list
mainModule.factory('collectorFactory', function() {
    var factory = {};
    //List that contains all selected subjects
    factory.listOfSubjects = [];

    //add a subject to list
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


//TEST CONTROLLER
mainModule.controller("listViewModel", ['$scope', 'collectorFactory', function ($scope, collectorFactory) {

    $scope.categories = ["Skola1", "Skola2", "Skola3", "Skola4", "Skola5"];

    $scope.listItems = collectorFactory.listOfSubjects;

    $scope.addSubject = function (subject) {
        collectorFactory.addSubject(subject);
    }
    $scope.removeSubject = function(subject) {
        collectorFactory.deleteSubject(subject);
    }
    $scope.toggleSubject = function (subject) {
        collectorFactory.toggleSubject(subject);
    }
    $scope.deleteAllSubjects = function () {
        collectorFactory.deleteAllSubjects();
    }


}]);
