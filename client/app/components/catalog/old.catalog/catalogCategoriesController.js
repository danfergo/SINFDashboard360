angular.module('dash-catalog').
controller('catalogCategoriesController', ['$scope', 'Product', 'ProductCategory', function ($scope, Product, ProductCategory) {
		$scope.$parent.pageTitle = "Catálogo";
		$scope.products = null;
		$scope.categories = null;

	ProductCategory.query(function(data){
		$scope.categories = data;
	});

}]);
