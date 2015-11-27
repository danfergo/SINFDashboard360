angular.module('dash-catalog').
controller('catalogController', ['$scope', 'Product', 'ProductCategory', '$stateParams', function ($scope, Product, ProductCategory, $stateParams) {
	$scope.$parent.pageTitle = "Catálogo";
	$scope.products = null;
	$scope.categories = null;
	$scope.includeOutOfStock = false;

	Product.get({id:$stateParams.categoryId},function(data){
		$scope.products = data;
	});

	ProductCategory.query(function(data){
		$scope.categories = data;
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
			if(product.stock > 0)
				return "In stock";
			else
				return 0;
		}

		$scope.IdentifyCategory = function(category_id){
			var length = $scope.categories ? $scope.categories.length : 0;
			for(var i = 0; i<length; i++)
			{
				if($scope.categories[i].category_id === category_id)
					return $scope.categories[i].description;			
			}
			return "No category associated";
		}
}]);
