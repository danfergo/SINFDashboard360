angular.module('dash-catalog').
controller('catalogController', ['$scope', 'Product', 'ProductCategory', function ($scope, Product, ProductCategory) {
	$scope.$parent.pageTitle = "Catálogo";
	$scope.products = null;
	$scope.categories = null;
	$scope.includeOutOfStock = false;
	$scope.filterCategories = {};
	$scope.filterQuantity = {};


	var selectedCategoriesIds = function () {
		var categoriesIds = [];
		for(var i in $scope.filterCategories){
			if($scope.filterCategories[i]) categoriesIds.push(i);
		}
		return categoriesIds;
	}
	var filterByCategory = function (products) {
		var selecCategoriesIds = selectedCategoriesIds();
		if(selecCategoriesIds.length == 0) return products;
		else return products.filter(function(product){
				if(selecCategoriesIds.indexOf(product.category_id) == -1){
					return false;
				}else {
					return true;
				}
			})
	}

	var filterByQuantity = function (products) {
		if( !$scope.filterQuantity['out'] && 
			!$scope.filterQuantity['min'] && 
			!$scope.filterQuantity['ok'] && 
			!$scope.filterQuantity['excedes']
			) return products;
		else { return products.filter(function(product){
							return  ($scope.filterQuantity['out'] && product.stock <=  0) || 
									($scope.filterQuantity['min'] && product.stock <  product.stockMin) || 
									($scope.filterQuantity['ok']  && (product.stock >= product.stock && product.stock <= product.stock) )  || 
									($scope.filterQuantity['excedes'] && product.stock > product.stockMax);
						});
		}
	}

	$scope.filteredProducts = function () {
		return  filterByQuantity(filterByCategory($scope.products));
	}
	
	ProductCategory.query(function(data){
		$scope.categories = data;
		Product.get(function(data){
			$scope.products = data;
		});
	});

		/*this.infiniteItems = {
          numLoaded_: 0,
          toLoad_: 0,
          // Required.
          getItemAtIndex: function(index) {
            if (index > this.numLoaded_) {
              this.fetchMoreItems_(index);
              return null;
            }
            return index;
          },
          // Required.
          // For infinite scroll behavior, we always return a slightly higher
          // number than the previously loaded items.
          getLength: function() {
            return this.numLoaded_ + 5;
          },
          fetchMoreItems_: function(index) {
            // For demo purposes, we simulate loading more items with a timed
            // promise. In real code, this function would likely contain an
            // $http request.
            if (this.toLoad_ < index) {
              this.toLoad_ += 20;
              $timeout(angular.noop, 300).then(angular.bind(this, function() {
                this.numLoaded_ = this.toLoad_;
              }));
          }
      }
  };*/

	$scope.toggle = function(event){
		$(event.currentTarget).toggleClass('active');
	}

	$scope.VerifyStock = function(product){
		//console.log(product.description +" max: " +product.stock + " min:" + product.stockMin)
		if(product.stock > 0)
			return "Artigo disponível";
		else
			return "Artigo indisponível";
	}

	$scope.IdentifyCategory = function(category_id){
		var length = $scope.categories ? $scope.categories.length : 0;
		for(var i = 0; i<length; i++)
		{
			if($scope.categories[i].category_id === category_id)
				return $scope.categories[i].description;			
		}
		return "Sem categoria associada";
	}
}]);
