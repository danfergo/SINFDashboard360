angular.module('dash-sales').
controller('salesController', ['$scope','Sale','$filter', function ($scope, Sale,$filter) {
	$scope.$parent.pageTitle = "Vendas";

	$scope.today = new Date(); 
	$scope.maxDate = new Date(); 
	$scope.minDate = new Date();
	$scope.minDate.setDate($scope.maxDate.getDate()-90);


	$scope.filterResults = function(){
		$scope.sales = null;
		Sale.query({
					min_date: $filter('date')($scope.minDate,'dd-MM-yyyy'),
				 	max_date: $filter('date')($scope.maxDate,'dd-MM-yyyy') 
					}, 
		function(data){
			$scope.sales = data;
		});
	}
	
	$scope.filterResults();

	$scope.toggle = function(event){
		$(event.currentTarget).toggleClass('active');
	}
}]);
