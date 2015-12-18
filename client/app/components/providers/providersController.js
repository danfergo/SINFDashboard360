angular.module('dash-providers').
controller('providersController', ['$scope','Provider', '$filter', function ($scope, Provider, $filter) {
	$scope.$parent.pageTitle = "Fornecedores";
	$scope.clients = null;

	Provider.query(function(data){

    data.forEach(function(element){
      element.valorEncomendas = element.valorEncomendas > 0 ? Math.round(element.valorEncomendas * 100) / 100 : -Math.round(element.valorEncomendas * 100) / 100;
      element.porPagar = element.porPagar > 0 ? Math.round(element.porPagar * 100) / 100 : -Math.round(element.porPagar * 100) / 100;
    });

    $scope.clients = $filter('orderBy')(data, 'valorEncomendas', true);

    var debtors = $filter('orderBy')(data, 'porPagar', true);
    var buyers = $scope.clients;

    $scope.series = ['Series A'];

    $scope.labelsbuyers = [];
    $scope.dataBuyers = [[]];

    $scope.labelsDebtors = [];
    $scope.dataDebtors = [[]];

    for(var i = 0; i < 6; i++){
      $scope.labelsbuyers.push(buyers[i].name.replace(/[^A-Z]/g, ''));
      $scope.dataBuyers[0].push(buyers[i].valorEncomendas);
      $scope.labelsDebtors.push(debtors[i].name.replace(/[^A-Z]/g, ''));
      $scope.dataDebtors[0].push(debtors[i].porPagar);
    }
	});

  $scope.formatNumber = function(i) {
    return Math.round(i * 100)/100;
  }

}]);
