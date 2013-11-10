define(['domain/person', 'crud/crudDataService', 'crud/crudViewModel'], function (Person, CrudService, Vm) {
    
    var service = new CrudService("api/people");
    var vm = new Vm(Person, service, "people");

    return vm;
	
});