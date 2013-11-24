define(['domain/instructor', 'crud/crudViewModel'], function (Instructor, Vm) {

    var args = {
        itemConstructor: Instructor,
        dataUrl: 'api/instructors',
        folderPath: 'instructors',
        heading: 'Instructors'
    };

    var vm = new Vm(args);

    return vm;

});