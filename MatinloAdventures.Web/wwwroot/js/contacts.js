var map;
function initMap() {

  var location = { lat: 42.660183, lng: 23.314518 };

  var map = new google.maps.Map(document.getElementById('map'),
      {
          zoom: 16,
          center: location
      });

  var marker = new google.maps.Marker({
      position: location,
      map: map
  });
}