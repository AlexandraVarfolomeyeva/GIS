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
    let subCoordinates = [];
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
    myMap.controls.add('zoomControl');

    for (j in substations) {
        substationsCollection.add(new ymaps.Placemark([substations[j].coordinatesX, substations[j].coordinatesY], {
            balloonContent: substations[j].name
        }));
    };
    
    myMap.geoObjects.add(substationsCollection);

    myMap.events.add('click', function (e) {
        if (!myMap.balloon.isOpen()) {
            var coords = e.get('coordPosition');
            myMap.balloon.open(coords, {
                //contentHeader: 'Событие!',
                contentBody:
                    '<p>Кто-то щелкнул по карте.</p>' +
                    '<p>Координаты щелчка: ' + [
                        coords[0].toPrecision(6),
                        coords[1].toPrecision(6)
                    ].join(', ') + '</p>',
                contentFooter: '<sup>Щелкните еще раз</sup>'
            });
        }
        else {
            myMap.balloon.close();
        }
    });

    myMap.events.add('contextmenu', function (e) {
        myMap.hint.show(e.get('coordPosition'), 'Кто-то щелкнул правой кнопкой');
    });

}
