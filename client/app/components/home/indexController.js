angular.module('dash-home').
controller('indexController', ['$scope', function ($scope) {
	$scope.$parent.pageTitle = "Início";


	$scope.months = ["may", "jun", "jul", "ago","set","out","nov","dec"];
	
	$scope.purchasesNsales = ['Compras', 'Vendas'];
	$scope.purchasesNsalesValues = [
		[65, 59, 32, 35,30, 58, 60, 90],
		[70, 65, 43,45, 40, 72, 70, 110]
	];

	$scope.categories = ["Ratos", "Computadores", "Acessórios", "Scanners", "Teclados", "Modems"];
  	$scope.salesPerCategory = [3000, 5000, 1000,200,2300,1000];
}]);
