ymaps.ready(function () {
    var myMap = new ymaps.Map("map", {
        center: [45.0448, 38.976],
        zoom: 10
    }, {
        searchControlProvider: 'yandex#search'
    });

    // Функция для добавления маркеров из переданных данных
    window.addMarkers = function (accounts, dotNetReference) {
        accounts.forEach(function (account) {
            // Геокодирование адреса
            ymaps.geocode(account.address, { results: 1 }).then(function (res) {
                var firstGeoObject = res.geoObjects.get(0);
                if (firstGeoObject) {
                    var coords = firstGeoObject.geometry.getCoordinates();
                    var placemark = new ymaps.Placemark(coords, {
                        hintContent: account.address,
                        balloonContent: `<strong>${account.address}</strong><br>Потребление: ${account.consumption || 'Нет данных'} кВт`
                    }, {
                        preset: 'islands#blueHomeIcon',
                        iconColor: '#0095b6'
                    });

                    // Добавление события клика для вызова C# метода
                    placemark.events.add('click', function () {
                        dotNetReference.invokeMethodAsync('NavigateToClientCard', account.id);
                    });

                    myMap.geoObjects.add(placemark);
                } else {
                    console.warn(`Не удалось геокодировать адрес: ${account.address}`);
                }
            }, function (err) {
                console.error(`Ошибка геокодирования для адреса ${account.address}:`, err);
            });
        });

        // Скрыть спиннер после загрузки
        document.getElementById('spinner').style.display = 'none';
    };
});