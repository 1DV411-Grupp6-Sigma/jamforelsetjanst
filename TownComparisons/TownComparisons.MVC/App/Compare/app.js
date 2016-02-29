//Service for adding objects to a list

/*
 * INSTRUCTIONS ON BOTTOM OF PAGE
*/

var collector = angular.module('collector', []);

collector.factory('collectorFactory', ['$cookies', function ($cookies) {
    var factory = {};
    //Name of cookie
    var savedList = "savedList";
    //Expiration
    var expire = new Date(new Date().getTime() + 180 * 60000);

    //List that contains all selected subjects
    factory.listOfSubjects = $cookies.getObject(savedList) || [];
    

    //Add a subject to list
    factory.addSubject = function (subject) {
        factory.listOfSubjects.push(subject);

        console.log(factory.listOfSubjects.indexOf(subject));

        $cookies.putObject(savedList, factory.listOfSubjects, { "expires": expire });
    }

    //Deletes from list
    factory.deleteSubject = function(subject) {
        console.log(subject.Name);
        console.log(factory.listOfSubjects);
        console.log(factory.listOfSubjects.indexOf(subject));
        
        factory.listOfSubjects.splice(factory.listOfSubjects.indexOf(subject), 1);

        $cookies.putObject(savedList, factory.listOfSubjects, { "expires": expire });
        
    }

    //Deletes from list if exists, else adds to list
    factory.toggleSubject = function(subject) {
        var exists = false;
        for (var i = 0; i < factory.listOfSubjects.length; i++) {
            if (factory.listOfSubjects[i].OrganisationalUnitId === subject.OrganisationalUnitId) {
                subject = factory.listOfSubjects[i];
                exists = true;
                break;
            } 
        }

        if (exists) {
            factory.deleteSubject(subject);
            subject.icon = "fi-plus";
            subject.class = "beforeCompare";
            subject.text = "Jämför";
        } else {
            factory.addSubject(subject);
        }
    }

    //Deletes all in list
    factory.deleteAllSubjects = function() {
        factory.listOfSubjects.length = 0;
        $cookies.remove(savedList);
    }

    return factory;
}]);

//INSTRUCTIONS
/*
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
*/