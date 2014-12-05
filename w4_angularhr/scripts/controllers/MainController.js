/**
 * Created by Anca on 22.10.2014.
 */
hrApp.controller('MainController', ['$scope', '$http', function($scope, $http) {
    $scope.title = 'Shopping List';
    $scope.products = [];
    $http({url:'http://localhost:34029/api/Values',
            method:'GET'}
    )
        .success(function (data) {//if request succeed
            $scope.products = data;
            console.log(data);
            console.log("get ok");
        }).error(function(data){
            console.log("get error");
        });

    $scope.descriptionShow = false;
    $scope.toggleDescriptionShow = function() {
        $scope.descriptionShow = !$scope.descriptionShow;
    };

    //add button
    $scope.create = function (product) {
        product =  {
            "Name" : product.Name,
            "Quantity" : product.Quantity,
            "Edit" : product.Edit,
            "Bought" : product.Bought
        };
        $scope.products.push(
            product
        );

        $http({url:'http://localhost:34029/api/Values/Post',
            method:'POST',
            dataType:"json",
            data:{
                Name : product.Name,
                Quantity : product.Quantity,
                Bought : product.Bought
            }}
        )
            .success(function (data) {//if request succeed
                console.log("post ok");
            }).error(function(data){
                console.log("post error");
            }
        );
    }

    $scope.toggleEditShow = function(product, name, quantity) {
        product.Edit = !product.Edit;
        if(product.Edit == false){
            product.Name = name;
            product.Quantity = quantity;
            $http({url:'http://localhost:34029/api/Values/' + product._id,
                    method:'PUT', data:product}
            )
                .success(function (data) {
                    console.log("put ok");
                }).error(function(data){
                    console.log("put error");
                }
            );


        }
    };

    $scope.toggleBoughtShow = function(product) {
        product.Bought = !product.Bought;
    };

    $scope.deleteBoughtProducts = function(){
          for(var i = 0; i < $scope.products.length; i++){
            if($scope.products[i].Bought == true){

                $http({url:'http://localhost:34029/api/Values/' + $scope.products[i]._id,
                        method:'DELETE'}
                )
                    .success(function (data) {//if request succeed
                        $http({url:'http://localhost:34029/api/Values',
                                method:'GET'}
                        )
                            .success(function (data) {//if request succeed
                                $scope.products = data;
                            }).error(function(data){
                                console.log("get error");
                            });
                    }).error(function(data){
                        console.log("delete error");
                    });
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