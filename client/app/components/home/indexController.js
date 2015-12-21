angular.module('dash-home').
controller('indexController', ['$scope', 'sales', 'purchases','$filter', function ($scope,sales,purchases,$filter) {
	$scope.$parent.pageTitle = "Início";


	$scope.months = ["may", "jun", "jul", "ago","set","out","nov","dec"];
	
	$scope.purchasesNsales = ['Compras', 'Vendas'];
	$scope.purchasesNsalesValues = [
		[65, 59, 32, 35,30, 58, 60, 90],
		[70, 65, 43,45, 40, 72, 70, 110]
	];

	$scope.categories = ["Ratos", "Computadores", "Acessórios", "Scanners", "Teclados", "Modems"];
  	$scope.salesPerCategory = [3000, 5000, 1000,200,2300,1000];




  	var categoriesNames = function(categories){
		var categoriesNames = [];
		categories.forEach(function(element){
			categoriesNames.push(element.description);
		});
  		return categoriesNames;
  	}

  	var calcMonthsBetween = function(start,end){
  		var months = [];
  		var tmp = start;
  		do {
  			months.push(tmp.month());
			tmp.add(1,'months'); 
  		}while(tmp.isBefore(end));
  		return months;
  	}

  	var monthsNames = function(months){
		var mN = ["jan", "fev", "mar", "abr", "mai", "jun", "jul", "ago","set","out", "nov", "dez"];
		var monthsWithNames = [];
		months.forEach(function(element){
			monthsWithNames.push(mN[element]);
		});
  		return monthsWithNames;
  	};

  	/******************** 3rd card ************************/
  	var yesterdaySales = 0;
  	var yesterdayPurchases = 0;
  	var todayPurchases = 0;
  	var todaySales = 0;
  	sales.forEach(function(sale){
  		if(moment(sale.Data)){

  		}
  	});




}]);
