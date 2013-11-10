define(function(require){
	
    var crudVm = require('crud/crudViewModel');
    var domainItemCtor = require('domain/person');
    var dataService = require('crud/crudDataService');
    var service = new dataService("api/people");
    var vm = new crudVm(domainItemCtor, service, "people");

    return vm;
	
});