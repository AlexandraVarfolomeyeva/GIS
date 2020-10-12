// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
ymaps.ready(init);
const uriSubstations = "/Home/GetAll/";
let substations = null;

function getSubstations() {
    var request2 = new XMLHttpRequest();
    request2.open("GET", uriSubstations, false);
    substations = null;
    request2.onload = function () {
        if (request2.status === 200) {
            substations = JSON.parse(request2.responseText);
        } else if (request2.status !== 204) {
            alert("Возникла неизвестная ошибка! Попробуйте повторить позже! Статус ошибки: " + request2.status);
        }
    };
    request2.send();
}

function init() {
    getSubstations();
    let subCoordinates=[];
    for (j in substations) {
        let coord = [substations[j].coordinatesX, substations[j].coordinatesY]
        subCoordinates.push(coord);
    };

    var myMap = new ymaps.Map("map", {
        center: [57.001268663457466, 40.973785368007455],
        zoom: 12
    }, {
            searchControlProvider: 'yandex#search'
        }),
        substationsCollection = new ymaps.GeoObjectCollection(null, {
            preset: 'islands#yellowIcon'
        })
        for (var i = 0, l = subCoordinates.length; i < l; i++) {
            substationsCollection.add(new ymaps.Placemark(subCoordinates[i]));
        }
       myMap.geoObjects.add(substationsCollection);
   
}
