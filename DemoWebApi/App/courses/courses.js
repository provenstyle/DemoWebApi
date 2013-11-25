define(['domain/course', 'crud/crudViewModel'], function (Course, Vm) {
    return new Vm({
        itemConstructor: Course,
        dataUrl: 'api/courses',
        folderPath: 'courses',
        heading: 'Courses'
    });
});