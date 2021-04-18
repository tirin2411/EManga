/// <reference path="../lib/angular/angular.js" />

(function () {
    angular.module('fmn',
        [ 'statistics',
            'common'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('home', {
                url: "/home/index",
                parent: 'base',
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
    }
})();