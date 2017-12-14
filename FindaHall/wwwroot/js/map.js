function initMap(mapobj) {
    var iconBase = 'https://maps.google.com/mapfiles/kml/shapes/';
    var icons = {
        parking: {
            icon: iconBase + 'parking_lot_maps.png'
        },
        library: {
            icon: iconBase + 'library_maps.png'
        },
        info: {
            icon: iconBase + 'info-i_maps.png'
        }
    };
    $.ajax({
        url: 'https://maps.googleapis.com/maps/api/geocode/json?address=' + mapobj[0].country +','+mapobj[0].city +','+ mapobj[0].street,
        type: 'GET',
        dataType: "json",
        success: function (json) {         
            var locations = [];
            for (var k = 0; k < mapobj.length; k++) {
                locations.push([mapobj[k].name, mapobj[k].latitude, mapobj[k].longitude, mapobj[k].price]);
            }

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 15,
                center: json.results[0].geometry.location,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });

            var infowindow = new google.maps.InfoWindow();

            var marker, i;
            
            for (var j = 0; j < locations.length; j++) {
                var styleIcon = new StyledIcon(StyledIconTypes.BUBBLE, { color: "#ffffff", text: '£'+locations[j][3] });
                marker = new StyledMarker({
                    position: new google.maps.LatLng(locations[j][1], locations[j][2]),
                    styleIcon: styleIcon,
                    map: map
                });

                google.maps.event.addListener(marker, 'click', (function (marker, i) {
                    return function () {
                        //infowindow.setContent(locations[i][0]);
                        //infowindow.open(map, marker);
                        //document.getElementById('selectedcity').value = Name;
                        $('#selectedcity').val(name);
                        document.getElementById('id01').style.display = 'block';
                    };
                })(marker, i));
            }

        },
        error: function (req, status, err) {

        }
    });
    
}




