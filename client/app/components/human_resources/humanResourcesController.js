angular.module('dash-humanResources').
controller('humanResourcesController', ['$scope', 'Deparment', function ($scope, Deparment) {
	$scope.$parent.pageTitle = "Human Resources";
	$scope.departments = null;

	Deparment.query(function(data){
		$scope.departments = data;
	});

	$scope.getTotalSalaries = function(department){
		var total = 0;
		for(var e in department.employees){
			total  += department.employees[e].salary;
		}
		return total;
	}


	$scope.toggle = function(event){
		$(event.currentTarget).toggleClass('active');
	}

}]);
