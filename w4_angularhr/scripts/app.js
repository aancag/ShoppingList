/**
 * Created by Anca on 22.10.2014.
 */
var hrApp = angular.module('hrApp', ['ngRoute', 'ngResource']);
hrApp.config(['$routeProvider',
    function($routeProvider) {
        $routeProvider
            .otherwise({/* intra pe orice ruta daca nu gaseste una definita, stabileste ruta default */
                templateUrl: 'templates/main.html',
                controller: 'MainController'
            });
    }]);