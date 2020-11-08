ymaps.ready(init);
const uriSubstations = "/Home/GetAll/";
let substations = null;
let substation = [], coordinates = [];
var mark;

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
var myMap;
function init() {
    getSubstations();
    myMap = new ymaps.Map("map", {
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
        var coords = e.get('coords');
            coordinates = [coords[0].toPrecision(6), coords[1].toPrecision(6)];
        myMap.balloon.open(coords, {
            contentHeader: 'Событие!',
            contentBody: '<p>Для того, чтобы сохранить координаты щелкните по одной из кнопок справа сверху.</p>' +
                '<p>Координаты щелчка: ' + [
                    coords[0].toPrecision(6),
                    coords[1].toPrecision(6)
                ].join(', ') + '</p>',
            contentFooter: '<sup>Щелкните еще раз</sup>'
        });
            console.log(coordinates);
        myMap.events.remove('click', function (e) { });
    }
    else {
        myMap.balloon.close();
    }
    });

 
    firstButton = new ymaps.control.Button("Разместить подстанцию");
    myMap.controls.add(firstButton, { float: 'right' });

    firstButton2 = new ymaps.control.Button("Кнопка2");
    myMap.controls.add(firstButton2, { float: 'right' });
    ///добавить координаты подстанции
    firstButton.events.add('click', function (e) {
        myMap.balloon.close();
        substation = coordinates;
        if (mark) { myMap.geoObjects.remove(mark); }
        mark = new ymaps.Placemark(coordinates, {
            balloonContent: '<strong>Ваша</strong> подстанция'
        }, {
                preset: 'islands#icon',
                iconColor: '#0095b6'
            })
        myMap.geoObjects.add(mark);
    });
    firstButton2.events.add('click', function (e){
       
        
   
    });
    // Обработка события, возникающего при щелчке
    // левой кнопкой мыши в любой точке карты.
    // При возникновении такого события откроем балун.
   
}

function getCoordinates(e) {
    console.log(e);
    console.log(e.get('coords'));
    if (!myMap.balloon.isOpen()) {
        var coords = e.get('coords');
        substation = [coords[0].toPrecision(6), coords[1].toPrecision(6)];
        myMap.balloon.open(coords, {
            contentHeader: 'Событие!',
            contentBody: '<p>Кто-то щелкнул по карте.</p>' +
                '<p>Координаты щелчка: ' + [
                    coords[0].toPrecision(6),
                    coords[1].toPrecision(6)
                ].join(', ') + '</p>',
            contentFooter: '<sup>Щелкните еще раз</sup>'
        });
        console.log(substation);
        myMap.events.remove('click', function (e) { });
    }
    else {
        myMap.balloon.close();
    }
}