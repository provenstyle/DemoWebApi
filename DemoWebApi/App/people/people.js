define(function(require){
	
    var crudVm = require('viewmodels/crudViewModel');
    var domainItemCtor = require('domain/person');
    var dataService = require('services/crudDataService');
    var service = new dataService("api/people");
    var vm = new crudVm(domainItemCtor, service, "people");

    return vm;
	
});