define(function(require){
	
	var crudVM = require('viewmodels/crudViewModel');
	var ctr = require('domain/person');
	var service = require('services/peopleService');
	var vm = new crudVM(ctr, service, "people"); 

	return vm;
	
});