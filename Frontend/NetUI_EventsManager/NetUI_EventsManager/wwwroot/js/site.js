// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



    // Inicializar el mapa
    var map = L.map('map').setView([0, 0], 2);  // Coordenadas iniciales y nivel de zoom

    // Añadir un "tile layer" de OpenStreetMap
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    // Añadir un marcador
    var marker = L.marker([0, 0], {draggable: true }).addTo(map);

    // Función para actualizar las cajas de texto con las coordenadas del marcador
    function updateCoordinates(e) {
        var latlng = marker.getLatLng();
    document.getElementById('Latitude').value = latlng.lat.toFixed(6);
    document.getElementById('Longitude').value = latlng.lng.toFixed(6);
    }

    // Asignar el evento de arrastre del marcador para actualizar las coordenadas
    marker.on('drag', updateCoordinates);

    // Asignar el evento de cambio de vista del mapa para actualizar las coordenadas
    map.on('move', function (e) {
        var center = map.getCenter();
    document.getElementById('latitude').value = center.lat;
    document.getElementById('longitude').value = center.lng;
    });
