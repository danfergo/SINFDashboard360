angular.module('dash-clients').
controller('clientsController', ['$scope','Client', '$filter', function ($scope, Client, $filter) {
	$scope.$parent.pageTitle = "Clientes";
	$scope.clients = null;

	Client.query(function(data){

    data.forEach(function(element){
      element.ValorTotal = element.ValorTotal > 0 ? Math.round(element.ValorTotal * 100) / 100 : -Math.round(element.ValorTotal * 100) / 100;
      element.ValorPendente = element.ValorPendente > 0 ? Math.round(element.ValorPendente * 100) / 100 : -Math.round(element.ValorPendente * 100) / 100;
    });

    $scope.clients = $filter('orderBy')(data, 'ValorTotal', true);

    var debtors = $filter('orderBy')(data, 'ValorPendente', true);
    var buyers = $scope.clients;

    $scope.series = ['Series A'];

    $scope.labelsbuyers = [];
    $scope.dataBuyers = [[]];

    $scope.labelsDebtors = [];
    $scope.dataDebtors = [[]];

    for(var i = 0; i < 6; i++){
      $scope.labelsbuyers.push(buyers[i].name.replace(/[^A-Z]/g, ''));
      $scope.dataBuyers[0].push(buyers[i].ValorTotal);
      $scope.labelsDebtors.push(debtors[i].name.replace(/[^A-Z]/g, ''));
      $scope.dataDebtors[0].push(debtors[i].ValorPendente);
    }
	});

  $scope.formatNumber = function(i) {
    return Math.round(i * 100)/100;
  }

}]);
