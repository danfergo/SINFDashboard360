angular.module('dash-sales').
controller('salesController', ['$scope','Sale','$filter', "ProductCategory", function ($scope, Sale, $filter, ProductCategory) {
	$scope.$parent.pageTitle = "Vendas";

	$scope.today = new Date(); 
	$scope.maxDate = new Date(); 
	$scope.minDate = moment($scope.maxDate).subtract(1, 'y').toDate(); // 12/10/2015 -90);

	$scope.productCategories = false;
	ProductCategory.query(function(productCategories){


		$scope.filterResults = function(){
			$scope.sales = null;
			Sale.query({
						min_date: $filter('date')($scope.minDate,'dd-MM-yyyy'),
					 	max_date: $filter('date')($scope.maxDate,'dd-MM-yyyy') 
						}, 
			function(data){
				var months = calcMonthsBetween(moment($scope.minDate),moment($scope.maxDate));
				$scope.sales = data;
				$scope.months = monthsNames(months);
				$scope.categories = categoriesNames(productCategories);
			  	$scope.salesPerCategory =  calcSalesPerCategory(data,$scope.categories ,months,moment($scope.minDate).year());
			});
		}

			

		$scope.filterResults();
	});


	$scope.toggle = function(event){
		$(event.currentTarget).toggleClass('active');
	}



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

  	var calcSalesPerCategory = function(sales, categories, months,startYear){
  		var year = startYear;
  		var salesPerCategory = [];
  		categories.forEach(function(category){
			year = startYear;					  		

  			var categorySales = [];
			months.forEach(function(month){

				var sum = 0;
				sales.forEach(function(sale){

					if(moment(sale.Data).month() == month &&  moment(sale.Data).year() == year ){

						for(var ld in sale.LinhasDoc){

							if(sale.LinhasDoc[ld].CategoriaArtigo == category){

								sum += sale.LinhasDoc[ld].TotalILiquido	;
							}
						}	
					}
				});
				categorySales.push(sum);
				if(month == 11) year++;
			});
  			salesPerCategory.push(categorySales);
  		});
  		return salesPerCategory;
  	};

  	var monthsNames = function(months){
		var mN = ["jan", "fev", "mar", "abr", "mai", "jun", "jul", "ago","set","out", "nov", "dez"];
		var monthsWithNames = [];
		months.forEach(function(element){
			monthsWithNames.push(mN[element]);
		});
  		return monthsWithNames;
  	};

}]);
