define(['domain/person', 'crud/crudDataService', 'crud/crudViewModel'], function (Person, CrudService, Vm) {

    var args = {
        itemConstructor: Person,
        dataService: new CrudService('api/people'),
        folderPath: 'people',
        heading: 'People'
    };

    var vm = new Vm(args);

    return vm;
	
});