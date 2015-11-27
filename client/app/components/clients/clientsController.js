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

  $scope.labels = ['João', 'Pedro', 'Maria', 'Joana', 'António', 'Rui', 'Ricardo'];
  $scope.series = ['Series A'];

  $scope.data = [
    [28, 48, 40, 19, 86, 27, 90]
  ];
         
}]);
