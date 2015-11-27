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
	$scope.months = ["janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho"];
  $scope.categories = ['Computadores', 'Ratos', 'CDROMs'];
  $scope.salesPerCategory = [
    [65, 59, 80, 81, 56, 55, 40],
	[28, 48, 40, 19, 86, 27, 90],
	[10, 22, 35, 60, 55, 42, 30],
  ];


}]);
