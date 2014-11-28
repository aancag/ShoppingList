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
          for(var i = 0; i < $scope.products.length; i++){

            if($scope.products[i].bought == true){
                $scope.products.splice(i, 1);
                i--;
            }
        }
    }
}
]);

myFiltersModule.filter('customFilter', [
    function() {
    return function (products, searchText) {
        var filtered = [];
        if(searchText == null){
            return products;
        }
        for (var i = 0; i < products.length; i++) {
            var item = products[i];
            if(angular.equals(searchText, item.name.substring(0, searchText.length) )){
                filtered.push(item);
            }
        }
        return filtered;
    };
}]);