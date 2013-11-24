define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        search: function() {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: ['Courses', ''], moduleId: 'courses/courses', nav: true },
                { route: 'Instructors', moduleId: 'instructors/instructors', nav: true }
            ])
                .mapUnknownRoutes('courses/courses', '#Courses')
                .buildNavigationModel();
            
            return router.activate();
        }
    };
});