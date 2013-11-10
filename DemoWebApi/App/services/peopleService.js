define(['underscore', 'knockout', 'domain/person', 'plugins/http'], function(_, ko, person, http){

    var url = 'api/people';

    var create = function(person) {
        var args = {
            type: 'POST',
            url: url,
            cache: false,
            dataType: 'json',
            data: person
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
        deleteItem = function(person) {
            var args = {
                type: 'DELETE',
                url: url + "/" + person.id,
                cache: false,
                dataType: 'json'
            };

            return $.ajax(args);

        },
        map = function(source, destination) {
            destination.first = source.first;
            destination.last = source.last;
        };

	return{
		create:create,
		getAll:getAll,
		update:update,
		deleteItem: deleteItem,
		map: map
	};
});