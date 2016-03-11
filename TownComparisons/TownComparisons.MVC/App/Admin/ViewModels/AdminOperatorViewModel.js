adminModule.controller("adminOperatorViewModel", function ($scope, adminService, $http, $q, $routeParams, $window, $location, viewModelHelper, Upload, $modalInstance) {

    //$scope.viewModelHelper = viewModelHelper;
    //$scope.adminService = adminService;

    $scope.categoryId = $routeParams.categoryId;
    $scope.operatorId = adminService.selectedOperatorId;
    $scope.validationErrors = [];
    $scope.knownValidationErrors = [];
    $scope.closeValidationAlert = false;

    $scope.objectFields = [{ field: 'Name', title: 'Namn', textarea: false },
                            { field: 'ShortDescription', title: 'Kort beskrivning', textarea: true, id: 'ShortDescription' },
                            { field: 'LongDescription', title: 'Längre beskrivning', textarea: true, id: 'LongDescription' },
                            { field: 'Address', title: 'Adress', textarea: false, id: 'txtautocomplete' },
                            { field: 'Latitude', title: 'Latitude', textarea: false, id: 'Latitude' },
                            { field: 'Longitude', title: 'Longitude', textarea: false, id: 'Longitude' },
                            { field: 'Contact', title: 'Kontakt', textarea: false, id: 'Contact' },
                            { field: 'Telephone', title: 'Telefon', textarea: false, id: 'Telephone' },
                            { field: 'Email', title: 'E-post', textarea: false, id: 'Email' },
                            { field: 'Website', title: 'Webbsida', textarea: false, id: 'Website' },
                            { field: 'OrganisationalForm', title: 'Organisations-form', textarea: false, id: 'OForm' },
                            { field: 'Other', title: 'Övrigt', textarea: true, id: 'Other' }];

    //$scope.getGeoCoordinates = {
    //    autocomplete : new google.maps.places.Autocomplete(angular.element(document).find('txtautocomplete'));
    //    var Latitude = angular.element(document).find('latitude');
    //    var Latitude = angular.element(document).find('longitude');
    //    google.maps.event.addListener(autocomplete, 'place_changed', function () {
    //        var place = autocomplete.getPlace();
    //        $scope.operator.lat = place.geometry.location.lat();
    //        $scope.operator.lng = place.geometry.location.lng();
    //        //$scope.operator.ad = place.formatted_address;
    //        $scope.$apply();
    //    });
    //};

    function showResult(result) {
        document.getElementById('Latitude').value = result.geometry.location.lat();
        document.getElementById('Longitude').value = result.geometry.location.lng();
    }
    function getGeo() {
        var adress = document.getElementById('txtautocomplete').value;
    }
    function getLatitudeLongitude(callback, address) {
        // If adress is not supplied, use default value 'Kristianstad'
        address = address || 'Kristianstad';
        // Initialize the Geocoder
        geocoder = new google.maps.Geocoder();
        if (geocoder) {
            geocoder.geocode({
                'address': address
            }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    callback(results[0]);
                }
            });
        }
    }
    var button = document.getElementById('btn');

    if (button !== null) {
        button.addEventListener("click", function () {
            var address = document.getElementById('txtautocomplete').value;
            getLatitudeLongitude(showResult, address)
        });
    }

    var initialize = function () {
        var button = document.getElementById('btn');
        refreshOperator();
    }

    var refreshOperator = function () {
        viewModelHelper.apiGet('api/category/' + $scope.categoryId + '/operator/' + $scope.operatorId, null,
            function (result) {
                $scope.operator = result.data;
                $scope.operatorName = angular.copy($scope.operator.Name); //to use without data binding to the category
                $scope.pageHeading = $scope.operatorName;
            });
    }

    $scope.saveOperator = function () {

        viewModelHelper.apiPost('api/admin/category/' + $scope.categoryId + '/operator/' + $scope.operatorId, $scope.operator,
            function (result) {
                //success, close modal
                $modalInstance.close($scope.operator);
            },
            function (errors) {
                //failure
                adminService.parseErrors(errors);
            });
    }

    $scope.saveOperatorImage = function (imageFile) {

        $scope.upload = Upload.upload({
            url: MyApp.rootPath + 'api/admin/category/' + $scope.categoryId + '/operator/' + $scope.operatorId + '/image', // webapi url
            method: "POST",
            file: imageFile
        }).success(function (data, status, headers, config) {
            // file is uploaded successfully
            $scope.operator = data;
        }).error(function (data, status, headers, config) {
            // file failed to upload
            $scope.validationErrors.push({ name: '', message: 'Kunde inte spara bilden.' });
        });
    }

    $scope.cancelEditOperator = function () {
        //close (cancel) modal
        $modalInstance.dismiss('cancel');
    }

    initialize();
});
