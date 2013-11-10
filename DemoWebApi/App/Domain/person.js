define(['plugins/observable'], function(observable){
	
	var person = function(first, last){
		this.id = -1;
		this.first = first || "";
		this.last = last || "";
	};

	return person;
});