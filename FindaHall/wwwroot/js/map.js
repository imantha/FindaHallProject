function initMap() {
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
    var locations = [
        ['Bondi Beach', -29.256439, 152.932056, 4],
        ['Coogee Beach', -29.820794, 152.765033, 5],
        ['Cronulla Beach', -30.254566, 152.403798, 3],

    ];

    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 10,
        center: new google.maps.LatLng(-30.254566, 152.403798),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    var infowindow = new google.maps.InfoWindow();
    
    var marker, i;
    var styleIcon = new StyledIcon(StyledIconTypes.BUBBLE, { color: "#ffffff", text: "$100" });
    for (i = 0; i < locations.length; i++) {
        marker = new StyledMarker({
            position: new google.maps.LatLng(locations[i][1], locations[i][2]),
            styleIcon: styleIcon,
            map: map
        });

        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                //infowindow.setContent(locations[i][0]);
                //infowindow.open(map, marker);
                document.getElementById('id01').style.display = 'block';
            };
        })(marker, i));
    }
}




