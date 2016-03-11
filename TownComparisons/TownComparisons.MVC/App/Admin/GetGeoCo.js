function getGeo() {
    var address = document.getElementById('txtautocomplete').value;
    var Latitude = document.getElementById('Latitude').value;
    var Longitude = document.getElementById('Longitude').value;
    getLatitudeLongitude(showResult, address);
    var autocomplete = new google.maps.places.Autocomplete(document.getElementById("txtautocomplete"));
}
function showResult(result) {
    document.getElementById('Latitude').value = result.geometry.location.lat();
    document.getElementById('Longitude').value = result.geometry.location.lng();
}

function getLatitudeLongitude(callback, address) {
    // If adress is not supplied, use default value 'Kristianstad'
    address = address || 'Kristianstad';
    // Initialize the Geocoder
    geocoder = new google.maps.Geocoder();

    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            document.getElementById('Latitude').value = results[0].geometry.location.lat();
            document.getElementById('Longitude').value = results[0].geometry.location.lng();
        } else {
            alert("Omöjligt att hämta geografiska koordinater: " + status);
        }
    });
}