angular.module('dash-home').
controller('indexController', ['$scope', function ($scope) {
		$scope.$parent.pageTitle = "Início";


	$scope.months = ["jan", "feb", "mar", "abr", "may", "jun", "jul"];
	$scope.purchasesNsales = ['Compras', 'Vendas'];
	$scope.purchasesNsalesValues = [
		[65, 59, 80, 81, 56, 55, 40],
		[28, 48, 40, 19, 86, 27, 90]
	];

	$scope.categories = ["Download Sales", "In-Store Sales", "Mail-Order Sales"];
  	$scope.salesPerCategory = [300, 500, 100];
}]);
