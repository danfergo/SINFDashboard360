angular.module('dash-clients').
controller('clientsController', ['$scope','Client', function ($scope, Client) {
	$scope.$parent.pageTitle = "Clientes";
	$scope.clients = null;

	Client.query(function(data){
		$scope.clients = data;
	});
		
		/*
	$scope.toggle = function(event){
		$(event.currentTarget).toggleClass('active');
	}*/
}]);
