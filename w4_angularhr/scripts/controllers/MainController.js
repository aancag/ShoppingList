/**
 * Created by Anca on 22.10.2014.
 */
hrApp.controller('MainController', ['$scope', function($scope) {
    $scope.title = 'Shopping List';
    $scope.products = [
        {
            "name" : "castraveti",
            "quantity" : "2kg",
            "edit": false,
            "bought" : false
        },
        {
            "name" : "ciocolata",
            "quantity" : "fara numar",
            "edit" : false,
            "bought" : false
        }
    ];
    $scope.descriptionShow = false;
    $scope.toggleDescriptionShow = function() {
        if($scope.descriptionShow == true) {
            $scope.descriptionShow = false;
        } else {
            $scope.descriptionShow = true;
        }
    };

    $scope.create = function (product) {
        $scope.products.push(
            {
                "name" : product.name,

                "quantity" : product.quantity,

                "edit" : product.edit,
                "bought" : product.bought
            }
        );
    }

    $scope.toggleEditShow = function(product) {
        if(product.edit == true) {
            product.edit = false;
        } else {
            product.edit = true;
        }
    };

    $scope.toggleBoughtShow = function(product) {
        if(product.bought == true) {
            product.bought = false;
        } else {
            product.bought = true;
        }
    };
    $scope.deleteBoughtProducts = function(){
        $scope.products = $scope.products.filter(function(product){
            return product.bought == false;
        });
    }
}

]);