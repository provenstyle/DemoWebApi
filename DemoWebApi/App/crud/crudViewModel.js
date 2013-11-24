define(['crud/crudDataService', 'plugins/dialog'],function(dataService, dialog){

    var crudViewModel = function (args) {

        var itemConstructor = args.itemConstructor;
        var service = new dataService(args.dataUrl);
        var folder = args.folderPath;
        var heading = args.heading;

		var createPath = "crud/create.html";		
		var updatePath = "crud/update.html";
		var displayPath = folder + "/display.html";
		var editPath = folder + "/edit.html";
        var listItemPath = folder + "/listItem.html";

		var vm = {			
			selectedItem: {},
	    	updateItem: {},
			collection: {}
		};

		var activate = function() {
		    return service.getAll()
		        .done(function (data) {
		            vm.collection = data;
		            if (data && data.length > 0) {
		                vm.selectedItem = vm.collection[0];		                
		            }
		        });
		};

        var goToCreate = function() {
                vm.updateItem = new itemConstructor();
                dialog.show({
                    viewUrl: createPath,
                    vm: vm,
                    editPath: editPath,
                    create: function(data) {
                        create(data);
                        dialog.close(this);
                    },
                    cancel: function() {
                        dialog.close(this);
                    }
                });
            },
            
            goToUpdate = function() {
                vm.updateItem = _.clone(vm.selectedItem);
                dialog.show({
                    viewUrl: updatePath,
                    vm: vm,
                    editPath: editPath,
                    update: function(data) {
                        update(data);
                        dialog.close(this);
                    },
                    confirmDelete: function() {
                        var ctx = this;
                        dialog.showMessage("Are you sure?", 'Confirm Delete', ['Delete', 'Cancel'])
                            .done(function(result) {
                                if (result === 'Delete') {
                                    deleteCurrent();
                                    dialog.close(ctx);
                                }
                            });
                    },
                    cancel: function() {
                        dialog.close(this);
                    },
                });
            },            
            selectCurrent = function (item) {                
                vm.selectedItem = item;
                goToUpdate();
            },
            create = function() {
                var item = vm.updateItem;
                service.create(item)
                    .done(function(id) {
                        item.id = id;
                        vm.collection.push(item);
                        vm.selectedItem = item;                  
                    })
                    .fail(function() {
                        alert("Save failed.");
                    });
            },
            update = function() {
                var item = vm.updateItem;
                service.update(item)
                    .done(function() {
                        var target = _.find(vm.collection, function(data) {
                            return data.id === item.id;
                        });
                        if (target)
                            service.map(item, target);
                        vm.selectedItem = item;                        
                    })
                    .fail(function() {
                        alert('Update failed.');
                    });
            },
            deleteCurrent = function() {
                var item = vm.selectedItem;
                service.deleteItem(item)
                    .done(function() {
                        var index = _.indexOf(vm.collection, item);
                        vm.collection.splice(index, 1);
                        if (vm.collection.length > 0) {
                            vm.selectedItem = vm.collection[0];
                        }
                    })
                    .fail(function() {
                        alert('Failed to delete.');
                    });
            };

		return{
			activate: activate,
			vm: vm,
			
			heading: heading,

			displayPath: displayPath,
			editPath: editPath,
			listItemPath: listItemPath,

			goToCreate: goToCreate,
			goToUpdate: goToUpdate,			
			selectCurrent: selectCurrent,

			create:create,
			update: update,
			deleteCurrent: deleteCurrent
		};
	};

	return crudViewModel;
});