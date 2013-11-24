define(['domain/course', 'crud/crudViewModel'], function (Course, Vm) {

    var args = {
        itemConstructor: Course,
        dataUrl: 'api/courses',
        folderPath: 'courses',
        heading: 'Courses'
    };

    var vm = new Vm(args);

    return vm;

});