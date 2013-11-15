define(['domain/person', 'crud/crudViewModel'], function (Person, Vm) {

    var args = {
        itemConstructor: Person,
        dataUrl: 'api/people',
        folderPath: 'people',
        heading: 'People'
    };

    var vm = new Vm(args);

    return vm;
	
});