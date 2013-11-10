requirejs.config({
    paths: {
        'text': '../scripts/text',
        'knockout': '../scripts/knockout-2.3.0',
        'jquery': '../scripts/jquery-1.9.1',
        'bootstrap': '../scripts/bootstrap',
        'durandal':'../scripts/durandal',
        'plugins' : '../scripts/durandal/plugins',
        'transitions' : '../scripts/durandal/transitions',
        'underscore' : '../scripts/underscore'
    },
    shim: {
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
        }, 

        'underscore':{
            exports: '_'
        }       
    }
});

define(function(require) {
    var app = require('durandal/app'),
        viewLocator = require('durandal/viewLocator'),
        system = require('durandal/system'),
        _ = require('underscore');

    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = 'Durandal Starter Kit';

    app.configurePlugins({
        observable: true,
        router:true,
        dialog: true,
        widget: true
    });

    app.start().then(function() {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();
        viewLocator.translateViewIdToArea = function (viewId, area) {
                return viewId;
            };

        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell', 'entrance');
    });
});