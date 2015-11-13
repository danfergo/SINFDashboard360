angular.module('dash-purchases', []).
config(function ($stateProvider) {
  $stateProvider.
  state('purchases', {
    parent: 'ts',
    url: 'purchases',
    controller: 'purchasesController',
    templateUrl: 'components/purchases/index.html',
    /*data: {
      permissions: {
        only: ['user'],
        redirectTo: 'index'
      }
    }*/
  });
});
