define([], function() {

    var ctor = function(url) {

        var create = function(item) {
            var args = {
                type: 'POST',
                url: url,
                cache: false,
                dataType: 'json',
                data: item
            };
            return $.ajax(args);
        },
            getAll = function() {
                var args = {
                    type: 'GET',
                    url: url,
                    cache: false,
                    dataType: 'json'
                };
                return $.ajax(args);
            },
            update = function(item) {
                var args = {
                    type: 'PUT',
                    url: url + "/" + item.id,
                    cache: false,
                    dataType: 'json',
                    data: item
                };
                return $.ajax(args);
            },
            deleteItem = function(item) {
                var args = {
                    type: 'DELETE',
                    url: url + "/" + item.id,
                    cache: false,
                    dataType: 'json'
                };

                return $.ajax(args);

            };
            function map(source, destination) {
                for (var property in source)
                    destination[property] = source[property];
            };

        return {
            create: create,
            getAll: getAll,
            update: update,
            deleteItem: deleteItem,
            map: map
        };
    };

    return ctor;
});