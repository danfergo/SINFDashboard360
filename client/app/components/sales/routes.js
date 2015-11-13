angular.module('dash-sales', []).
config(function ($stateProvider) {
  $stateProvider.
  state('sales', {
    parent: 'ts',
    url: 'sales',
    controller: 'salesController',
    templateUrl: 'components/sales/index.html',
    /*data: {
      permissions: {
        only: ['user'],
        redirectTo: 'index'
      }
    }*/
  });
});
