define([], function(){

	var crudViewModel = function(itemConstructor, service, folder){
		var createPath = folder + "/create.html";
		var readPath = folder + "/read.html";
		var updatePath = folder + "/update.html";
		var deletePath = folder + "/confirmDelete.html";

		var vm = {
			selectedView: readPath,
			selectedItem: {},
	    	updateItem: {},
			collection: {}
		};

		var activate = function() {
		    return service.getAll()
		        .done(function (data) {
		            
		            vm.collection = data;
		            if(data && data.length > 0)
		                vm.selectedItem = vm.collection[0];
		        });
		};

		var goToCreate = function(){
				vm.updateItem = new itemConstructor();
				vm.selectedView = createPath;
			}, 
			goToRead = function(){
				vm.selectedView = readPath;
			},
			goToUpdate = function(){
				vm.updateItem = _.clone(vm.selectedItem);
				vm.selectedView = updatePath;
			},	
			goToConfirmDelete = function(){
				vm.selectedView = deletePath;
			},
			selectCurrent = function(item){
				vm.selectedItem = item;
				goToRead();	
			},
			create = function () {
			    var item = vm.updateItem;
			    service.create(item)
			        .done(function(id) {
			            item.id = id;
			            vm.collection.push(item);
			            vm.selectedItem = item;
			            goToRead();
			        })
			        .fail(function() {
			            alert("Save failed.");
			        });
			},
			update = function () {
			    var item = vm.updateItem;
			    service.update(item)
			        .done(function () {
			            var target = _.find(vm.collection, function (data) {
			                return data.id === item.id;
			            });
			            if (target)
			                service.map(item, target);
			            vm.selectedItem = item;
			            goToRead();
			        })
			        .fail(function() {
			            alert('Update failed.');
			        });
			},
			deleteCurrent = function () {

			    var item = vm.selectedItem;
			    service.deleteItem(item)
			        .done(function() {
			            var index = _.indexOf(vm.collection, item);
			            vm.collection.splice(index, 1);
			            if(vm.collection.length > 0)
    			            vm.selectedItem = vm.collection[0];
			            goToRead();
			        })
			        .fail(function() {
			            alert('Failed to delete.');
			        });
			};
		
		return{
			activate: activate,
			vm:vm,
			goToCreate: goToCreate,
			goToUpdate: goToUpdate,
			goToRead: goToRead,
			goToConfirmDelete: goToConfirmDelete,
			selectCurrent: selectCurrent,

			create:create,
			update: update,
			deleteCurrent: deleteCurrent,
		};
	};

	return crudViewModel;

});