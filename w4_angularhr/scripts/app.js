/**
 * Created by Anca on 22.10.2014.
 *
 */

var myFiltersModule = angular.module('myFilters', []);

var hrApp = angular.module('hrApp', ['ngRoute', 'ngResource', 'myFilters']);
hrApp.config(['$routeProvider',
    function($routeProvider) {
        $routeProvider
            .otherwise({/* intra pe orice ruta daca nu gaseste una definita, stabileste ruta default */
                templateUrl: 'templates/main.html',
                controller: 'MainController'
            });
    }]);

hrApp.directive("Bought", function(){
    return {
        restrict : "E",
        template: "<th>Bought</th>"
    }
});